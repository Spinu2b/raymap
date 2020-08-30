using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc
{
    public class AnimationClip
    {
        public int id;
        public Dictionary<int, Dictionary<int, ChannelTransform>> channelKeyframes = new Dictionary<int, Dictionary<int, ChannelTransform>>();
        public Dictionary<string, List<AnimationFramesPeriodInfo>> channelsForSubobjectsAssociationsData = new Dictionary<string, List<AnimationFramesPeriodInfo>>();
        public Dictionary<string, List<AnimationFramesPeriodInfo>> animationHierarchies = new Dictionary<string, List<AnimationFramesPeriodInfo>>();
        public List<SubobjectUsedMorphAssociationInfo> morphs = new List<SubobjectUsedMorphAssociationInfo>();
    }
}
