using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.Common;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData.OpenSpaceInterfaces;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing;
using OpenSpace.Object;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces
{
    public class PersoAnimationStatesSkinnedSubmeshesExportInterface : PersoAnimationStatesTraverser
    {
        public PersoAnimationStatesSkinnedSubmeshesExportInterface(PersoBehaviourInterface persoBehaviourInterface) : base(persoBehaviourInterface) {}

        public SkinnedSubmeshesSet DeriveSubmeshesSetForGivenFrame(int animationFrameNumber)
        {
            var skinnedSubmeshesSetFactory = new SkinnedSubmeshesSetFactory();
            return skinnedSubmeshesSetFactory.ConstructFromGiven(
                new PersoBehaviourSubmeshesExportInterface(
                        persoBehaviourAnimationStatesHelper.persoBehaviourInterface), animationFrameNumber);
        }
    }
}
