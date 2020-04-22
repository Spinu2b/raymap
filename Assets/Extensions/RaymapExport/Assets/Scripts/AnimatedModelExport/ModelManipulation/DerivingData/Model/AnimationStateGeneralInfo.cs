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
        private PersoAccessorAnimationStatesHelper persoBehaviourAnimationStatesHelper;

        private AnimationClipModel animationClipModel;
        private ChannelHierarchies channelHierarchiesInfo;

        private Dictionary<string, SubobjectsChannelsAssociation> subobjectsChannelsAssociations;

        public AnimationStateGeneralInfo(PersoAccessorAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            this.persoBehaviourAnimationStatesHelper = persoBehaviourAnimationStatesHelper;
        }

        public void BuildData()
        {
            animationClipModel = new AnimationClipModelFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            animationClipId = animationClipModel.id;

            subobjectsChannelsAssociations = new SubobjectsChannelsAssociationsInfoFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            channelHierarchiesInfo = new ChannelHierarchiesFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
        }

        public Dictionary<string, SubobjectsChannelsAssociation> GetSubobjectsChannelsAssociationsInfo()
        {
            return subobjectsChannelsAssociations;
        }

        public AnimationClipModel GetAnimationClipObj()
        {
            return animationClipModel;
        }

        public ChannelHierarchies GetChannelHierarchiesInfo()
        {
            return channelHierarchiesInfo;
        }
    }
}
