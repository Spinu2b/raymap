using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
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

        private AnimationClipModel animationClipModel;
        private Dictionary<string, SubmeshObjectModel> submeshesDescriptionSet;
        private ArmatureHierarchyModel armatureHierarchyParentingInfo;

        public AnimationStateGeneralInfo(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            this.persoBehaviourAnimationStatesHelper = persoBehaviourAnimationStatesHelper;
        }

        public void BuildData()
        {
            animationClipModel = new AnimationClipModelFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            animationClipName = animationClipModel.name;
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
