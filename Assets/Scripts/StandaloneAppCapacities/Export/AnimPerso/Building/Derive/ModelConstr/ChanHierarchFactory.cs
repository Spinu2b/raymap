using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.ChannelHierarchiesDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr
{
    public class ChannelHierarchiesFactory
    {
        public ChannelHierarchies DeriveFor(PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            var consolidatedChannelHierarchiesBuilder = new ConsolidatedChannelHierarchiesBuilder();
            foreach (Tuple<int, Dictionary<int, int>> channelParentingInfoForFrame in 
                persoAccessorAnimationStatesHelper.IterateChannelParentingInfosForThisAnimationState())
            {
                consolidatedChannelHierarchiesBuilder.Consolidate(GetChannelHierarchiesModelForParenting(channelParentingInfoForFrame.Item2));
            }
            return consolidatedChannelHierarchiesBuilder.Build();
        }

        private ChannelHierarchies GetChannelHierarchiesModelForParenting(Dictionary<int, int> channelsParenting)
        {
            var channelHierarchy = ChannelHierarchy.FromChannelsParenting(channelsParenting);
            var result = new ChannelHierarchies();
            result.channelHierarchies.Add(channelHierarchy.channelHierarchyDescriptionIdentifier, channelHierarchy);
            return result;
        }
    }
}
