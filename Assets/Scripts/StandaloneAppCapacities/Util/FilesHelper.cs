using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Assets.Scripts.StandaloneAppCapacities.Util
{
    public static class FilesHelper
    {
        public static string AskForSaveFilepath(string caption, string extension, string defaultFileName)
        {
            var path = EditorUtility.SaveFilePanel(caption, "", defaultFileName, extension);
            return path;
        }

        public static string RemoveInvalidCharactersFromPath(string filePath)
        {
            return string.Join("_", filePath.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
