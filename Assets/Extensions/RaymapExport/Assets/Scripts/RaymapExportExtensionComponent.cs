using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Extensions.Api;
using Assets.Extensions.EditorActions.Assets.Scripts;
using Assets.Extensions.RaymapExport.Assets.Scripts.ActionsHandling;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts
{
    public class RaymapExportExtensionComponent : RaymapExtensionComponent, IEditorActionListenerComponent
    {
        private bool injected = false;
        private RaymapExportActionsHandler raymapExportActionsHandler;

        private EnvironmentContext environmentContext = new EnvironmentContext();

        protected override void OnMapLoaded()
        {
            Controller raymapController = RaymapSceneHelper.GetController();

            raymapController.playTextureAnimations = false;
            raymapController.playAnimations = false;

            environmentContext.Init();
            InjectIntoPersos(environmentContext);

            injected = true;
            raymapExportActionsHandler.PerformScheduledActionsIfAny();
        }

        private void InjectIntoPersos(EnvironmentContext environmentContext)
        {
            foreach (var persoGameObject in RaymapSceneHelper.IteratePersoGameObjects())
            {
                OnPersoInject(persoGameObject, environmentContext);
            }
        }

        protected void OnPersoInject(GameObject persoGameObject, EnvironmentContext environmentContext)
        {
            persoGameObject.AddComponent<RaymapExportPersoComponent>();
            persoGameObject.GetComponent<RaymapExportPersoComponent>().SetEnvironmentContext(environmentContext);
        }

        public void OnEditorAction(EditorActionsExtensionComponent editorActionsExtensionComponent, 
            string actionName, Dictionary<string, string> actionArguments)
        {
            raymapExportActionsHandler.ScheduleAction(actionName, actionArguments);
            if (injected)
            {
                raymapExportActionsHandler.PerformScheduledActionsIfAny();
            }
        }

        public void RegisterForActions(EditorActionsExtensionComponent editorActionsExtensionComponent)
        {
            raymapExportActionsHandler = new RaymapExportActionsHandler(this);
            raymapExportActionsHandler.RegisterForActions(editorActionsExtensionComponent);
        }    
    }
}
