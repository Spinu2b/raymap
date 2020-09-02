using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using Assets.Scripts.StandaloneAppCapacities.Export.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Visuals
{
    public static class Textures2DSetBuildConsolidator
    {
        public static void AddTexture(VisualData texture2DData, Dictionary<string, Texture2D> textures, Dictionary<string, Image> images)
        {
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(textures, texture2DData.textures);
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(images, texture2DData.images);
        }
    }

    public class VisualDataBuilder
    {
        private VisualData result = new VisualData();

        public VisualDataBuilder SetMaterial(Material material)
        {
            result.materials = new Dictionary<string, Material>() { { material.identifier, material } };
            return this;
        }

        public VisualDataBuilder SetTextures(Dictionary<string, Texture2D> textures)
        {
            result.textures = textures;
            return this;
        }

        public VisualDataBuilder SetImages(Dictionary<string, Image> images)
        {
            result.images = images;
            return this;
        }

        public VisualData Build()
        {
            return result;
        }
    }

    public class MaterialVisualDataBuilder
    {
        private Material resultMaterial = new Material();
        private Dictionary<string, Texture2D> resultTextures = new Dictionary<string, Texture2D>();
        private Dictionary<string, Image> resultImages = new Dictionary<string, Image>();

        public void SetMaterialBaseClass(MaterialBaseClass materialClass)
        {
            throw new NotImplementedException();
        }

        public void SetFloat(string floatName, float floatValue)
        {
            resultMaterial.SetFloat(floatName, floatValue);
        }

        public void SetTexture(string textureName, VisualData texture2DData)
        {
            var onlyPredictedObjectTexture = VisualDataHelper.GetOnlyPredictedObjectTexture(texture2DData);
            resultMaterial.AddTexture(textureName, onlyPredictedObjectTexture);
            Textures2DSetBuildConsolidator.AddTexture(texture2DData, resultTextures, resultImages);
        }

        public VisualData Build()
        {
            resultMaterial.identifier = resultMaterial.description.ComputeIdentifier();
            return new VisualDataBuilder().SetMaterial(resultMaterial).SetTextures(resultTextures).SetImages(resultImages).Build();
        }

        public void SetVector(string vectorName, Vector vector)
        {
            resultMaterial.description.vectors[vectorName] = vector;
        }
    }
}
