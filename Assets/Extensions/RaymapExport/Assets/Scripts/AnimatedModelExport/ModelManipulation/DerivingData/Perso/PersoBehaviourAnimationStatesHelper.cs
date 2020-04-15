using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class PersoBehaviourAnimationStatesHelper
    {
        public PersoBehaviourInterface persoBehaviourInterface { get; private set; }
        private int currentPersoAnimationStateIndex = 0;

        public PersoBehaviourAnimationStatesHelper(PersoBehaviourInterface persoBehaviourInterface)
        {
            this.persoBehaviourInterface = persoBehaviourInterface;
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
            persoBehaviourInterface.SetState(stateIndex);
            currentPersoAnimationStateIndex = stateIndex;
        }

        public bool AreValidPersoAnimationStatesLeftIncludingCurrentOne()
        {
            return currentPersoAnimationStateIndex < persoBehaviourInterface.statesCount;
        }

        public bool AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(int currentFrameNumber)
        {
            return currentFrameNumber < persoBehaviourInterface.currentAnimationStateFramesCount;
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
                if (currentStateIndex >= persoBehaviourInterface.statesCount)
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
                    frameNumber, persoBehaviourInterface.GetChannelsKeyframeDataForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }      
        }

        public IEnumerable<Tuple<int, VisualData>> IterateVisualDataForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, VisualData>(frameNumber, persoBehaviourInterface.GetVisualDataForAnimationFrame(frameNumber));
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
                    persoBehaviourInterface.GetMorphDataForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
            return subobjectUsedMorphAssociationInfoListBuilder.Build();
        }

        public IEnumerable<Tuple<int, SubobjectsChannelsAssociation>> IterateChannelsSubobjectsAssociationsDataForThisAnimationState()
        {
            foreach (var subobjectsUsedInfo in IterateSubobjectsUsedForThisAnimationState())
            {
                yield return new Tuple<int, SubobjectsChannelsAssociation>(
                    subobjectsUsedInfo.Item1, subobjectsUsedInfo.Item2.Item1);
            }
        }

        public IEnumerable<Tuple<int, Tuple<SubobjectsChannelsAssociation, List<SubobjectModel>>>> IterateSubobjectsUsedForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, Tuple<SubobjectsChannelsAssociation, List<SubobjectModel>>>(frameNumber, 
                    persoBehaviourInterface.GetSubobjectsUsedForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
        }

        public IEnumerable<Tuple<int, Dictionary<int, int>>> IterateChannelParentingInfosThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, Dictionary<int, int>>(frameNumber,
                    persoBehaviourInterface.GetChannelParentingInfosForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
        }

        private bool IsValidPersoAnimationState(int animationStateIndex)
        {
            return persoBehaviourInterface.IsValidAnimationState(animationStateIndex);
        }

        public int GetFirstValidStateAnimationKeyframeFrameNumber()
        {
            return 0;
        }
    }
}
