using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.ChannelHierarchiesDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.AnimFrameAssoc
{
    public class ChannelHierarchiesUsedAssociationInfosBuilder :
        AnimationFramesDataUsedAssociationInfosBuilder<Dictionary<int, int>, string>
    {
        protected override string GetKey(Dictionary<int, int> channelsParenting)
        {
            ChannelHierarchy channelHierarchy = ChannelHierarchy.FromChannelsParenting(channelsParenting);
            return channelHierarchy.channelHierarchyDescriptionIdentifier;
        }
    }
}
