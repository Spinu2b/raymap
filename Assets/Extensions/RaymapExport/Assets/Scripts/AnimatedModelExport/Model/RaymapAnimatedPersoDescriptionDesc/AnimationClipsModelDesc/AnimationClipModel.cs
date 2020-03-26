﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class ChannelTransformModel
    {
        public Vector3d position;
        public Quaternion rotation;
        public Vector3d scale;
    }

    public class AnimationClipModel
    {
        public AnimationClipType type;
        public string name;
        public Dictionary<string, Dictionary<int, ChannelTransformModel>> channelKeyframes;
        public Dictionary<string, List<SubmeshUsedAssociationInfo>> submeshesExistenceData;
    }

    public class MorphAnimationClipModel : AnimationClipModel
    {
        public Dictionary<string, List<SubmeshUsedMorphAssociationInfo>> morphs;
    }
}
