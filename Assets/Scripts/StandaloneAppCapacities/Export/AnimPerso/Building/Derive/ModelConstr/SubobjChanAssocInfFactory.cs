using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr
{
    public class SubobjectsChannelsAssociationsInfoFactory
    {
        public SubobjectsChannelsAssociations DeriveFor(PersoAccessorAnimationStatesHelper persoAccessorAnimationStatesHelper)
        {
            var subobjectsChannelsAssociationsInfoBuilder = new SubobjectsChannelsAssociationsInfoBuilder();
            foreach (Tuple<int, SubobjectsChannelsAssociation> subobjectsChannelsAssociationForFrame in 
                persoAccessorAnimationStatesHelper.IterateChannelSubobjectsAssociationsDataForThisAnimationState())
            {
                var subobjectsChannelsAssociationDict = new Dictionary<string, SubobjectsChannelsAssociation>();
                subobjectsChannelsAssociationDict.Add(subobjectsChannelsAssociationForFrame.Item2.subobjectsChannelsAssociationIdentifier,
                    subobjectsChannelsAssociationForFrame.Item2);
                subobjectsChannelsAssociationsInfoBuilder.Consolidate(
                    SubobjectsChannelsAssociations.FromSubobjectsChannelsAssociationDict(subobjectsChannelsAssociationDict));
            }
            return subobjectsChannelsAssociationsInfoBuilder.Build();
        }
    }
}
