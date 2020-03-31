using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation
{
    public class AnimationClipsGeneralDataExtractor
    {
        public Tuple<AnimationClipsModel, SubobjectsLibraryModel, ArmatureHierarchyModel> DeriveFor(GameObject persoGameObject)
        {
            var persoAnimationStatesDataManipulator = new PersoAnimationStatesGeneralDataManipulator();

            var consolidatedArmatureHierarchyBuilder = new ConsolidatedArmatureHierarchyBuilder();
            var submeshesLibraryBuilder = new SubobjectsLibraryBuilder();

            var animationClipsModel = new AnimationClipsModel();

            foreach (var animationStateGeneralInfo in persoAnimationStatesDataManipulator.IterateAnimationStatesGeneralDataForExport(persoGameObject))
            {
                animationClipsModel.animationClips.Add(animationStateGeneralInfo.animationClipId, animationStateGeneralInfo.GetAnimationClipObj());
                submeshesLibraryBuilder.Consolidate(
                    subobjects: animationStateGeneralInfo.GetSubmeshesDescriptionSet(),
                    materials: animationStateGeneralInfo.GetMaterials(),
                    textures: animationStateGeneralInfo.GetTextures(),
                    images: animationStateGeneralInfo.GetImages());
                consolidatedArmatureHierarchyBuilder.Consolidate(animationStateGeneralInfo.GetArmatureHierarchyParentingInfo());
            }
            return new Tuple<AnimationClipsModel, SubobjectsLibraryModel, ArmatureHierarchyModel>(
                animationClipsModel, submeshesLibraryBuilder.Build(), consolidatedArmatureHierarchyBuilder.Build());
        }
    }
}
