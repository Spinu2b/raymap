using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations
{
    public class SubobjectUsedAssociationInfosBuilder : AnimationFramesDataUsedAssociationInfosBuilder<int, int>
    {
        protected override int GetKey(int subobjectNumber)
        {
            return subobjectNumber;
        }
    }
}
