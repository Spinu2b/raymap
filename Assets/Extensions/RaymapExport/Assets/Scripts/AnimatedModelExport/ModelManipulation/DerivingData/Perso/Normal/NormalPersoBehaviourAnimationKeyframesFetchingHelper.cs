using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using OpenSpace.Animation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourAnimationKeyframesFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourAnimationKeyframesFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        public Dictionary<string, ChannelTransformModel> GetPersoBehaviourChannelsKeyframeDataForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetChannelsKeyframeDataForNormalAnimation(frameNumber);
            } else if (IsMontrealAnimation())
            {
                return GetChannelsKeyframeDataForMontrealAnimation(frameNumber);
            } else if (IsLargoAnimation())
            {
                return GetChannelsKeyframeDataForLargoAnimation(frameNumber);
            } else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private Dictionary<string, ChannelTransformModel> GetChannelsKeyframeDataForLargoAnimation(int frameNumber)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, ChannelTransformModel> GetChannelsKeyframeDataForMontrealAnimation(int frameNumber)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, ChannelTransformModel> GetChannelsKeyframeDataForNormalAnimation(int frameNumber)
        {
            Func<int, ChannelTransformModel> GetChannelAbsoluteTransform = (int channelIndex) =>
            {
                return ChannelTransformModel.FromUnityAbsoluteTransform(
                    persoBehaviour.channelObjects[channelIndex].transform);
            };

            var result = new Dictionary<string, ChannelTransformModel>();

            for (int i = 0; i < persoBehaviour.a3d.num_channels; i++)
            {
                AnimChannel ch = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i];
                AnimFramesKFIndex kfi = persoBehaviour.a3d.framesKFIndex[persoBehaviour.currentFrame + ch.framesKF];
                AnimKeyframe kf = persoBehaviour.a3d.keyframes[kfi.kf];
                int framesSinceKF = (int)persoBehaviour.currentFrame - (int)kf.frame;
                if (framesSinceKF == 0)
                {
                    result.Add(persoBehaviour.channelObjects[i].name, GetChannelAbsoluteTransform(i));
                }
            }
            return result;
        }
    }
}
