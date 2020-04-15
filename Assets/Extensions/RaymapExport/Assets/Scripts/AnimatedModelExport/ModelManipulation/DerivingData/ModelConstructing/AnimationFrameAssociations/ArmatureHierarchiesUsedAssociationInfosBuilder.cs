using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.ChannelHierarchiesDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations
{
    public class ArmatureHierarchiesUsedAssociationInfosBuilder : AnimationFramesDataUsedAssociationInfosBuilder<Dictionary<int, int>, string>
    {
        protected override string GetKey(Dictionary<int, int> channelsParenting)
        {
            ArmatureHierarchyModel armatureHierarchy = ArmatureHierarchyModel.FromChannelsParenting(channelsParenting);
            return armatureHierarchy.armatureHierarchyDescriptionHash;
        }
    }
}
