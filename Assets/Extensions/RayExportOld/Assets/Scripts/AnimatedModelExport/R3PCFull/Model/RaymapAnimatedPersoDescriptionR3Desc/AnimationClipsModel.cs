using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc
{
    public class AnimationClipsModel
    {
        public Dictionary<string, AnimationClipModel> animationClips = new Dictionary<string, AnimationClipModel>();

        public IEnumerable<AnimationClipModel> IterateAnimationClips()
        {
            foreach (var animationClipInfo in animationClips)
            {
                yield return animationClipInfo.Value;
            }
        }
    }
}
