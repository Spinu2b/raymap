using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal;
using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using OpenSpace.Animation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Quaternion = Assets.Scripts.StandaloneAppCapacities.Export.Math.Quaternion;

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
            Func<int, ChannelTransform> GetChannelTransform = (int channelIndex) =>
            {
                AnimChannel ch = normalPersoAccessor.a3d.channels[normalPersoAccessor.a3d.start_channels + channelIndex];
                AnimFramesKFIndex kfi = normalPersoAccessor.a3d.framesKFIndex[normalPersoAccessor.currentFrame + ch.framesKF];
                AnimKeyframe kf = normalPersoAccessor.a3d.keyframes[kfi.kf];

                AnimVector pos = normalPersoAccessor.a3d.vectors[kf.positionVector];
                AnimQuaternion qua = normalPersoAccessor.a3d.quaternions[kf.quaternion];
                AnimVector scl = normalPersoAccessor.a3d.vectors[kf.scaleVector];

                int framesSinceKF = (int)normalPersoAccessor.currentFrame - (int)kf.frame;
                AnimKeyframe nextKF = null;
                int framesDifference;
                float interpolation;
                if (kf.IsEndKeyframe)
                {
                    AnimFramesKFIndex next_kfi = normalPersoAccessor.a3d.framesKFIndex[0 + ch.framesKF];
                    nextKF = normalPersoAccessor.a3d.keyframes[next_kfi.kf];
                    framesDifference = normalPersoAccessor.a3d.num_onlyFrames - 1 + (int)nextKF.frame - (int)kf.frame;
                    if (framesDifference == 0)
                    {
                        interpolation = 0;
                    }
                    else
                    {
                        //interpolation = (float)(nextKF.interpolationFactor * (framesSinceKF / (float)framesDifference) + 1.0 * nextKF.interpolationFactor);
                        interpolation = framesSinceKF / (float)framesDifference;
                    }
                } else
                {
                    nextKF = normalPersoAccessor.a3d.keyframes[kfi.kf + 1];
                    framesDifference = (int)nextKF.frame - (int)kf.frame;
                    //interpolation = (float)(nextKF.interpolationFactor * (framesSinceKF / (float)framesDifference) + 1.0 * nextKF.interpolationFactor);
                    interpolation = framesSinceKF / (float)framesDifference;
                }

                AnimVector pos2 = normalPersoAccessor.a3d.vectors[nextKF.positionVector];
                AnimQuaternion qua2 = normalPersoAccessor.a3d.quaternions[nextKF.quaternion];
                AnimVector scl2 = normalPersoAccessor.a3d.vectors[nextKF.scaleVector];

                Vector3 vector = Vector3.Lerp(pos.vector, pos2.vector, interpolation);
                UnityEngine.Quaternion quaternion = UnityEngine.Quaternion.Lerp(qua.quaternion, qua2.quaternion, interpolation);
                Vector3 scale = Vector3.Lerp(scl.vector, scl2.vector, interpolation);
                float positionMultiplier = Mathf.Lerp(kf.positionMultiplier, nextKF.positionMultiplier, interpolation);

                //we will store channel transform in direct form from the OpenSpace and take care of transformations later down the line
                // in blender when considering parenting chain in bones, no worries here as we keep being consistent with that approach
                // these bad boys here are local transforms - that being position, rotation and scale, so keep that in mind
                var channelTransformResult = new ChannelTransform();
                channelTransformResult.position = Vector3d.FromUnityVector3(vector * positionMultiplier);
                channelTransformResult.rotation = Quaternion.FromUnityQuaternion(quaternion);
                channelTransformResult.scale = Vector3d.FromUnityVector3(scale);
                return channelTransformResult;
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
                    result.Add(ch.id, GetChannelTransform(i));
                }
            }
            return result;
        }
    }
}
