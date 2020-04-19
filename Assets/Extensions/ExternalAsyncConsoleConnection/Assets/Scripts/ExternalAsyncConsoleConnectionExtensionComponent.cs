using Assets.Extensions.Api;
using Assets.Extensions.EditorActions.Assets.Scripts;
using Assets.Extensions.EditorActions.Assets.Scripts.BuiltinActions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Extensions.ExternalAsyncConsole.Assets.Scripts
{
    public static class ExternalAsyncConsoleActions
    {
        public static string useExternalAsyncConsole = "USE_EXTERNAL_ASYNC_CONSOLE";

        public static class UseExternalAsyncConsoleArguments
        {
            public static string pipeName = "PIPE_NAME";
        }
    }

    public static class AsyncConsoleLogger
    {
        private static ExternalAsyncConsoleConnectionExtensionComponent externalAsyncConsoleConnectionExtensionComponent;

        public static void LogDebug(string message)
        {
            if (externalAsyncConsoleConnectionExtensionComponent != null)
            {
                externalAsyncConsoleConnectionExtensionComponent.LogDebug(message);
            }
            UnityEngine.Debug.Log(message);
        }
    }

    public class ExternalAsyncConsoleConnectionExtensionComponent : RaymapExtensionComponent, IEditorActionListenerComponent
    {
        private AsyncConsoleConnectionThreadHandler asyncConsoleConnectionThreadHandler = new AsyncConsoleConnectionThreadHandler();

        public void OnEditorAction(EditorActionsExtensionComponent editorActionsExtensionComponent, 
            string actionName, Dictionary<string, string> actionArguments)
        {
            if (actionName.Equals(ExternalAsyncConsoleActions.useExternalAsyncConsole))
            {
                ConnectToExternalAsyncConsole(actionArguments[ExternalAsyncConsoleActions.UseExternalAsyncConsoleArguments.pipeName]);
                editorActionsExtensionComponent.SetActionCompleted(actionName);
            } 
            else if (actionName.Equals(ExitAction.actionName)) {
                EndExternalConsoleConnection();
                editorActionsExtensionComponent.SetActionCompleted(actionName);
            }
            else
            {
                throw new InvalidOperationException("Invalid action for external async console extension!");
            }            
        }

        private void EndExternalConsoleConnection()
        {
            asyncConsoleConnectionThreadHandler.EndConnection();
        }

        private void ConnectToExternalAsyncConsole(string pipeName)
        {
            asyncConsoleConnectionThreadHandler.StartConsoleHandling(pipeName);
        }

        public void RegisterForActions(EditorActionsExtensionComponent editorActionsExtensionComponent)
        {
            editorActionsExtensionComponent.SetActionListener(ExternalAsyncConsoleActions.useExternalAsyncConsole, this);
            editorActionsExtensionComponent.SetActionListener(ExitAction.actionName, this);
        }

        protected override void OnMapLoaded()
        {
            //throw new NotImplementedException();
        }

        public void LogDebug(string message)
        {
            asyncConsoleConnectionThreadHandler.LogDebug(message);
        }
    }
}
