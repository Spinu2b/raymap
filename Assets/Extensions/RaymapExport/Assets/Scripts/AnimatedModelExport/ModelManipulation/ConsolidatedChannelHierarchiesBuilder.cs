using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation
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
            //throw new NotImplementedException();
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(
                result.armatureHierarchies, channelHierarchies.armatureHierarchies);
            //result.channels = new HashSet<int>(result.channels.Concat(armatureHierarchy.channels));
        }
    }
}
