using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export
{
    public static class JsonModelFileWriter
    {
        public static void WriteTofile(string filePath, Object modelToExport)
        {
            string output = JsonConvert.SerializeObject(modelToExport, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}
