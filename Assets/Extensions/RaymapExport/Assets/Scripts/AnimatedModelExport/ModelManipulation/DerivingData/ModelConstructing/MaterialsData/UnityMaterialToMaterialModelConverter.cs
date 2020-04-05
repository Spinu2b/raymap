using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class UnityMaterialToMaterialModelConverter
    {
        public static Tuple<AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material,
            Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>,
            Dictionary<string, Image>> Convert(UnityEngine.Material unityMaterial, List<string> materialTextureNames)
        {
            var texturesResult = new Dictionary<string, 
                AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>();
            var imagesResult = new Dictionary<string, Image>();

            var texturesHashes = new List<string>();
            foreach (var materialTexture2D in 
                SubmeshGameObjectMaterialsDataFetchingHelper.IterateTextures2DOfMaterial(unityMaterial, materialTextureNames))
            {
                Image imageModel = ImageModelFactory.GetImageModel(materialTexture2D);
                string imageHash = imageModel.name;

                var textureModel = TextureModelFactory.GetTextureModel(materialTexture2D, imageHash);
                string textureHash = textureModel.name;

                texturesHashes.AddWithUniqueCheck(textureHash);

                texturesResult.Add(imageHash, textureModel);
                imagesResult.Add(imageHash, imageModel);
            }

            var resultMaterialModel = MaterialModelFactory.GetMaterialModel(unityMaterial, materialTextureNames, texturesHashes);
            return new Tuple<
                AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material,
                Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>,
                Dictionary<string, Image>>(resultMaterialModel, texturesResult, imagesResult);
        } 
    }
}
