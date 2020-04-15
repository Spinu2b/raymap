using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Animation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourAnimationKeyframesFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourAnimationKeyframesFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        public Dictionary<int, ChannelTransformModel> GetPersoBehaviourChannelsKeyframeDataForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetChannelsKeyframeDataForNormalAnimation();
            } else if (IsMontrealAnimation())
            {
                return GetChannelsKeyframeDataForMontrealAnimation();
            } else if (IsLargoAnimation())
            {
                return GetChannelsKeyframeDataForLargoAnimation();
            } else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForLargoAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForMontrealAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForNormalAnimation()
        {
            Func<int, ChannelTransformModel> GetChannelAbsoluteTransform = (int channelIndex) =>
            {
                return ChannelTransformModel.FromUnityAbsoluteTransform(
                    persoBehaviour.channelObjects[channelIndex].transform);
            };

            var result = new Dictionary<int, ChannelTransformModel>();

            for (int i = 0; i < persoBehaviour.a3d.num_channels; i++)
            {
                AnimChannel ch = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i];
                AnimFramesKFIndex kfi = persoBehaviour.a3d.framesKFIndex[persoBehaviour.currentFrame + ch.framesKF];
                AnimKeyframe kf = persoBehaviour.a3d.keyframes[kfi.kf];
                int framesSinceKF = (int)persoBehaviour.currentFrame - (int)kf.frame;
                if (framesSinceKF == 0)
                {
                    result.Add(GetChannelId(persoBehaviour.channelObjects[i].name), GetChannelAbsoluteTransform(i));
                }
            }
            return result;
        }

        private int GetChannelId(string channelName)
        {
            return ChannelHelper.GetChannelId(channelName);
        }
    }
}
