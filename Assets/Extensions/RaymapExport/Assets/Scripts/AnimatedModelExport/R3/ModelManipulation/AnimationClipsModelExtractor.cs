using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation
{
    public class AnimationClipsModelExtractor
    {
        public AnimationClipsModel DeriveFor(GameObject persoR3GameObject)
        {
            var persoAnimationStatesDataManipulator = new PersoAnimationStatesDataManipulator();

            var result = new AnimationClipsModel();
            foreach (var animationClip in persoAnimationStatesDataManipulator.IterateAnimationClips(persoR3GameObject))
            {
                result.animationClips.Add(animationClip.name, animationClip);
                foreach (var animationKeyframe in animationClip.IterateKeyframes())
                {
                    result.animationClips[animationClip.name].keyframes.Add(animationKeyframe.index, animationKeyframe);
                }
            }
            return result;
        }
    }
}
