using ModelExport.R3.PersoStatesArmatureAnimationsExporting.DataManipulation.Model;
using ModelExport.R3.PersoStatesArmatureAnimationsExporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExport.R3.PersoStatesArmatureAnimationsExporting.DataManipulation
{
    public class RaymapAnimationKeyframeModelFacadeAccessor
    {
        private AnimTreeWithChannelsDataHierarchy animTreeWithChannelsDataHierarchy;

        public RaymapAnimationKeyframeModelFacadeAccessor(AnimTreeWithChannelsDataHierarchy animTreeWithChannelsDataHierarchy,
            int FrameNumber)
        {
            this.animTreeWithChannelsDataHierarchy = animTreeWithChannelsDataHierarchy;
            this.FrameNumber = FrameNumber;
        }

        public int FrameNumber;

        public Dictionary<string, Dictionary<string, float>> MorphWeights;

        public AnimationFrameModel GetAnimationFrameModel()
        {
            AnimationFrameModel result = animTreeWithChannelsDataHierarchy.ToAnimationFrameModel();
            result.morphWeights = MorphWeights;
            return result;
        }
    }
}
