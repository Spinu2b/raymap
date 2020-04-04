using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class MaterialsTexturesImagesFactory
    {
        public Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>
            DeriveFor(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var resultList = new List<Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>>();

            foreach (var materialsTexturesImagesInFrameInfo in persoBehaviourAnimationStatesHelper.IterateMaterialsTexturesImagesDataForThisAnimationState())
            {
                resultList.Add(materialsTexturesImagesInFrameInfo.Item2);
            }
            return MaterialsTexturesImagesModelUnifier.Unify(resultList);
        }
    }
}
