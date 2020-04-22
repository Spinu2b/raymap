using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.ChannelHierarchiesDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class ChannelHierarchiesFactory
    {
        public ChannelHierarchies DeriveFor(PersoAccessorAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var consolidatedChannelHierarchiesBuilder = new ConsolidatedChannelHierarchiesBuilder();
            foreach (Tuple<int, Dictionary<int, int>> channelParentingInfoForFrame
                in persoBehaviourAnimationStatesHelper.IterateChannelParentingInfosThisAnimationState())
            {
                consolidatedChannelHierarchiesBuilder.Consolidate(GetChannelHierarchiesModelForParenting(channelParentingInfoForFrame.Item2));
            }
            return consolidatedChannelHierarchiesBuilder.Build();
        }

        private ChannelHierarchies GetChannelHierarchiesModelForParenting(Dictionary<int, int> channelsParenting)
        {
            var channelHierarchy = ChannelHierarchyModel.FromChannelsParenting(channelsParenting);

            var result = new ChannelHierarchies();
            result.channelHierarchies.Add(channelHierarchy.channelHierarchyDescriptionHash, channelHierarchy);
            return result;
        }
    }
}
