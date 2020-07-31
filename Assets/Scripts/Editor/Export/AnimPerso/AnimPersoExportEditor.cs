using Assets.Scripts.Editor.Util;
using Assets.Scripts.Unity.Export;
using Assets.Scripts.Unity.Export.AnimPerso;
using Assets.Scripts.Unity.Export.AnimPerso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Export.AnimPerso
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
                string filePath = FilesHelper.GetFilePathToSave(
                    extension: "animPerso", label: "Choose file path to export animated perso model to", description: "Animated perso description");
                if (filePath != null)
                {
                    AnimatedPersoDescription animatedPersoDescription = animPersoExportComponent.ExportAnimatedPerso();
                    JsonModelFileWriter.WriteTofile(filePath, animatedPersoDescription);
                }                
            }
            GUILayout.EndVertical();
        }
    }
}
