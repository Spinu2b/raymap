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
        public Tuple<AnimationClipsModel, SubobjectsLibraryModel, ChannelHierarchies> DeriveFor(GameObject persoGameObject)
        {
            var persoAnimationStatesDataManipulator = new PersoAnimationStatesGeneralDataManipulator();

            var consolidatedChannelHierarchiesBuilder = new ConsolidatedChannelHierarchiesBuilder();
            var submeshesLibraryBuilder = new SubobjectsLibraryBuilder();

            var animationClipsModel = new AnimationClipsModel();

            foreach (var animationStateGeneralInfo in persoAnimationStatesDataManipulator.IterateAnimationStatesGeneralDataForExport(persoGameObject))
            {
                animationClipsModel.animationClips.Add(animationStateGeneralInfo.animationClipId, animationStateGeneralInfo.GetAnimationClipObj());
                submeshesLibraryBuilder.Consolidate(
                    subobjects: animationStateGeneralInfo.GetSubmeshesDescriptionSet(),
                    visualData: animationStateGeneralInfo.GetVisualData());
                consolidatedChannelHierarchiesBuilder.Consolidate(animationStateGeneralInfo.GetChannelHierarchiesInfo()); 
            }
            return new Tuple<AnimationClipsModel, SubobjectsLibraryModel, ChannelHierarchies>(
                animationClipsModel, submeshesLibraryBuilder.Build(), consolidatedChannelHierarchiesBuilder.Build());
        }
    }
}
