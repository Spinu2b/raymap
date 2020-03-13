using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.ModelConstructing
{
    public class AnimTreeWithChannelsDataHierarchyFactory
    {
        public AnimTreeWithChannelsDataHierarchy ConstructFromGiven(AnimA3DGeneralDataManipulationInterface animA3DGeneralDataManipulator,
            int animationFrameNumber)
        {
            var animTreeWithChannelsDataHierarchyBuilder = new AnimTreeWithChannelsDataHierarchyBuilder();
            foreach (var animHierarchyWithChannelInfo in animA3DGeneralDataManipulator.IterateAnimHierarchiesWithChannelInfosForGivenFrame(animationFrameNumber))
            {
                animTreeWithChannelsDataHierarchyBuilder.AddAnimHierarchyWithChannelInfo(animHierarchyWithChannelInfo);
            }
            return animTreeWithChannelsDataHierarchyBuilder.Build();
        }
    }
}
