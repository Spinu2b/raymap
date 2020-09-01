using Assets.Scripts.Modules.RaymapPlayApi;
using Assets.Scripts.StandaloneAppCapacities.RaymapActions.BuiltinActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.RaymapActions
{
    public static class ActionDataSignatures
    {
        public const string raymapAction = "--raymap_action";
        public const string raymapActionArgument = "--raymap_action_arg";
    }

    public class ActionListenerInfo
    {
        public IRaymapActionListenerComponent listener;
        public bool hasCompleted = false;

        public ActionListenerInfo(IRaymapActionListenerComponent actionListener)
        {
            listener = actionListener;
        }
    }

    public class RaymapActionsModuleComponent : RaymapPlayComponent
    {
        private Dictionary<string, List<ActionListenerInfo>> actionListeners = new Dictionary<string, List<ActionListenerInfo>>();
        private Queue<ScheduledAction> scheduledActions = new Queue<ScheduledAction>();

        public void SetActionListener(string actionName, IRaymapActionListenerComponent actionListener)
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

        public void SetActionCompleted(IRaymapActionListenerComponent actionListener, string actionName)
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
                    listenerInfo.listener.OnRaymapAction(this, scheduledAction.actionName, scheduledAction.actionArguments);
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
                    case ActionDataSignatures.raymapAction:
                        var scheduledAction = scheduledActionBuilder.BuildIfPresentOrReturnNull();
                        if (scheduledAction != null)
                        {
                            scheduledActions.Enqueue(scheduledAction);
                        }

                        scheduledActionBuilder = new ScheduledActionBuilder();
                        scheduledActionBuilder.SetActionName(args[i + 1]);
                        i++;
                        break;

                    case ActionDataSignatures.raymapActionArgument:
                        scheduledActionBuilder.AddActionArgument(args[i + 1], args[i + 2]);
                        i += 2;
                        break;
                }
            }

            foreach (var actionListener in UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour)).OfType<IRaymapActionListenerComponent>())
            {
                actionListener.RegisterForActions(this);
            }

            if (scheduledActions.Count != 0)
            {
                var scheduledAction = scheduledActions.Peek();
                foreach (var listenerInfo in actionListeners[scheduledAction.actionName])
                {
                    listenerInfo.listener.OnRaymapAction(this, scheduledAction.actionName, scheduledAction.actionArguments);
                }
            }
        }
    }
}
