using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.ChannelHierarchiesDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations
{
    public class ChannelHierarchiesUsedAssociationInfosBuilder : AnimationFramesDataUsedAssociationInfosBuilder<Dictionary<int, int>, string>
    {
        protected override string GetKey(Dictionary<int, int> channelsParenting)
        {
            ChannelHierarchyModel channelHierarchy = ChannelHierarchyModel.FromChannelsParenting(channelsParenting);
            return channelHierarchy.channelHierarchyDescriptionHash;
        }
    }
}
