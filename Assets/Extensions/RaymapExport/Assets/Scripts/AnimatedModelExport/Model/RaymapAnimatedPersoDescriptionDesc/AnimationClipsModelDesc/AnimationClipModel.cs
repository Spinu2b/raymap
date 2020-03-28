using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc
{
    public enum AnimationClipType
    {
        SKINNED_ANIMATION_CLIP,
        MORPH_ANIMATION_CLIP
    }

    public class SubmeshUsedAssociationInfo
    {
        public int frameBegin;
        public int frameEnd;
    }

    public class SubmeshUsedMorphAssociationInfo
    {
        public string morphSubmeshStart;
        public string morphSubmeshEnd;
        public Dictionary<int, float> morphProgressKeyframes;
    }

    public struct ChannelTransformModel
    {
        public Vector3d position;
        public MathDescription.Quaternion rotation;
        public Vector3d scale;

        public static ChannelTransformModel FromUnityAbsoluteTransform(Transform transform)
        {
            throw new NotImplementedException();
        }
    }

    public class AnimationClipModel
    {
        public AnimationClipType type;
        public string name;
        public Dictionary<string, Dictionary<int, ChannelTransformModel>> channelKeyframes;
        public Dictionary<string, List<SubmeshUsedAssociationInfo>> submeshesExistenceData;
        public Dictionary<string, List<SubmeshUsedMorphAssociationInfo>> morphs;
    }
}
