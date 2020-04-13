using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport
{
    [CustomEditor(typeof(RaymapExportPersoComponent))]
    public class RaymapExportPersoComponentEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            RaymapExportPersoComponent modelExport = (RaymapExportPersoComponent)target;

            if (GUILayout.Button("Export model with animations"))
            {
                var outputFilePath = EditorUtility.SaveFilePanel(
                    "Save model as RAYMAPEXPORT",
                    "",
                    modelExport.gameObject.name + ".raymapexport",
                    "raymapexport"
                    );
                modelExport.ExportModelWithAnimations(outputFilePath);
            }
        }
    }
}
