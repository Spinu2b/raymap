using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations
{
    public class ChannelsSubobjectsAssociationInfosBuilder : 
        AnimationFramesDataUsedAssociationInfosBuilder<SubobjectsChannelsAssociation, string>
    {
        protected override string GetKey(SubobjectsChannelsAssociation subobjectsChannelsAssociation)
        {
            return subobjectsChannelsAssociation.subobjectsChannelsAssociationDescriptionHash;
        }
    }
}
