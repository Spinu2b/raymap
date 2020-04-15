﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class AnimationClipModelFactory
    {
        public AnimationClipModel DeriveFor(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var result = new AnimationClipModel();
            result.channelKeyframes = GetChannelKeyframesData(persoBehaviourAnimationStatesHelper);
            result.channelsForSubobjectsAssociationsData = GetChannelsForSubobjectsAssociationsData(persoBehaviourAnimationStatesHelper);
            result.animationHierarchies = GetAnimationHierarchiesData(persoBehaviourAnimationStatesHelper);
            result.morphs = GetMorphsData(persoBehaviourAnimationStatesHelper);
            result.id = persoBehaviourAnimationStatesHelper.GetCurrentPersoStateIndex();
            return result;
        }

        private List<SubobjectUsedMorphAssociationInfo> GetMorphsData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            return persoBehaviourAnimationStatesHelper.GetMorphDataForThisAnimationState();
        }

        private Dictionary<string, List<AnimationFramesPeriodInfo>> GetChannelsForSubobjectsAssociationsData(
            PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var channelsSubobjectsAssociationInfosBuilder = new ChannelsSubobjectsAssociationInfosBuilder();
            foreach (Tuple<int, SubobjectsChannelsAssociation> subobjectExistenceIndicatorsForFrame in 
                persoBehaviourAnimationStatesHelper.IterateChannelsSubobjectsAssociationsDataForThisAnimationState())
            {
                int currentFrame = subobjectExistenceIndicatorsForFrame.Item1;
                var subobjectsChannelsAssociation = subobjectExistenceIndicatorsForFrame.Item2;
                channelsSubobjectsAssociationInfosBuilder.ConsiderAssociation(data: subobjectsChannelsAssociation, frameNumber: currentFrame);
            }
            return channelsSubobjectsAssociationInfosBuilder.Build();
        }

        private Dictionary<string, List<AnimationFramesPeriodInfo>> GetAnimationHierarchiesData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var channelHierarchiesUsedAssociationInfosBuilder = new ChannelHierarchiesUsedAssociationInfosBuilder();
            foreach (Tuple<int, Dictionary<int, int>> channelsParentingForFrameInfo in 
                persoBehaviourAnimationStatesHelper.IterateChannelParentingInfosThisAnimationState())
            {
                int currentFrame = channelsParentingForFrameInfo.Item1;
                channelHierarchiesUsedAssociationInfosBuilder.ConsiderAssociation(
                    data: channelsParentingForFrameInfo.Item2, frameNumber: currentFrame);
            }

            return channelHierarchiesUsedAssociationInfosBuilder.Build();
        }

        private Dictionary<int, Dictionary<int, ChannelTransformModel>> GetChannelKeyframesData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var result = new Dictionary<int, Dictionary<int, ChannelTransformModel>>();
            foreach (Tuple<int, Dictionary<int, ChannelTransformModel>> channelKeyframesForFrame in
                persoBehaviourAnimationStatesHelper.IterateKeyframeDataForThisAnimationState()) {
                int currentFrame = channelKeyframesForFrame.Item1;
                foreach (var channelKeyframe in channelKeyframesForFrame.Item2)
                {
                    var channelId = channelKeyframe.Key;
                    if (!result.ContainsKey(channelId))
                    {
                        result[channelId] = new Dictionary<int, ChannelTransformModel>();
                    }
                    result[channelId][currentFrame] = channelKeyframe.Value;
                }
            }
            return result;
        }
    }
}