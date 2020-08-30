using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.Wrappers
{
    public abstract class PersoAccessor
    {
        public abstract int statesCount { get; }
        public abstract int currentAnimationStateFramesCount { get; }
        public int currentFrame { get; set; }
        public string name { get; set; }

        public abstract void SetState(int stateIndex);
        public abstract SubobjectsLibrary GetSubobjectsLibrary();
        public abstract Dictionary<int, ChannelTransform> GetChannelsKeyframeDataForAnimationFrame(int frameNumber);
        public abstract List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber);
        public abstract SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationsForAnimationFrame(int frameNumber);
        public abstract Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber);
        public abstract bool IsValidAnimationState(int animationStateIndex);
    }
}
