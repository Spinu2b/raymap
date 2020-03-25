using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.Common;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.ModelConstructing;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData.OpenSpaceInterfaces;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces
{
    public class PersoAnimationStatesExportInterface : PersoAnimationStatesTraverser
    {
        public PersoAnimationStatesExportInterface(PersoBehaviourInterface persoBehaviourInterface) : base(persoBehaviourInterface) {}

        public string GetCurrentAnimationClipName()
        {
            return "Animation " + persoBehaviourAnimationStatesHelper.GetCurrentPersoStateIndex();
        }

        public object DeriveAnimTreeWithChannelsDataHierarchyForGivenFrame(int animationFrameNumber)
        {
            //throw new NotImplementedException();
            var animTreeWithChannelsDataHierarchyFactory = new AnimTreeWithChannelsDataHierarchyFactory();
            return animTreeWithChannelsDataHierarchyFactory.ConstructFromGiven(new PersoBehaviourAnimationExportInterface(
                persoBehaviourAnimationStatesHelper.persoBehaviourInterface), animationFrameNumber);
        }
    }
}
