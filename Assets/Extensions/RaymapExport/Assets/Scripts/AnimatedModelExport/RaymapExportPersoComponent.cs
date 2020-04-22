using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport
{
    public class RaymapExportPersoComponent : MonoBehaviour
    {
        public void ExportModelWithAnimations(string outputFilePath)
        {
            var exporter = new RaymapAnimatedPersoExporter();

            PersoAccessor persoAccessor = GetPersoAccessor(gameObject);

            RaymapAnimatedPersoDescription result = exporter.Export(persoAccessor);
            var fileContent = JsonConvert.SerializeObject(result);
            File.WriteAllText(outputFilePath, fileContent);
        }

        private PersoAccessor GetPersoAccessor(GameObject persoGameObject)
        {
            return PersoAccessorFactory.FromPersoGameObject(persoGameObject);
        }
    }
}
