﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
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
        public Tuple<AnimationClipsModel, SubobjectsLibraryModel, ChannelHierarchies, Dictionary<string, SubobjectsChannelsAssociation>>
            DeriveFor(GameObject persoGameObject)
        {
            var persoAnimationStatesDataManipulator = new PersoAnimationStatesGeneralDataManipulator();

            var consolidatedChannelHierarchiesBuilder = new ConsolidatedChannelHierarchiesBuilder();
            var animationClipsModel = new AnimationClipsModel();

            var subobjectsLibrary = persoAnimationStatesDataManipulator.GetSubobjectsLibrary(persoGameObject);
            var subobjectsChannelsAssociationsInfoBuilder = new SubobjectsChannelsAssociationsInfoBuilder();

            foreach (var animationStateGeneralInfo in persoAnimationStatesDataManipulator.IterateAnimationStatesGeneralDataForExport(persoGameObject))
            {
                animationClipsModel.animationClips.Add(animationStateGeneralInfo.animationClipId, animationStateGeneralInfo.GetAnimationClipObj());
                consolidatedChannelHierarchiesBuilder.Consolidate(animationStateGeneralInfo.GetChannelHierarchiesInfo());
                subobjectsChannelsAssociationsInfoBuilder.Consolidate(animationStateGeneralInfo.GetSubobjectsChannelsAssociationsInfo());
            }
            return new Tuple<AnimationClipsModel, SubobjectsLibraryModel, ChannelHierarchies, Dictionary<string, SubobjectsChannelsAssociation>>(
                animationClipsModel, subobjectsLibrary, consolidatedChannelHierarchiesBuilder.Build(), subobjectsChannelsAssociationsInfoBuilder.Build());
        }
    }
}
