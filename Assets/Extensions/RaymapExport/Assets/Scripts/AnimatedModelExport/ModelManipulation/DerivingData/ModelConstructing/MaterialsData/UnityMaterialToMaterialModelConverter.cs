using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class UnityMaterialToMaterialVisualDataConverter
    {
        public static VisualData Convert(UnityEngine.Material unityMaterial, List<string> materialTextureNames)
        {
            var texturesResult = new Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc.Texture>();
            var imagesResult = new Dictionary<string, Image>();

            var texturesHashes = new List<string>();
            foreach (var materialTexture2D in 
                SubmeshGameObjectMaterialsDataFetchingHelper.IterateTextures2DOfMaterial(unityMaterial, materialTextureNames))
            {
                Image imageModel = ImageModelFactory.GetImageModel(materialTexture2D);
                string imageHash = imageModel.imageDescriptionHash;

                var textureModel = TextureModelFactory.GetTextureModel(materialTexture2D, imageHash);
                string textureHash = textureModel.textureDescriptionHash;

                texturesHashes.AddWithUniqueCheck(textureHash);

                texturesResult.Add(imageHash, textureModel);
                imagesResult.Add(imageHash, imageModel);
            }

            var resultMaterialModel = MaterialModelFactory.GetMaterialModel(unityMaterial, materialTextureNames, texturesHashes);
            var materialDict = new Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc.Material>();
            materialDict.Add(resultMaterialModel.materialDescriptionHash, resultMaterialModel);

            var result = new VisualData();
            result.materials = materialDict;
            result.textures = texturesResult;
            result.images = imagesResult;
            return result;
        } 
    }
}
