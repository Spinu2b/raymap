using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
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
        public int animationClipId;
        private PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper;

        private AnimationClipModel animationClipModel;
        private Dictionary<int, SubobjectModel> submeshesDescriptionSet;
        private ChannelHierarchies channelHierarchiesInfo;

        private VisualData visualData;

        public AnimationStateGeneralInfo(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            this.persoBehaviourAnimationStatesHelper = persoBehaviourAnimationStatesHelper;
        }

        public void BuildData()
        {
            animationClipModel = new AnimationClipModelFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            animationClipId = animationClipModel.id;

            submeshesDescriptionSet = new SubmeshesDescriptionSetFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            channelHierarchiesInfo = new ChannelHierarchiesFactory().DeriveFor(persoBehaviourAnimationStatesHelper);

            visualData = new VisualDataFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
        }

        public VisualData GetVisualData()
        {
            return visualData;
        }

        public AnimationClipModel GetAnimationClipObj()
        {
            return animationClipModel;
        }

        public Dictionary<int, SubobjectModel> GetSubmeshesDescriptionSet()
        {
            return submeshesDescriptionSet;
        }

        public ChannelHierarchies GetChannelHierarchiesInfo()
        {
            return channelHierarchiesInfo;
        }
    }
}
