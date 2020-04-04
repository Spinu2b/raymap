using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public static class TexturesModelsUnifier
    {
        public static Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>
            Unify(List<Dictionary<string,
                AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>> texturesModels)
        {
            throw new NotImplementedException();
        }
    }

    public static class ImagesModelsUnifier
    {
        public static Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Image>
            Unify(List<Dictionary<string,
                AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Image>> imagesModels)
        {
            throw new NotImplementedException();
        }
    }

    public static class UnityMaterialsToMaterialsTexturesImagesModelConverter
    {
        public static Tuple<Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material>,
            Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>,
            Dictionary<string, Image>> Convert(List<Tuple<UnityEngine.Material, HashSet<string>>> materialsTextureNamesInfo)
        {
            var materialsResult = materialsTextureNamesInfo.ToDictionary(x => x.Item1.name, x => GetMaterialModel(x.Item1, x.Item2));
            var texturesResult = GetTextureModelsForMaterials(materialsTextureNamesInfo);
            var imagesResult = GetImageModelsForMaterialsTextures(materialsTextureNamesInfo);
            return new Tuple<Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material>,
            Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>,
            Dictionary<string, Image>>(materialsResult, texturesResult, imagesResult);
        }

        private static Dictionary<string, Image>
            GetImageModelsForMaterialsTextures(List<Tuple<UnityEngine.Material, HashSet<string>>> materialsTextureNamesInfo)
        {
            var resultList = new List<Dictionary<string,
                AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Image>>();
            foreach (var materialTextureNamesInfo in materialsTextureNamesInfo)
            {
                resultList.Add(GetMaterialImagesObjsFor(materialTextureNamesInfo.Item1, materialTextureNamesInfo.Item2));
            }
            return ImagesModelsUnifier.Unify(resultList);
        }

        private static Dictionary<string, Image> GetMaterialImagesObjsFor(UnityEngine.Material unityMaterial,
            HashSet<string> materialTextureNames)
        {
            Func<string, string> CreateImageIdentifier = (string texture2DName) => {
                throw new NotImplementedException();
            };

            return IterateTextures2DOfMaterial(unityMaterial, materialTextureNames).ToDictionary(
                x => CreateImageIdentifier(x.name), x => GetImageModelFromUnityTexture2D(x));
        }

        private static Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>
            GetTextureModelsForMaterials(List<Tuple<UnityEngine.Material, HashSet<string>>> materialsTextureNamesInfo)
        {
            var resultList = new List<Dictionary<string,
                AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>>();
            foreach (var materialTextureNamesInfo in materialsTextureNamesInfo)
            {
                resultList.Add(GetMaterialTexturesObjsFor(materialTextureNamesInfo.Item1, materialTextureNamesInfo.Item2));
            }
            return TexturesModelsUnifier.Unify(resultList);
        }

        private static Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>
            GetMaterialTexturesObjsFor(UnityEngine.Material unityMaterial, HashSet<string> materialTextureNames)
        {
            return IterateTextures2DOfMaterial(unityMaterial, materialTextureNames).ToDictionary(
                x => x.name, x => GetTextureModelFromUnityTexture2D(x));
        }

        private static AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture
            GetTextureModelFromUnityTexture2D(Texture2D unityTexture2D)
        {
            throw new NotImplementedException();
        }

        private static Image GetImageModelFromUnityTexture2D(Texture2D unityTexture2D)
        {
            throw new NotImplementedException();
        }

        private static 
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material
            GetMaterialModel(UnityEngine.Material unityMaterial, HashSet<string> materialTextureNames)
        {
            var materialModel = new AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material();
            materialModel.name = unityMaterial.name;
            materialModel.textures = new HashSet<string>(materialTextureNames.Select(x => x));
            return materialModel;
        }

        private static IEnumerable<Texture2D> IterateTextures2DOfMaterial(
            UnityEngine.Material unityMaterial, HashSet<string> materialTextureNames)
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
