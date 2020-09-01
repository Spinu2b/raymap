using Assets.Scripts.StandaloneAppCapacities.RaymapActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.RaymapActionsHandling
{
    public static class AnimPersoExportActions
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

    public class AnimPersosExportRaymapActionsHandler
    {
        private AnimPersosExportRaymapPlayComponent animPersosExportRaymapPlayComponent;
        private Queue<Tuple<string, Dictionary<string, string>>> actionsToPerform = new Queue<Tuple<string, Dictionary<string, string>>>();
        private RaymapActionsModuleComponent raymapActionsModuleComponent;

        public AnimPersosExportRaymapActionsHandler(AnimPersosExportRaymapPlayComponent animPersosExportRaymapPlayComponent)
        {
            this.animPersosExportRaymapPlayComponent = animPersosExportRaymapPlayComponent;
        }

        public void PerformScheduledActionsIfAny()
        {
            while (actionsToPerform.Count != 0)
            {
                var actionInfo = actionsToPerform.Dequeue();
                PerformAction(actionInfo.Item1, actionInfo.Item2);
                raymapActionsModuleComponent.SetActionCompleted(animPersosExportRaymapPlayComponent, actionInfo.Item1);
            }
        }

        private void PerformAction(string actionName, Dictionary<string, string> actionArgs)
        {
            if (actionName.Equals(AnimPersoExportActions.exportAllPersos))
            {
                AnimPersoExportActionsImplementations.ExportAllPersosToDirectory(actionArgs[AnimPersoExportActions.ExportAllPersosArguments.outputDirectory]);
            } else if (actionName.Equals(AnimPersoExportActions.exportPerso))
            {
                AnimPersoExportActionsImplementations.ExportPerso(actionArgs[AnimPersoExportActions.ExportPersoArguments.persoName], actionArgs[AnimPersoExportActions.ExportPersoArguments.outputFile]);
            } else
            {
                throw new InvalidOperationException("Invalid action for Raymap persos export!");
            }
        }

        public void ScheduleAction(string actionName, Dictionary<string, string> actionArguments)
        {
            actionsToPerform.Enqueue(new Tuple<string, Dictionary<string, string>>(actionName, actionArguments));
        }

        public void RegisterForActions(RaymapActionsModuleComponent raymapActionsModuleComponent)
        {
            raymapActionsModuleComponent.SetActionListener(AnimPersoExportActions.exportAllPersos, animPersosExportRaymapPlayComponent);
            raymapActionsModuleComponent.SetActionListener(AnimPersoExportActions.exportPerso, animPersosExportRaymapPlayComponent);
            this.raymapActionsModuleComponent = raymapActionsModuleComponent;
        }
    }
}
