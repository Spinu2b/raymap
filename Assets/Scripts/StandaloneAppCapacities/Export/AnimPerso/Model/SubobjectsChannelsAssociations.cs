using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using Assets.Scripts.Util;
using Assets.Scripts.Util.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model
{
    public class SubobjectsChannelsAssociationDescription : IIdentifiableComputationally, ISerializableToBytes
    {
        public Dictionary<int, List<int>> channelsForSubobjectsParenting = new Dictionary<int, List<int>>();
        public Dictionary<int, Dictionary<int, List<int>>> channelsForSubobjectsBonesParenting = new Dictionary<int, Dictionary<int, List<int>>>();

        public string ComputeIdentifier()
        {
            var bytes = SerializeToBytes();
            return BytesHashHelper.GetHashHexStringFor(bytes);
        }

        public byte[] SerializeToBytes()
        {
            var channelsForSubobjectsParentingBytes = ComparableKeyDictionaryToBytesSerializer.
                WithCSharpComparableKeySerializeToBytes(
                    dict: channelsForSubobjectsParenting,
                    keySerializer: BytesHelper.SerializeFunctions.IntSerializerFunction,
                    valueSerializer: x =>
                        BytesHelper.SerializeFunctions.ListSerializerFunction(
                            list: x,
                            elementSerializer: BytesHelper.SerializeFunctions.IntSerializerFunction)
                        );

            var channelsForSubobjectsBonesParentingBytes = ComparableKeyDictionaryToBytesSerializer.
                WithCSharpComparableKeySerializeToBytes(
                    dict: channelsForSubobjectsBonesParenting,
                    keySerializer: BytesHelper.SerializeFunctions.IntSerializerFunction,
                    valueSerializer: x => ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                            dict: x,
                            keySerializer: BytesHelper.SerializeFunctions.IntSerializerFunction,
                            valueSerializer: y =>
                                BytesHelper.SerializeFunctions.ListSerializerFunction(
                                    list: y,
                                    elementSerializer: BytesHelper.SerializeFunctions.IntSerializerFunction
                                )
                        )
                );

            return channelsForSubobjectsParentingBytes.Concat(channelsForSubobjectsBonesParentingBytes).ToArray();
        }
    }

    public class SubobjectsChannelsAssociation : IComparableModel<SubobjectsChannelsAssociation>
    {
        public string subobjectsChannelsAssociationIdentifier;
        public SubobjectsChannelsAssociationDescription subobjectsChannelsAssociationsDescription = new SubobjectsChannelsAssociationDescription();

        public bool EqualsToAnother(SubobjectsChannelsAssociation other)
        {
            return subobjectsChannelsAssociationIdentifier.Equals(other.subobjectsChannelsAssociationIdentifier);
        }
    }

    public class SubobjectsChannelsAssociations
    {
        public Dictionary<string, SubobjectsChannelsAssociation> subobjectsChannelsAssociations = new Dictionary<string, SubobjectsChannelsAssociation>();

        public static SubobjectsChannelsAssociations 
            FromSubobjectsChannelsAssociationDict(Dictionary<string, SubobjectsChannelsAssociation> subobjectsChannelsAssociationDict)
        {
            var result = new SubobjectsChannelsAssociations();
            result.subobjectsChannelsAssociations = subobjectsChannelsAssociationDict;
            return result;
        }
    }
}
