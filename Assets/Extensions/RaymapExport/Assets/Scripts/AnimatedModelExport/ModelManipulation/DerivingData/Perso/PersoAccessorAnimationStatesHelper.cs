using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class PersoAccessorAnimationStatesHelper
    {
        public PersoAccessor persoAccessor { get; private set; }

        private int currentPersoAnimationStateIndex = 0;

        public PersoAccessorAnimationStatesHelper(PersoAccessor persoAccessor)
        {
            this.persoAccessor = persoAccessor;
        }

        public void SwitchToFirstAnimationState()
        {
            SwitchContextToAnimationStateOfIndex(GetFirstPersoStateIndex());
            currentPersoAnimationStateIndex = GetFirstPersoStateIndex();
        }

        private int GetFirstPersoStateIndex()
        {
            return 0;
        }

        private void SwitchContextToAnimationStateOfIndex(int stateIndex)
        {
            persoAccessor.SetState(stateIndex);
            currentPersoAnimationStateIndex = stateIndex;
        }

        public bool AreValidPersoAnimationStatesLeftIncludingCurrentOne()
        {
            return currentPersoAnimationStateIndex < persoAccessor.statesCount;
        }

        public bool AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(int currentFrameNumber)
        {
            return currentFrameNumber < persoAccessor.currentAnimationStateFramesCount;
        }

        public int GetStateAnimationNextFrameNumberAfter(int currentFrameNumber)
        {
            return currentFrameNumber + 1;
        }

        public int GetCurrentPersoStateIndex()
        {
            return currentPersoAnimationStateIndex;
        }

        public void AcquireNextValidPersoAnimationState()
        {
            int currentStateIndex = currentPersoAnimationStateIndex;
            currentStateIndex++;

            while (!IsValidPersoAnimationState(currentStateIndex))
            {
                currentStateIndex++;
                if (currentStateIndex >= persoAccessor.statesCount)
                {
                    currentPersoAnimationStateIndex = currentStateIndex;
                    return;
                }
            }
            SwitchContextToAnimationStateOfIndex(currentStateIndex);
        }

        public IEnumerable<Tuple<int, Dictionary<int, ChannelTransformModel>>> IterateKeyframeDataForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, Dictionary<int, ChannelTransformModel>>(
                    frameNumber, persoAccessor.GetChannelsKeyframeDataForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }      
        }

        public List<SubobjectUsedMorphAssociationInfo> GetMorphDataForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            var subobjectUsedMorphAssociationInfoListBuilder = new SubobjectUsedMorphAssociationInfoListBuilder();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                subobjectUsedMorphAssociationInfoListBuilder.Consider(frameNumber,
                    persoAccessor.GetMorphDataForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
            return subobjectUsedMorphAssociationInfoListBuilder.Build();
        }

        public IEnumerable<Tuple<int, SubobjectsChannelsAssociation>> IterateChannelsSubobjectsAssociationsDataForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, SubobjectsChannelsAssociation>(frameNumber,
                    persoAccessor.GetSubobjectsChannelsAssociationForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
        }

        public IEnumerable<Tuple<int, Dictionary<int, int>>> IterateChannelParentingInfosThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, Dictionary<int, int>>(frameNumber,
                    persoAccessor.GetChannelParentingInfosForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
        }

        private bool IsValidPersoAnimationState(int animationStateIndex)
        {
            return persoAccessor.IsValidAnimationState(animationStateIndex);
        }

        public int GetFirstValidStateAnimationKeyframeFrameNumber()
        {
            return 0;
        }
    }
}
