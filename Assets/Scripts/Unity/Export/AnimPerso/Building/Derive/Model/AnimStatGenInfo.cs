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
        private ConsolidatedChannelHierarchiesBuilder channelHierarchiesInfo;

        private SubobjectsChannelsAssociations subobjectsChannelsAssociations;
    }
}
