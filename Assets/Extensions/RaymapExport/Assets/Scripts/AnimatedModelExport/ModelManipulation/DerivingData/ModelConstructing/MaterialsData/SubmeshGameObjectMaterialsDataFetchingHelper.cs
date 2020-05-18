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
        public static List<Tuple<Material, List<string>>> 
            GetGouraudShaderedMaterialData(GameObject elementGameObject)
        {
            var gouraudMaterials = GetRaymapGouraudMaterials(elementGameObject);
            var result = new List<Tuple<Material, List<string>>>();
            foreach (var material in gouraudMaterials)
            {
                var textureNamesForMaterial = new List<string>();
                for (int i = 0; i < RaymapGouraudShaderDescription.GetTexturesCount(material); i++)
                {
                    textureNamesForMaterial.AddWithUniqueCheck(RaymapGouraudShaderDescription.GetTextureName(index: i));
                }
                result.Add(new Tuple<Material, List<string>>(material, textureNamesForMaterial));
            }
            return result;
        }

        private static List<Material> GetRaymapGouraudMaterials(GameObject elementGameObject)
        {
            return elementGameObject.GetComponent<Renderer>().materials.Select(x => x).ToList();
        }

        public static IEnumerable<Texture2D> IterateTextures2DOfMaterial(
            UnityEngine.Material unityMaterial, List<string> materialTextureNames)
        {
            List<UnityEngine.Texture> allTexture = new List<UnityEngine.Texture>();
            foreach (var textureName in materialTextureNames)
            {
                UnityEngine.Texture texture = unityMaterial.GetTexture(textureName);
                if (texture is Texture2D)
                {
                    yield return (Texture2D)texture;
                }
            }
        }
    }
}
