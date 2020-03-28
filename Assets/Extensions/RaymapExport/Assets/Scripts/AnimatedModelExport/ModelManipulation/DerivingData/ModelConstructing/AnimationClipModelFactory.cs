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
            result.type = GetAnimationClipType(persoBehaviourAnimationStatesHelper);
            result.channelKeyframes = GetChannelKeyframesData(persoBehaviourAnimationStatesHelper);
            result.submeshesExistenceData = GetSubmeshExistenceData(persoBehaviourAnimationStatesHelper);
            result.morphs = GetMorphsData(persoBehaviourAnimationStatesHelper);
            return result;
        }

        private Dictionary<string, List<SubmeshUsedMorphAssociationInfo>> GetMorphsData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, List<SubmeshUsedAssociationInfo>> GetSubmeshExistenceData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var submeshUsedAssociationInfosBuilder = new SubmeshUsedAssociationInfosBuilder();
            foreach (Tuple<int, List<string>> submeshExistenceIndicatorsForFrame in 
                persoBehaviourAnimationStatesHelper.IterateSubmeshExistenceDataForThisAnimationState())
            {
                int currentFrame = submeshExistenceIndicatorsForFrame.Item1;
                foreach (var submeshName in submeshExistenceIndicatorsForFrame.Item2)
                {
                    submeshUsedAssociationInfosBuilder.ConsiderAssociation(submeshName: submeshName, frameNumber: currentFrame);
                }
            }
            return submeshUsedAssociationInfosBuilder.Build();
        }

        private Dictionary<string, Dictionary<int, ChannelTransformModel>> GetChannelKeyframesData(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var result = new Dictionary<string, Dictionary<int, ChannelTransformModel>>();
            foreach (Tuple<int, Dictionary<string, ChannelTransformModel>> channelKeyframesForFrame in
                persoBehaviourAnimationStatesHelper.IterateKeyframeDataForThisAnimationState()) {
                int currentFrame = channelKeyframesForFrame.Item1;
                foreach (var channelKeyframe in channelKeyframesForFrame.Item2)
                {
                    var channelName = channelKeyframe.Key;
                    if (!result.ContainsKey(channelName))
                    {
                        result[channelName] = new Dictionary<int, ChannelTransformModel>();
                    }
                    result[channelName][currentFrame] = channelKeyframe.Value;
                }
            }
            return result;
        }

        private AnimationClipType GetAnimationClipType(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            throw new NotImplementedException();
        }
    }
}
