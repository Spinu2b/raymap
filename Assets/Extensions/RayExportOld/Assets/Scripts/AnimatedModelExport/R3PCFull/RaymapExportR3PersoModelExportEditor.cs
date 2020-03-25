using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3
{
    [CustomEditor(typeof(RaymapExportR3PersoModelExport))]
    public class RaymapExportR3PersoModelExportEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            RaymapExportR3PersoModelExport r3ModelExport = (RaymapExportR3PersoModelExport)target;

            if (GUILayout.Button("Export model with animations"))
            {
                var outputFilePath = EditorUtility.SaveFilePanel(
                    "Save model as RAYMAPEXPORT",
                    "",
                    r3ModelExport.gameObject.name + ".raymapexport",
                    "raymapexport"
                    );
               r3ModelExport.ExportModelWithAnimations(outputFilePath);
            }
        }
    }
}
 