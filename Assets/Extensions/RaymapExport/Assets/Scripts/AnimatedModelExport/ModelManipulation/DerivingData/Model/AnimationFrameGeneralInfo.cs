using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc.AnimationClipModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model
{
    public class AnimationFrameGeneralInfo
    {
        public AnimationFrameModel GetAnimationFrameObj()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, SubmeshObjectModel> GetSubmeshesDescriptionSetForThisFrame()
        {
            throw new NotImplementedException();
        }

        public ArmatureHierarchyModel GetArmatureHierarchyParentingInfoForThisFrame()
        {
            throw new NotImplementedException();
        }
    }
}
