using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model
{
    public class AnimationStateGeneralInfo
    {
        public string animationClipName;

        public AnimationClipModel GetAnimationClipObj()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnimationFrameGeneralInfo> IterateAnimationFramesGeneralDataForExport()
        {
            throw new NotImplementedException();
        }
    }
}
