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
                string filePath = FilesHelper.AskForSaveFilepath(caption: "Export animated Perso model path",
                    extension: "animperso", defaultFileName: FilesHelper.RemoveInvalidCharactersFromPath(animPersoExportComponent.gameObject.name + ".animperso"));
                if (!String.IsNullOrWhiteSpace(filePath))
                {
                    AnimatedPersoDescription animatedPersoDescription = animPersoExportComponent.ExportAnimatedPerso();
                    JsonModelFileWriter.WriteTofile(filePath, animatedPersoDescription);
                }                
            }
            GUILayout.EndVertical();
        }
    }
}
