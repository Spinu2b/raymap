using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.OpenSpace.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers
{
    public abstract class PersoAccessor
    {
        public abstract int statesCount { get; }
        public abstract int currentAnimationStateFramesCount { get; }

        public abstract int currentFrame { get; }

        public abstract string name { get; }

        public abstract void SetState(int stateIndex);

        public abstract SubobjectsLibraryModel GetSubobjectsLibrary();

        public abstract Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForAnimationFrame(int frameNumber);

        public abstract List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber);

        public abstract SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForAnimationFrame(int frameNumber);

        public abstract Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber);

        public abstract bool IsValidAnimationState(int animationStateIndex);
    }
}
