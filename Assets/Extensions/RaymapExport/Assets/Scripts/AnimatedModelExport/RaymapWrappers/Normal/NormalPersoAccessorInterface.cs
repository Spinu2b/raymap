using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using OpenSpace;
using OpenSpace.Animation;
using OpenSpace.Animation.Component;
using OpenSpace.Animation.ComponentLargo;
using OpenSpace.Object;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal
{
    public partial class NormalPersoAccessor : PersoAccessor
    {
        public override int statesCount => perso.p3dData.family.states.Count;

        public override int currentAnimationStateFramesCount => GetCurrentAnimationStateFramesCount();

        public override Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override SubobjectsLibraryModel GetSubobjectsLibrary()
        {
            return normalPersoAccessorSubobjectsLibraryFetchingHelper.GetPersoSubobjectsLibrary();
        }

        public override bool IsValidAnimationState(int animationStateIndex)
        {
            throw new NotImplementedException();
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
            this.normalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper =
                new NormalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper(this);
            this.normalPersoAccessorChannelsParentingFetchingHelper = new NormalPersoAccessorChannelsParentingFetchingHelper(this);
            this.normalPersoAccessorMorphFetchingHelper = new NormalPersoAccessorMorphFetchingHelper(this);
            this.normalPersoAccessorStateHelper = new NormalPersoAccessorStateHelper(this);
            this.normalPersoAccessorSubobjectsLibraryFetchingHelper = new NormalPersoAccessorSubobjectsLibraryFetchingHelper(this); 
        }
    }
}
