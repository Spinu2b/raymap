using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class UnityMaterialsToMaterialsTexturesImagesModelConverter
    {
        public static Tuple<Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material>,
            Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>,
            Dictionary<string, Image>> Convert(List<Tuple<UnityEngine.Material, List<string>>> materialsTextureNamesInfo)
        {
            var materialsTexturesImagesModelBuilder = new MaterialsTexturesImagesModelBuilder();
            foreach (var unityMaterialInfo in materialsTextureNamesInfo)
            {
                var unityMaterial = unityMaterialInfo.Item1;
                var materialTextureNames = unityMaterialInfo.Item2;
                var materialModeled =
                    UnityMaterialToMaterialModelConverter.Convert(unityMaterial, materialTextureNames);
                materialsTexturesImagesModelBuilder.Consider(materialModeled);
            }
            return materialsTexturesImagesModelBuilder.Build();
        }
    }
}
