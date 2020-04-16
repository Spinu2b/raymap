using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using PeepsCompress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc
{
    public class SubobjectsChannelsAssociationDescription : ISerializableToBytes, IHashableModel
    {
        public Dictionary<int, List<int>> channelsForSubobjectsParenting = new Dictionary<int, List<int>>();
        public Dictionary<int, Dictionary<int, List<int>>> channelsForSubobjectsBonesParenting = new Dictionary<int, Dictionary<int, List<int>>>();

        public string ComputeHash()
        {
            var bytes = SerializeToBytes();
            return BytesHashHelper.GetHashHexStringFor(bytes);
        }

        public byte[] SerializeToBytes()
        {
            var channelsForSubobjectsParentingBytes = ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                dict: channelsForSubobjectsParenting,
                keySerializer: x => BitConverter.GetBytes(x),
                valueSerializer: x => x.Select(y => BitConverter.GetBytes(y)).SelectMany(y => y).ToArray());

            var channelsForSubobjectsBonesParentingBytes = ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                dict: channelsForSubobjectsBonesParenting,
                keySerializer: x => BitConverter.GetBytes(x),
                valueSerializer: x => ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                        dict: x,
                        keySerializer: y => BitConverter.GetBytes(y),
                        valueSerializer: y => y.Select(z => BitConverter.GetBytes(z)).SelectMany(z => z).ToArray()
                    ));

            return channelsForSubobjectsBonesParentingBytes.Concat(channelsForSubobjectsBonesParentingBytes).ToArray();
        }
    }

    public class SubobjectsChannelsAssociation : IComparableModel<SubobjectsChannelsAssociation>
    {
        public string subobjectsChannelsAssociationDescriptionHash;
        public SubobjectsChannelsAssociationDescription subobjectsChannelsAssociationDescription =
            new SubobjectsChannelsAssociationDescription();

        public bool EqualsToAnother(SubobjectsChannelsAssociation other)
        {
            return subobjectsChannelsAssociationDescriptionHash.Equals(other.subobjectsChannelsAssociationDescriptionHash);
        }
    }
}
