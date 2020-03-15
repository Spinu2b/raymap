using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData.OpenSpaceInterfaces;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces
{
    public class PersoAnimationStatesSkinnedSubmeshesExportInterface : PersoAnimationStatesTraverser
    {
        public PersoAnimationStatesSkinnedSubmeshesExportInterface(Family family) : base(family) {}

        public SkinnedSubmeshesSet DeriveSubmeshesSetForGivenFrame(int animationFrameNumber)
        {
            var skinnedSubmeshesSetFactory = new SkinnedSubmeshesSetFactory();
            return skinnedSubmeshesSetFactory.ConstructFromGiven(
                new AnimA3DGeneralSubmeshesDataManipulatorInterface(
                    familyAnimationStatesHelper.GetAnimA3DGeneralForCurrentPersoAnimationState()), animationFrameNumber);
        }
    }
}
