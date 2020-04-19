using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport
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
                    FileNamesHelper.RemoveInvalidCharacters(modelExport.gameObject.name) + ".raymapexport",
                    "raymapexport"
                    );
                if (outputFilePath != null && outputFilePath.Length != 0)
                {
                    modelExport.ExportModelWithAnimations(outputFilePath);
                }                
            }
        }
    }
}
