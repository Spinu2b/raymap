using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport
{
    public class RaymapExportPersoComponent : MonoBehaviour
    {
        public void ExportModelWithAnimations(string outputFilePath)
        {
            var exporter = new RaymapAnimatedPersoExporter();
            RaymapAnimatedPersoDescription result = exporter.Export(gameObject);
            var fileContent = JsonConvert.SerializeObject(result);
            File.WriteAllText(outputFilePath, fileContent);
        }
    }
}
