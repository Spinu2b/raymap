using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation
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
            }
            return result;
        }
    }
}
