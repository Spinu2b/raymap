using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.Model;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.ModelConstructing
{
    public class AnimTreeWithChannelsDataHierarchyFactory
    {
        public AnimTreeWithChannelsDataHierarchy ConstructFromGiven(PersoBehaviourAnimationExportInterface persoBehaviourAnimationExportInterface, int animationFrameNumber)
        {
            var animTreeWithChannelsDataHierarchyBuilder = new AnimTreeWithChannelsDataHierarchyBuilder();
            foreach (var animHierarchyWithChannelInfo in persoBehaviourAnimationExportInterface.IterateAnimHierarchiesWithChannelInfosForGivenFrame(animationFrameNumber))
            {
                animTreeWithChannelsDataHierarchyBuilder.AddAnimHierarchyWithChannelInfo(animHierarchyWithChannelInfo);
            }
            return animTreeWithChannelsDataHierarchyBuilder.Build();
        }
    }
}
