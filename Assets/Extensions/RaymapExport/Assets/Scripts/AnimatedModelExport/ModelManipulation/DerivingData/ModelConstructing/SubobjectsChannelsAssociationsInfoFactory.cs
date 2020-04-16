using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class SubobjectsChannelsAssociationsInfoFactory
    {
        public Dictionary<string, SubobjectsChannelsAssociation> DeriveFor(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var subobjectsChannelsAssociationsInfoBuilder = new SubobjectsChannelsAssociationsInfoBuilder();
            foreach (Tuple<int, SubobjectsChannelsAssociation> subobjectsChannelsAssociationForFrame
                in persoBehaviourAnimationStatesHelper.IterateChannelsSubobjectsAssociationsDataForThisAnimationState())
            {
                var subobjectsChannelsAssociationDict = new Dictionary<string, SubobjectsChannelsAssociation>();
                subobjectsChannelsAssociationDict.Add(subobjectsChannelsAssociationForFrame.Item2.subobjectsChannelsAssociationDescriptionHash,
                    subobjectsChannelsAssociationForFrame.Item2);
                subobjectsChannelsAssociationsInfoBuilder.Consolidate(subobjectsChannelsAssociationDict);
            }
            return subobjectsChannelsAssociationsInfoBuilder.Build();
        }
    }
}
