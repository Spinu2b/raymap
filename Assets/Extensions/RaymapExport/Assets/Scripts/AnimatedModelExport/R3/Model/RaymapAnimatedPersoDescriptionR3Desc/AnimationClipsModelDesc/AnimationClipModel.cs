﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc
{
    public class AnimationClipModel
    {
        public Dictionary<int, AnimationFrameModel> keyframes = new Dictionary<int, AnimationFrameModel>();
        public string name;

        public AnimationClipModel(string name)
        {
            this.name = name;
        }

        public IEnumerable<AnimationFrameModel> IterateKeyframes()
        {
            throw new NotImplementedException();
        }

        internal void AddKeyframe(int index, AnimationFrameModel animationFrame)
        {
            throw new NotImplementedException();
        }
    }
}
