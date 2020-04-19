using Assets.Extensions.Api;
using Assets.Extensions.EditorActions.Assets.Scripts.BuiltinActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.EditorActions.Assets.Scripts
{
    public static class ActionDataSignatures
    {
        public const string editorAction = "--editor_action";
        public const string editorActionArgument = "--editor_action_arg";
    }

    public class ActionListenerInfo
    {
        public IEditorActionListenerComponent listener;
        public bool hasCompleted = false;

        public ActionListenerInfo(IEditorActionListenerComponent actionListener)
        {
            listener = actionListener;
        }
    }

    public class EditorActionsExtensionComponent : RaymapExtensionComponent
    {
        private Dictionary<string, List<ActionListenerInfo>> actionListeners =
            new Dictionary<string, List<ActionListenerInfo>>();
        private Queue<ScheduledAction> scheduledActions = new Queue<ScheduledAction>();

        public void SetActionListener(string actionName, IEditorActionListenerComponent actionListener)
        {
            if (!actionListeners.ContainsKey(actionName))
            {
                actionListeners.Add(actionName, new List<ActionListenerInfo>());
            }
            if (actionListeners[actionName].Any(x => x.listener == actionListener))
            {
                throw new InvalidOperationException("Action listener already is given for given action!");
            }
            actionListeners[actionName].Add(new ActionListenerInfo(actionListener));
        }

        public void SetActionCompleted(IEditorActionListenerComponent actionListener, string actionName)
        {
            foreach (var entry in actionListeners[actionName])
            {
                if (entry.listener == actionListener)
                {
                    if (entry.hasCompleted)
                    {
                        throw new InvalidOperationException("Reporting finishing action for given listener more than once!");
                    }
                    entry.hasCompleted = true;
                }
            }

            foreach (var entry in actionListeners[actionName])
            {
                if (entry.hasCompleted == false)
                {
                    return;
                }
            }

            if (actionName.Equals(ExitAction.actionName))
            {
                Application.Quit();
            }

            scheduledActions.Dequeue();
            if (scheduledActions.Count != 0)
            {
                var scheduledAction = scheduledActions.Peek();
                foreach (var listenerInfo in actionListeners[scheduledAction.actionName])
                {
                    listenerInfo.listener.OnEditorAction(this, scheduledAction.actionName, scheduledAction.actionArguments);
                }
            }
        }

        protected override void OnMapLoaded()
        {
            
        }

        private void Start()
        {
            string[] args = System.Environment.GetCommandLineArgs();
            ScheduledActionBuilder scheduledActionBuilder = new ScheduledActionBuilder();

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case ActionDataSignatures.editorAction:
                        var scheduledAction = scheduledActionBuilder.BuildIfPresentOrReturnNull();
                        if (scheduledAction != null)
                        {
                            scheduledActions.Enqueue(scheduledAction);
                        }                        

                        scheduledActionBuilder = new ScheduledActionBuilder();
                        scheduledActionBuilder.SetActionName(args[i + 1]);
                        i++;
                        break;

                    case ActionDataSignatures.editorActionArgument:
                        scheduledActionBuilder.AddActionArgument(args[i + 1], args[i + 2]);
                        i += 2;
                        break;
                }
            }

            foreach (var actionListener in 
                UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour)).OfType<IEditorActionListenerComponent>())
            {
                actionListener.RegisterForActions(this);
            }
            
            if (scheduledActions.Count != 0)
            {
                var scheduledAction = scheduledActions.Peek();
                foreach (var listenerInfo in actionListeners[scheduledAction.actionName])
                {
                    listenerInfo.listener.OnEditorAction(this, scheduledAction.actionName, scheduledAction.actionArguments);
                }
            }
        }
    }
}
