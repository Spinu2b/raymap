using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Model.ChannelHierarchiesDesc
{
    public class ChannelHierarchyDescription
    {
        public HashSet<int> channels = new HashSet<int>();
        public Dictionary<int, int> parenting = new Dictionary<int, int>();
    }

    public class ChannelHierarchy
    {
        public string channelHierarchyIdentifier;
        public ChannelHierarchyDescription channelHierarchy = new ChannelHierarchyDescription();

        public static ChannelHierarchy FromChannelsParenting(Dictionary<int, int> channelsParenting)
        {
            throw new NotImplementedException();
        }
    }
}
