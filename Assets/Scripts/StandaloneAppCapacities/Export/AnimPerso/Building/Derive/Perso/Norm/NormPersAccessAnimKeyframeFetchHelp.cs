using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal;
using OpenSpace.Animation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm
{
    public class NormalPersoAccessorAnimationKeyframesFetchingHelper : NormalPersoAccessorAnimationDataFetchingHelper
    {
        public NormalPersoAccessorAnimationKeyframesFetchingHelper(NormalPersoAccessor normalPersoAccessor) : base(normalPersoAccessor)
        {
        }

        public Dictionary<int, ChannelTransform> GetPersoBehaviourChannelsKeyframeDataForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetChannelsKeyframeDataForNormalAnimation();
            }
            else if (IsMontrealAnimation())
            {
                return GetChannelsKeyframeDataForMontrealAnimation();
            }
            else if (IsLargoAnimation())
            {
                return GetChannelsKeyframeDataForLargoAnimation();
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private Dictionary<int, ChannelTransform> GetChannelsKeyframeDataForLargoAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, ChannelTransform> GetChannelsKeyframeDataForMontrealAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, ChannelTransform> GetChannelsKeyframeDataForNormalAnimation()
        {
            Func<int, ChannelTransform> GetChannelAbsoluteTransform = (int channelIndex) =>
            {
                throw new NotImplementedException();
                //return ChannelTransformModel.FromUnityAbsoluteTransform(
                //    normalPersoAccessor.channelObjects[channelIndex].transform);
            };

            var result = new Dictionary<int, ChannelTransform>();

            for (int i = 0; i < normalPersoAccessor.a3d.num_channels; i++)
            {
                AnimChannel ch = normalPersoAccessor.a3d.channels[normalPersoAccessor.a3d.start_channels + i];
                AnimFramesKFIndex kfi = normalPersoAccessor.a3d.framesKFIndex[normalPersoAccessor.currentFrame + ch.framesKF];
                AnimKeyframe kf = normalPersoAccessor.a3d.keyframes[kfi.kf];
                int framesSinceKF = (int)normalPersoAccessor.currentFrame - (int)kf.frame;
                if (framesSinceKF == 0)
                {
                    result.Add(ch.id, GetChannelAbsoluteTransform(i));
                }
            }
            return result;
        }
    }
}
