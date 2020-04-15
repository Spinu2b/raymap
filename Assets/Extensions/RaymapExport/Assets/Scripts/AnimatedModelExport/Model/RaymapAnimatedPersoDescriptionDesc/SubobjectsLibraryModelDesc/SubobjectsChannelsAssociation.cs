using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc
{
    public class SubobjectsChannelsAssociationDescription : ISerializableToBytes, IHashableModel
    {
        public Dictionary<int, List<int>> channelsForSubobjectsParenting = new Dictionary<int, List<int>>();
        public Dictionary<int, Dictionary<int, List<int>>> channelsForSubobjectsBonesParenting = new Dictionary<int, Dictionary<int, List<int>>>();

        public string ComputeHash()
        {
            throw new NotImplementedException();
        }

        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
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
