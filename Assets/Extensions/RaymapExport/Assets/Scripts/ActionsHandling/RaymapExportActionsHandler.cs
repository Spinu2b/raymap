using Assets.Extensions.Api;
using Assets.Extensions.EditorActions.Assets.Scripts;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.ActionsHandling
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

    public class RaymapExportActionsHandler
    {
        private RaymapExportExtensionComponent raymapExportExtensionComponent;
        private Queue<Tuple<string, Dictionary<string, string>>> actionsToPerform = new Queue<Tuple<string, Dictionary<string, string>>>();
        private EditorActionsExtensionComponent editorActionsExtensionComponent;

        public RaymapExportActionsHandler(RaymapExportExtensionComponent raymapExportExtensionComponent)
        {
            this.raymapExportExtensionComponent = raymapExportExtensionComponent;
        }

        public void PerformScheduledActionsIfAny()
        {
            while (actionsToPerform.Count != 0)
            {
                var actionInfo = actionsToPerform.Dequeue();
                PerformAction(actionInfo.Item1, actionInfo.Item2);
                editorActionsExtensionComponent.SetActionCompleted(raymapExportExtensionComponent, actionInfo.Item1);
            }
        }

        private void PerformAction(string actionName, Dictionary<string, string> actionArgs)
        {
            if (actionName.Equals(RaymapExportActions.exportAllPersos))
            {
                RaymapExportActionsImplementations.ExportAllPersosToDirectory(actionArgs[RaymapExportActions.ExportAllPersosArguments.outputDirectory]);
            }
            else if (actionName.Equals(RaymapExportActions.exportPerso))
            {
                RaymapExportActionsImplementations.ExportPerso(actionArgs[RaymapExportActions.ExportPersoArguments.persoName],
                    actionArgs[RaymapExportActions.ExportPersoArguments.outputFile]);
            }
            else
            {
                throw new InvalidOperationException("Invalid action for RaymapExport!");
            }
        }

        public void ScheduleAction(string actionName, Dictionary<string, string> actionArguments)
        {
            actionsToPerform.Enqueue(new Tuple<string, Dictionary<string, string>>(actionName, actionArguments));
        }

        public void RegisterForActions(EditorActionsExtensionComponent editorActionsExtensionComponent)
        {
            editorActionsExtensionComponent.SetActionListener(RaymapExportActions.exportAllPersos, raymapExportExtensionComponent);
            editorActionsExtensionComponent.SetActionListener(RaymapExportActions.exportPerso, raymapExportExtensionComponent);
            this.editorActionsExtensionComponent = editorActionsExtensionComponent;
        }
    }
}
