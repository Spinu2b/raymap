using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using Assets.Scripts.Util;
using Assets.Scripts.Util.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.ChannelHierarchiesDesc
{
    public static class ChannelHierarchyConstructionHelper
    {
        public static HashSet<int> GetChannelsHashsetFromParentingDict(Dictionary<int, int> channelsParenting)
        {
            var result = new HashSet<int>();
            foreach (var entry in channelsParenting)
            {
                result.Add(entry.Key);
                result.Add(entry.Value);
            }
            return result;
        }
    }

    public class ChannelHierarchyDescription : ISerializableToBytes, IIdentifiableComputationally 
    {
        public HashSet<int> channels = new HashSet<int>();
        public Dictionary<int, int> parenting = new Dictionary<int, int>();

        public string ComputeIdentifier()
        {
            var bytes = SerializeToBytes();
            return BytesHashHelper.GetHashHexStringFor(bytes);
        }

        public byte[] SerializeToBytes()
        {
            var channelsBytes = ComparableElementHashsetToBytesSerializer.WithCSharpComparableElementSerializeToBytes(
                hashSet: channels,
                elementSerializer: BytesHelper.SerializeFunctions.IntSerializerFunction
                );

            var parentingBytes = ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                dict: parenting,
                keySerializer: BytesHelper.SerializeFunctions.IntSerializerFunction,
                valueSerializer: BytesHelper.SerializeFunctions.IntSerializerFunction
                );

            return channelsBytes.Concat(parentingBytes).ToArray();
        }
    }

    public class ChannelHierarchy : IComparableModel<ChannelHierarchy>
    {
        public string channelHierarchyDescriptionIdentifier;
        public ChannelHierarchyDescription channelHierarchy = new ChannelHierarchyDescription();

        public static ChannelHierarchy FromChannelsParenting(Dictionary<int, int> channelsParenting)
        {
            var result = new ChannelHierarchy();
            result.channelHierarchy.parenting = channelsParenting;
            result.channelHierarchy.channels = ChannelHierarchyConstructionHelper.GetChannelsHashsetFromParentingDict(channelsParenting);
            result.channelHierarchyDescriptionIdentifier = result.channelHierarchy.ComputeIdentifier();
            return result;
        }

        public bool EqualsToAnother(ChannelHierarchy other)
        {
            return channelHierarchyDescriptionIdentifier.Equals(other.channelHierarchyDescriptionIdentifier);
        }
    }
}
