using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
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
            result.subobjectsExistenceData = GetSubobjectExistenceData(persoBehaviourAnimationStatesHelper);
            result.morphs = GetMorphsData(persoBehaviourAnimationStatesHelper);
            result.id = persoBehaviourAnimationStatesHelper.GetCurrentPersoStateIndex();
            return result;
        }

        private List<SubobjectUsedMorphAssociationInfo> GetMorphsData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            return persoBehaviourAnimationStatesHelper.GetMorphDataForThisAnimationState();
        }

        private Dictionary<int, List<SubobjectUsedAssociationInfo>> GetSubobjectExistenceData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var subobjectUsedAssociationInfosBuilder = new SubobjectUsedAssociationInfosBuilder();
            foreach (Tuple<int, List<int>> subobjectExistenceIndicatorsForFrame in 
                persoBehaviourAnimationStatesHelper.IterateSubobjectExistenceDataForThisAnimationState())
            {
                int currentFrame = subobjectExistenceIndicatorsForFrame.Item1;
                foreach (var subobjectNumber in subobjectExistenceIndicatorsForFrame.Item2)
                {
                    subobjectUsedAssociationInfosBuilder.ConsiderAssociation(subobjectNumber: subobjectNumber, frameNumber: currentFrame);
                }
            }
            return subobjectUsedAssociationInfosBuilder.Build();
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
