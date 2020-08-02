using Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Perso;
using Assets.Scripts.Unity.Export.AnimPerso.Model;
using Assets.Scripts.Unity.Export.AnimPerso.Model.AnimClipsDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model
{
    public class AnimationStateGeneralInfo
    {
        public int animationClipId;
        private PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper;

        private AnimationClip animationClipModel;
        private ChannelHierarchies channelHierarchiesInfo;

        private SubobjectsChannelsAssociations subobjectsChannelsAssociations;
        private PersoAccessorAnimationStatesHelper persoBehaviourAnimationStatesHelper;

        public AnimationStateGeneralInfo(PersoAccessorAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            this.persoBehaviourAnimationStatesHelper = persoBehaviourAnimationStatesHelper;
        }

        public AnimationClip GetAnimationClipObj()
        {
            return animationClipModel;
        }

        public ChannelHierarchies GetChannelHierarchiesInfo()
        {
            return channelHierarchiesInfo;
        }

        public void BuildData()
        {
            animationClipModel = new AnimationClipModelFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            animationClipId = animationClipModel.id;

            subobjectsChannelsAssociations = new SubobjectsChannelsAssociationsInfoFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            channelHierarchiesInfo = new ChannelHierarchiesFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
        }

        public SubobjectsChannelsAssociations GetSubobjectsChannelsAssociationsInfo()
        {
            return subobjectsChannelsAssociations;
        }
    }
}
