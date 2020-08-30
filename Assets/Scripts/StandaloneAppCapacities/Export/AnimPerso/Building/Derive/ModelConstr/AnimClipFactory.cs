using Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.ModelConstr.AnimFrameAssoc;
using Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Perso;
using Assets.Scripts.Unity.Export.AnimPerso.Model;
using Assets.Scripts.Unity.Export.AnimPerso.Model.AnimClipsDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.ModelConstr
{
    public class AnimationClipFactory
    {
        public AnimationClip DeriveFor(PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            var result = new AnimationClip();
            result.channelKeyframes = GetChannelKeyframesData(persoAccessorAnimationStatesHelper);
            result.channelsForSubobjectsAssociationsData = GetChannelsForSubobjectsAssociationsData(persoAccessorAnimationStatesHelper);
            result.animationHierarchies = GetAnimationHierarchiesData(persoAccessorAnimationStatesHelper);
            result.morphs = GetMorphsData(persoAccessorAnimationStatesHelper);
            result.id = persoAccessorAnimationStatesHelper.GetCurrentPersoStateIndex();
            return result;
        }

        private List<SubobjectUsedMorphAssociationInfo> GetMorphsData(PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            return persoAccessorAnimationStatesHelper.GetMorphDataForThisAnimationState();
        }

        private Dictionary<string, List<AnimationFramesPeriodInfo>> GetChannelsForSubobjectsAssociationsData(
            PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            var channelsSubobjectsInfosInAnimationFramesBuilder = new ChannelsSubobjectsAssociationInfosInAnimationFrameBuilder();
            foreach (Tuple<int, SubobjectsChannelsAssociation> subobjectExistenceIndicatorsForFrame in
                persoAccessorAnimationStatesHelper.IterateChannelSubobjectsAssociationsDataForThisAnimationState())
            {
                int currentFrame = subobjectExistenceIndicatorsForFrame.Item1;
                var subobjectsChannelsAssociation = subobjectExistenceIndicatorsForFrame.Item2;
                channelsSubobjectsInfosInAnimationFramesBuilder.ConsiderAssociation(data: subobjectsChannelsAssociation, frameNumber: currentFrame);
            }
            return channelsSubobjectsInfosInAnimationFramesBuilder.Build();
        }

        private Dictionary<string, List<AnimationFramesPeriodInfo>> GetAnimationHierarchiesData(PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            var channelHierarchiesUsedAssociationInfosBuilder = new ChannelHierarchiesUsedAssociationInfosBuilder();
            foreach (Tuple<int, Dictionary<int, int>> channelsParentingForFrameInfo in 
                persoAccessorAnimationStatesHelper.IterateChannelParentingInfosForThisAnimationState())
            {
                int currentFrame = channelsParentingForFrameInfo.Item1;
                channelHierarchiesUsedAssociationInfosBuilder.ConsiderAssociation(
                    data: channelsParentingForFrameInfo.Item2, frameNumber: currentFrame);
            }

            return channelHierarchiesUsedAssociationInfosBuilder.Build();
        }

        private Dictionary<int, Dictionary<int, ChannelTransform>> GetChannelKeyframesData(PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            var result = new Dictionary<int, Dictionary<int, ChannelTransform>>();
            foreach (Tuple<int, Dictionary<int, ChannelTransform>> channelKeyframesForFrame in
                persoAccessorAnimationStatesHelper.IterateKeyframeDataForThisAnimationState())
            {
                int currentFrame = channelKeyframesForFrame.Item1;
                foreach (var channelKeyframe in channelKeyframesForFrame.Item2)
                {
                    var channelId = channelKeyframe.Key;
                    if (!result.ContainsKey(channelId))
                    {
                        result[channelId] = new Dictionary<int, ChannelTransform>();
                    }
                    result[channelId][currentFrame] = channelKeyframe.Value;
                }
            }
            return result;
        }
    }
}
