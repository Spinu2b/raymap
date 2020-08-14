using Assets.Scripts.Unity.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.Unity.Export.AnimPerso.Model.ChannelHierarchiesDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.ModelConstr.AnimFrameAssoc
{
    public class ChannelHierarchiesUsedAssociationInfosBuilder :
        AnimationFramesDataUsedAssociationInfosBuilder<Dictionary<int, int>, string>
    {
        protected override string GetKey(Dictionary<int, int> channelsParenting)
        {
            ChannelHierarchy channelHierarchy = ChannelHierarchy.FromChannelsParenting(channelsParenting);
            return channelHierarchy.channelHierarchyIdentifier;
        }
    }
}
