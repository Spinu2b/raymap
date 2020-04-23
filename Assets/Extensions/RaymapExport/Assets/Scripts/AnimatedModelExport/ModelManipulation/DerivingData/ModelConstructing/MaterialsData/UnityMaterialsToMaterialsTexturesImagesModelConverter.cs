using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class UnityMaterialsToVisualDataConverter
    {
        public static VisualData Convert(List<Tuple<UnityEngine.Material, List<string>>> materialsTextureNamesInfo)
        {
            var resultList = new List<VisualData>();
            foreach (var unityMaterialInfo in materialsTextureNamesInfo)
            {
                var unityMaterial = unityMaterialInfo.Item1;
                var materialTextureNames = unityMaterialInfo.Item2;
                var materialModeled = UnityMaterialToMaterialVisualDataConverter.Convert(unityMaterial, materialTextureNames);
                resultList.Add(materialModeled);
            }
            return VisualDataUnifier.Unify(resultList);
        }
    }
}
