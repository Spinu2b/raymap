using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model
{
    public class SubobjectsChannelsAssociationDescription : IIdentifiableComputationally
    {
        public Dictionary<int, List<int>> channelsForSubobjectsParenting = new Dictionary<int, List<int>>();
        public Dictionary<int, Dictionary<int, List<int>>> channelsForSubobjectsBonesParenting = new Dictionary<int, Dictionary<int, List<int>>>();

        public string ComputeIdentifier()
        {
            throw new NotImplementedException();
        }
    }

    public class SubobjectsChannelsAssociation
    {
        public string subobjectsChannelsAssociationIdentifier;
        public SubobjectsChannelsAssociationDescription subobjectsChannelsAssociationsDescription = new SubobjectsChannelsAssociationDescription();
    }

    public class SubobjectsChannelsAssociations
    {
        public Dictionary<string, SubobjectsChannelsAssociation> subobjectsChannelsAssociations = new Dictionary<string, SubobjectsChannelsAssociation>();

        public static SubobjectsChannelsAssociations 
            FromSubobjectsChannelsAssociationDict(Dictionary<string, SubobjectsChannelsAssociation> subobjectsChannelsAssociationDict)
        {
            throw new NotImplementedException();
        }
    }
}
