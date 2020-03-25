using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3
{
    public class RaymapExportR3PersoModelExport : MonoBehaviour
    {
        public void ExportModelWithAnimations(string outputFilePath)
        {
            var exporter = new RaymapAnimatedPersoR3Exporter();
            RaymapAnimatedPersoDescriptionR3 result = exporter.export(gameObject);
            var fileContent = JsonConvert.SerializeObject(result);
            File.WriteAllText(outputFilePath, fileContent);
        }
    }
}
