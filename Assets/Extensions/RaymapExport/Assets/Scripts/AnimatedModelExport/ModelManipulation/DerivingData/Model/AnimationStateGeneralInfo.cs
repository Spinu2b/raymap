using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc;
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

        public Dictionary<string, SubmeshObjectModel> GetSubmeshesDescriptionSet()
        {
            throw new NotImplementedException();
        }

        public ArmatureHierarchyModel GetArmatureHierarchyParentingInfo()
        {
            throw new NotImplementedException();
        }
    }
}
