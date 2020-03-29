﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc
{
    public class SubobjectUsedAssociationInfo
    {
        public int frameBegin;
        public int frameEnd;
    }

    public class SubobjectUsedMorphAssociationInfo
    {
        public string morphSubobjectStart;
        public string morphSubobjectEnd;
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
        public string name;
        public Dictionary<string, Dictionary<int, ChannelTransformModel>> channelKeyframes;
        public Dictionary<string, List<SubobjectUsedAssociationInfo>> subobjectsExistenceData;
        public Dictionary<string, List<SubobjectUsedMorphAssociationInfo>> morphs;
    }
}
