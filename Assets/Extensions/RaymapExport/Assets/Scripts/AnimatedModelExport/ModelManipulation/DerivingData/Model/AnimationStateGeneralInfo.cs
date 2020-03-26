using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
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
        private PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper;
        private int stateIndex;

        private AnimationClipModel animationClipModel;
        private Dictionary<string, SubmeshObjectModel> submeshesDescriptionSet;
        private ArmatureHierarchyModel armatureHierarchyParentingInfo;

        public AnimationStateGeneralInfo(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper, int stateIndex)
        {
            this.persoBehaviourAnimationStatesHelper = persoBehaviourAnimationStatesHelper;
            this.stateIndex = stateIndex;
        }

        public void BuildData()
        {
            throw new NotImplementedException();
        }

        public AnimationClipModel GetAnimationClipObj()
        {
            return animationClipModel;
        }

        public Dictionary<string, SubmeshObjectModel> GetSubmeshesDescriptionSet()
        {
            return submeshesDescriptionSet;
        }

        public ArmatureHierarchyModel GetArmatureHierarchyParentingInfo()
        {
            return armatureHierarchyParentingInfo;
        }
    }
}
