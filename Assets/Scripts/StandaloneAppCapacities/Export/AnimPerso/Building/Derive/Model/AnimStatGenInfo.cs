using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model
{
    public class AnimationStateGeneralInfo
    {
        public int animationClipId;
        private PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper;

        private AnimationClip animationClipModel;
        private ChannelHierarchies channelHierarchiesInfo;

        private SubobjectsChannelsAssociations subobjectsChannelsAssociations;

        public AnimationStateGeneralInfo(PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            this.persoAccessorAnimationStatesHelper = persoAccessorAnimationStatesHelper;
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
            animationClipModel = new AnimationClipFactory().DeriveFor(persoAccessorAnimationStatesHelper);
            animationClipId = animationClipModel.id;

            subobjectsChannelsAssociations = new SubobjectsChannelsAssociationsInfoFactory().DeriveFor(persoAccessorAnimationStatesHelper);
            channelHierarchiesInfo = new ChannelHierarchiesFactory().DeriveFor(persoAccessorAnimationStatesHelper);
        }

        public SubobjectsChannelsAssociations GetSubobjectsChannelsAssociationsInfo()
        {
            return subobjectsChannelsAssociations;
        }
    }
}
