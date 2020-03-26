using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
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
        public Tuple<AnimationClipsModel, SubmeshesLibraryModel, ArmatureHierarchyModel> DeriveFor(GameObject persoGameObject)
        {
            var persoAnimationStatesDataManipulator = new PersoAnimationStatesGeneralDataManipulator();

            var consolidatedArmatureHierarchyBuilder = new ConsolidatedArmatureHierarchyBuilder();
            var submeshesLibraryBuilder = new SubmeshesLibraryBuilder();

            var animationClipsModel = new AnimationClipsModel();
            
            foreach (var animationStateGeneralInfo in persoAnimationStatesDataManipulator.IterateAnimationStatesGeneralDataForExport(persoGameObject))
            {
                animationClipsModel.animationClips.Add(animationStateGeneralInfo.animationClipName, animationStateGeneralInfo.GetAnimationClipObj());
                foreach (var animationFrameGeneralInfo in animationStateGeneralInfo.IterateAnimationFramesGeneralDataForExport())
                {
                    submeshesLibraryBuilder.Consolidate(animationFrameGeneralInfo.GetSubmeshesDescriptionSetForThisFrame());
                    consolidatedArmatureHierarchyBuilder.Consolidate(animationFrameGeneralInfo.GetArmatureHierarchyParentingInfoForThisFrame());
                }
            }
            return new Tuple<AnimationClipsModel, SubmeshesLibraryModel, ArmatureHierarchyModel>(
                animationClipsModel, submeshesLibraryBuilder.Build(), consolidatedArmatureHierarchyBuilder.Build());
        }
    }
}
