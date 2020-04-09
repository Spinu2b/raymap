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
        public ChannelHierarchies DeriveFor(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
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
            var armatureHierarchy = ArmatureHierarchyModel.FromChannelsParenting(channelsParenting);

            var result = new ChannelHierarchies();
            result.armatureHierarchies.Add(armatureHierarchy.armatureHierarchyDescriptionHash, armatureHierarchy);
            return result;
        }
    }
}
