using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal
{
    public partial class NormalPersoAccessor : PersoAccessor
    {
        public override int statesCount => perso.p3dData.family.states.Count;

        public override int currentAnimationStateFramesCount => GetCurrentAnimationStateFramesCount();

        public override Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber)
        {
            return normalPersoAccessorChannelsParentingFetchingHelper.GetPersoBehaviourChannelsParentingForFrame(frameNumber);
        }

        public override Dictionary<int, ChannelTransform> GetChannelsKeyframeDataForAnimationFrame(int frameNumber)
        {
            return normalPersoAccessorAnimationKeyframesFetchingHelper.GetPersoBehaviourChannelsKeyframeDataForFrame(frameNumber);
        }

        public override List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber)
        {
            return normalPersoAccessorMorphFetchingHelper.GetPersoBehaviourMorphDataForFrame(frameNumber);
        }

        public override SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationsForAnimationFrame(int frameNumber)
        {
            return normalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper.GetPersoBehaviourSubobjectsChannelsAssociationForFrame(frameNumber);
        }

        public override SubobjectsLibrary GetSubobjectsLibrary()
        {
            return normalPersoAccessorSubobjectsLibraryFetchingHelper.GetPersoSubobjectsLibrary();
        }

        public override bool IsValidAnimationState(int animationStateIndex)
        {
            return normalPersoAccessorStateHelper.IsValidAnimationState(animationStateIndex);
        }

        public override void SetState(int stateIndex)
        {
            if (stateIndex < 0 || stateIndex >= perso.p3dData.family.states.Count) return;
            this.stateIndex = stateIndex;
            this.currentState = stateIndex;
            state = perso.p3dData.family.states[stateIndex];
            SetState(state);
        }

        public NormalPersoAccessor() : base()
        {
            // OK
            this.normalPersoAccessorAnimationKeyframesFetchingHelper = new NormalPersoAccessorAnimationKeyframesFetchingHelper(this);
            // NOT OK?
            this.normalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper = new NormalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper(this);
            // OK, but resign from channels set in ChannelHierarchy definition, this can be derived from channel keyframes for particular animation states
            // channels set seems to remain constant across one animation state, only parenting changes across frames
            // yep, each channel has one keyframe located at frame number 0, so they all dictate initial transform for given animation state 
            this.normalPersoAccessorChannelsParentingFetchingHelper = new NormalPersoAccessorChannelsParentingFetchingHelper(this);
            // Don't know yet
            this.normalPersoAccessorMorphFetchingHelper = new NormalPersoAccessorMorphFetchingHelper(this);
            // This has nothing to do with strict direct model representation
            this.normalPersoAccessorStateHelper = new NormalPersoAccessorStateHelper(this);
            // OK
            this.normalPersoAccessorSubobjectsLibraryFetchingHelper = new NormalPersoAccessorSubobjectsLibraryFetchingHelper(this);
        }
    }
}
