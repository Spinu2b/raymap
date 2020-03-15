using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData.OpenSpaceInterfaces;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces
{
    public class PersoAnimationStatesExportInterface : PersoAnimationStatesTraverser
    {
        public PersoAnimationStatesExportInterface(Family family) : base(family) {}

        public string GetCurrentAnimationClipName()
        {
            return "Animation " + familyAnimationStatesHelper.GetCurrentPersoStateIndex();
        }

        public object DeriveAnimTreeWithChannelsDataHierarchyForGivenFrame(int animationFrameNumber)
        {
            var animTreeWithChannelsDataHierarchyFactory = new AnimTreeWithChannelsDataHierarchyFactory();
            return animTreeWithChannelsDataHierarchyFactory.ConstructFromGiven(new AnimA3DGeneralAnimationDataManipulationInterface(
                familyAnimationStatesHelper.GetAnimA3DGeneralForCurrentPersoAnimationState()), animationFrameNumber);
        }
    }
}
