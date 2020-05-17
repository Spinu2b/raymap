using Assets.Extensions.Api;
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
    public static class RaymapExportActionsImplementations
    {
        public static void ExportPerso(string persoName, string outputFile)
        {
            RaymapSceneHelper.IteratePersoGameObjects()
                .Where(x => x.name.Equals(persoName)).First().GetComponent<RaymapExportPersoComponent>().ExportModelWithAnimations(outputFile);
        }

        public static void ExportAllPersosToDirectory(string outputDirectory)
        {
            foreach (var persoGameObject in RaymapSceneHelper.IteratePersoGameObjects())
            {
                persoGameObject.GetComponent<RaymapExportPersoComponent>().ExportModelWithAnimations(
                    Path.Combine(outputDirectory, FileNamesHelper.RemoveInvalidCharacters(persoGameObject.name) + ".raymapexport"));
            }
        }
    }
}
