using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing
{
    public class SkinnedSubmeshesSetFactory
    {
        public SkinnedSubmeshesSet ConstructFromGiven(AnimA3DGeneralSubmeshesDataManipulatorInterface animA3DSubmeshesDataManipulator, int animationFrameNumber)
        {
            var skinnedSubmeshesSetBuilder = new SkinnedSubmeshesSetBuilder();
            foreach (var physicalObjectWithChannelParentingInfo in animA3DSubmeshesDataManipulator.IteratePhysicalObjectsWithChannelParentingInfosForGivenFrame(animationFrameNumber))
            {
                if (physicalObjectWithChannelParentingInfo.IsVisiblePhysicalObject)
                {
                    foreach (var physicalObjectSubmeshObject in physicalObjectWithChannelParentingInfo.IteratePhysicalObjectSubmeshes())
                    {
                        if (!physicalObjectSubmeshObject.IsAlphaChannelSubmeshObject)
                        {
                            skinnedSubmeshesSetBuilder.AddSubmeshObject(physicalObjectSubmeshObject);
                        }
                    }
                } 
            }
            return skinnedSubmeshesSetBuilder.Build();
        }
    }
}
