using Assets.Scripts.Unity.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Testing
{
    [CustomEditor(typeof(TestAccessTexture2DMultihreadComponent))]
    public class TestAccessTexture2DMultithreadEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var tat2Dmc = (TestAccessTexture2DMultihreadComponent)target;

            GUILayout.BeginVertical();
            if (GUILayout.Button("Verify accessing Texture2D getPixels from different threads"))
            {
                tat2Dmc.TestAccessingTexture2DGetPixelsMethodFromDifferentThreads();
            }
            GUILayout.EndVertical();
        }
    }
}
