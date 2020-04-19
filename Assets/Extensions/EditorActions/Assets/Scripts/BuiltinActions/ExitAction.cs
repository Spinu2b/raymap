using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.EditorActions.Assets.Scripts.BuiltinActions
{
    public class ExitAction : IEditorActionListenerComponent
    {
        public const string actionName = "EXIT_ACTION";

        public void OnEditorAction(string actionName, Dictionary<string, string> actionArguments)
        {
            Application.Quit();
        }

        public void RegisterForActions(EditorActionsExtensionComponent editorActionsExtensionComponent)
        {
            editorActionsExtensionComponent.SetActionListener(actionName, this);
        }
    }
}
