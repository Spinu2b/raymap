using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building
{
    public class ConsolidatedChannelHierarchiesBuilder
    {
        ChannelHierarchies result = new ChannelHierarchies();

        public ChannelHierarchies Build()
        {
            return result;
        }

        public void Consolidate(ChannelHierarchies channelHierarchies)
        {
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(
                result.channelHierarchies, channelHierarchies.channelHierarchies);
        }
    }
}
