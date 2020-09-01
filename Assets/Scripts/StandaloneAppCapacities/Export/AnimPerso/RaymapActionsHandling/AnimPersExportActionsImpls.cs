using Assets.Scripts.Modules.RaymapPlayApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.RaymapActionsHandling
{
    public static class AnimPersoExportActionsImplementations
    {
        public static void ExportPerso(string persoName, string outputFile)
        {
            var animPersoModel = 
                RaymapSceneHelper.IteratePersoGameObjects().Where(x => x.name.Equals(persoName)).First().GetComponent<AnimPersoExportComponent>().ExportAnimatedPerso();
            throw new NotImplementedException();
        }

        public static void ExportAllPersosToDirectory(string outputDirectory)
        {
            foreach (var persoGameObject in RaymapSceneHelper.IteratePersoGameObjects())
            {
                var animPersoModel = persoGameObject.GetComponent<AnimPersoExportComponent>().ExportAnimatedPerso();
                throw new NotImplementedException();
            }
        }
    }
}
