using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Shaders;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class SubmeshGameObjectMaterialsDataFetchingHelper
    {
        public static List<Tuple<Material, HashSet<string>>> 
            GetGouraudShaderedMaterialData(GameObject elementGameObject)
        {
            var gouraudMaterials = GetRaymapGouraudMaterials(elementGameObject);
            var result = new List<Tuple<Material, HashSet<string>>();
            foreach (var material in gouraudMaterials)
            {
                var textureNamesForMaterial = new HashSet<string>();
                for (int i = 0; i < RaymapGouraudShaderDescription.GetTexturesCount(material); i++)
                {
                    textureNamesForMaterial.AddWithUniqueCheck(RaymapGouraudShaderDescription.GetTextureName(index: i));
                }
                result.Add(new Tuple<Material, HashSet<string>>(material, textureNamesForMaterial));
            }
            return result;
        }

        private static List<Material> GetRaymapGouraudMaterials(GameObject elementGameObject)
        {
            return elementGameObject.GetComponent<Renderer>().materials.Select(x => x).ToList();
        }
    }
}
