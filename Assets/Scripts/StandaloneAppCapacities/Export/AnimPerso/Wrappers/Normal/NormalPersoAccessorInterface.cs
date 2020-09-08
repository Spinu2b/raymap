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
            this.normalPersoAccessorAnimationKeyframesFetchingHelper = new NormalPersoAccessorAnimationKeyframesFetchingHelper(this);
            this.normalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper = new NormalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper(this);
            this.normalPersoAccessorChannelsParentingFetchingHelper = new NormalPersoAccessorChannelsParentingFetchingHelper(this);
            this.normalPersoAccessorMorphFetchingHelper = new NormalPersoAccessorMorphFetchingHelper(this);
            this.normalPersoAccessorStateHelper = new NormalPersoAccessorStateHelper(this);
            this.normalPersoAccessorSubobjectsLibraryFetchingHelper = new NormalPersoAccessorSubobjectsLibraryFetchingHelper(this);
        }
    }
}
