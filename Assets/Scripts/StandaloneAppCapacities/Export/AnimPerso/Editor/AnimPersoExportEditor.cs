using Assets.Scripts.Editor.Util;
using Assets.Scripts.StandaloneAppCapacities.Export;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Editor
{
    [CustomEditor(typeof(AnimPersoExportComponent))]
    public class AnimPersoExportEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            AnimPersoExportComponent animPersoExportComponent = (AnimPersoExportComponent)target;

            GUILayout.BeginVertical();
            if (GUILayout.Button("Export animated perso"))
            {
                AnimatedPersoDescription animatedPersoDescription = animPersoExportComponent.ExportAnimatedPerso();
                string filePath = Path.Combine(UnitySettings.ExportPath, "PersoModelExport",
                    FilesHelper.AvoidNotAllowedCharsInFilepath(animatedPersoDescription.name) + ".animperso");
                JsonModelFileWriter.WriteTofile(filePath, animatedPersoDescription);               
            }
            GUILayout.EndVertical();
        }
    }
}
