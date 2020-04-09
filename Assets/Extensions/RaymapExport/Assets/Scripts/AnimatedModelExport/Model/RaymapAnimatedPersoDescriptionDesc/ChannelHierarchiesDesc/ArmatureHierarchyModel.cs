using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.ChannelHierarchiesDesc
{
    public class ArmatureHierarchyDescription : ISerializableToBytes, IHashableModel, IComparableModel<ArmatureHierarchyDescription>
    {
        public HashSet<int> channels = new HashSet<int>();
        public Dictionary<int, int> parenting = new Dictionary<int, int>();

        public string ComputeHash()
        {
            var armatureHierarchyBytes = SerializeToBytes();
            return BytesHashHelper.GetHashHexStringFor(armatureHierarchyBytes);
        }

        public bool EqualsToAnother(ArmatureHierarchyDescription other)
        {
            if (channels.Count != other.channels.Count) return false;
            if (parenting.Count != other.parenting.Count) return false;
            if (!ComparableModelDictionariesComparator.AreCSharpComparableDictionariesCompliant(parenting, other.parenting)) return false;
            foreach (var channel in channels)
            {
                if (!other.channels.Contains(channel)) return false;
            }
            return true;
        }

        public byte[] SerializeToBytes()
        {
            return channels.OrderBy(x => x).Select(x => BitConverter.GetBytes(x))
                .Concat(parenting.OrderBy(x => x.Key).Select(x => BitConverter.GetBytes(x.Key)
                .Concat(BitConverter.GetBytes(x.Value)))).SelectMany(x => x).ToArray();
        }
    }

    public class ArmatureHierarchyModel : IComparableModel<ArmatureHierarchyModel>
    {
        public string armatureHierarchyDescriptionHash;
        public ArmatureHierarchyDescription armatureHierarchy = new ArmatureHierarchyDescription();

        public static ArmatureHierarchyModel FromChannelsParenting(Dictionary<int, int> channelsParenting)
        {
            var result = new ArmatureHierarchyModel();
            result.armatureHierarchy.parenting = channelsParenting.ToDictionary(x => x.Key, x => x.Value);
            result.armatureHierarchy.channels = new HashSet<int>(channelsParenting.Keys.Concat(channelsParenting.Values));
            result.armatureHierarchyDescriptionHash = result.armatureHierarchy.ComputeHash();
            return result;
        }

        public bool EqualsToAnother(ArmatureHierarchyModel other)
        {
            return armatureHierarchyDescriptionHash.Equals(other.armatureHierarchyDescriptionHash) &&
                armatureHierarchy.EqualsToAnother(other.armatureHierarchy);
        }
    }
}
