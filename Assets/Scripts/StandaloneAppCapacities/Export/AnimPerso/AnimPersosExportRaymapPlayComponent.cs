using Assets.Scripts.Modules.RaymapPlayApi;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.RaymapActionsHandling;
using Assets.Scripts.StandaloneAppCapacities.RaymapActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso
{
    public class AnimPersosExportRaymapPlayComponent : RaymapPlayComponent, IRaymapActionListenerComponent
    {
        private bool injected = false;
        private AnimPersosExportRaymapActionsHandler animPersosExportRaymapActionsHandler;

        protected override void OnMapLoaded()
        {
            Controller raymapController = RaymapSceneHelper.GetController();

            InjectIntoPersos();
            injected = true;
            animPersosExportRaymapActionsHandler.PerformScheduledActionsIfAny();
        }

        private void InjectIntoPersos()
        {
            foreach (var persoGameObject in RaymapSceneHelper.IteratePersoGameObjects())
            {
                OnPersoInject(persoGameObject);
            }
        }

        private void OnPersoInject(GameObject persoGameObject)
        {
            persoGameObject.AddComponent<AnimPersoExportComponent>();
        }

        public void OnRaymapAction(RaymapActionsModuleComponent raymapActionsModuleComponent, string actionName, Dictionary<string, string> actionArguments)
        {
            animPersosExportRaymapActionsHandler.ScheduleAction(actionName, actionArguments);
            if (injected)
            {
                animPersosExportRaymapActionsHandler.PerformScheduledActionsIfAny();
            }
        }

        public void RegisterForActions(RaymapActionsModuleComponent raymapActionsModuleComponent)
        {
            animPersosExportRaymapActionsHandler = new AnimPersosExportRaymapActionsHandler();
            animPersosExportRaymapActionsHandler.RegisterForActions(raymapActionsModuleComponent);
        }
    }
}
