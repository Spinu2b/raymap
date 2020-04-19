using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Extensions.Api;
using Assets.Extensions.EditorActions.Assets.Scripts;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts
{
    public static class RaymapExportActions
    {
        public static string exportAllPersos = "EXPORT_ALL_PERSOS";
        public static string exportPerso = "EXPORT_PERSO";

        public static class ExportAllPersosArguments
        {
            public static string outputDirectory = "OUTPUT_DIRECTORY";
        }

        public static class ExportPersoArguments
        {
            public static string persoName = "PERSO_NAME";
            public static string outputFile = "OUTPUT_FILE";
        }
    }

    public class RaymapExportExtensionComponent : RaymapExtensionComponent, IEditorActionListenerComponent
    {
        private Queue<Tuple<string, Dictionary<string, string>>> actionsToPerform = new Queue<Tuple<string, Dictionary<string, string>>>();
        private bool injected = false;

        private EditorActionsExtensionComponent editorActionsExtensionComponent;

        protected override void OnMapLoaded()
        {
            InjectIntoPersos();
            injected = true;

            if (actionsToPerform.Count != 0)
            {
                PerformScheduledActions(editorActionsExtensionComponent);
            }
        }

        private void InjectIntoPersos()
        {
            foreach (var persoGameObject in RaymapSceneHelper.IteratePersoGameObjects())
            {
                OnPersoInject(persoGameObject);
            }
        }

        protected void OnPersoInject(GameObject persoGameObject)
        {
            persoGameObject.AddComponent<RaymapExportPersoComponent>();
        }

        public void OnEditorAction(EditorActionsExtensionComponent editorActionsExtensionComponent, 
            string actionName, Dictionary<string, string> actionArguments)
        {
            actionsToPerform.Enqueue(new Tuple<string, Dictionary<string, string>>(actionName, actionArguments));
            if (injected)
            {
                PerformScheduledActions(editorActionsExtensionComponent);
            }
        }

        public void RegisterForActions(EditorActionsExtensionComponent editorActionsExtensionComponent)
        {
            editorActionsExtensionComponent.SetActionListener(RaymapExportActions.exportAllPersos, this);
            editorActionsExtensionComponent.SetActionListener(RaymapExportActions.exportPerso, this);
            this.editorActionsExtensionComponent = editorActionsExtensionComponent;
        }

        private void PerformScheduledActions(EditorActionsExtensionComponent editorActionsExtensionComponent)
        {
            while (actionsToPerform.Count != 0)
            {
                var actionInfo = actionsToPerform.Dequeue();
                PerformAction(actionInfo.Item1, actionInfo.Item2);
                editorActionsExtensionComponent.SetActionCompleted(actionInfo.Item1);
            }            
        }

        private void PerformAction(string actionName, Dictionary<string, string> actionArgs)
        {
            if (actionName.Equals(RaymapExportActions.exportAllPersos))
            {
                ExportAllPersosToDirectory(actionArgs[RaymapExportActions.ExportAllPersosArguments.outputDirectory]);
            } else if (actionName.Equals(RaymapExportActions.exportPerso))
            {
                ExportPerso(actionArgs[RaymapExportActions.ExportPersoArguments.persoName],
                    actionArgs[RaymapExportActions.ExportPersoArguments.outputFile]);
            } else
            {
                throw new InvalidOperationException("Invalid action for RaymapExport!");
            }
        }

        private void ExportPerso(string persoName, string outputFile)
        {
            RaymapSceneHelper.IteratePersoGameObjects()
                .Where(x => x.name.Equals(persoName)).First().GetComponent<RaymapExportPersoComponent>().ExportModelWithAnimations(outputFile);
        }

        private void ExportAllPersosToDirectory(string outputDirectory)
        {
            foreach (var persoGameObject in RaymapSceneHelper.IteratePersoGameObjects())
            {
                persoGameObject.GetComponent<RaymapExportPersoComponent>().ExportModelWithAnimations(
                    Path.Combine(outputDirectory, FileNamesHelper.RemoveInvalidCharacters(persoGameObject.name) + ".raymapexport"));
            }
        }
    }
}
