using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.AnimFrameAssoc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso
{
    public class PersoAccessorAnimationStatesHelper
    {
        private PersoAccessor persoAccessor;

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

        private void SwitchContextToAnimationStateOfIndex(int stateIndex)
        {
            persoAccessor.SetState(stateIndex);
            currentPersoAnimationStateIndex = stateIndex;
        }

        private int GetFirstPersoStateIndex()
        {
            return 0;
        }

        public bool AreValidPersoAnimationStatesLeftIncludingCurrentOne()
        {
            return currentPersoAnimationStateIndex < persoAccessor.statesCount;
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

        private bool IsValidPersoAnimationState(int animationStateIndex)
        {
            return persoAccessor.IsValidAnimationState(animationStateIndex);
        }

        public int GetCurrentPersoStateIndex()
        {
            return currentPersoAnimationStateIndex;
        }

        public List<SubobjectUsedMorphAssociationInfo> GetMorphDataForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            var subobjectUsedMorphAssociationInfoListBuilder = new SubobjectUsedMorphAssociationInfoListBuilder();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                subobjectUsedMorphAssociationInfoListBuilder.Consider(frameNumber, persoAccessor.GetMorphDataForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
            return subobjectUsedMorphAssociationInfoListBuilder.Build();
        }

        public IEnumerable<Tuple<int, SubobjectsChannelsAssociation>> IterateChannelSubobjectsAssociationsDataForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, SubobjectsChannelsAssociation>(
                    frameNumber, persoAccessor.GetSubobjectsChannelsAssociationsForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
        }

        public IEnumerable<Tuple<int, Dictionary<int, int>>> IterateChannelParentingInfosForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, Dictionary<int, int>>(
                    frameNumber, persoAccessor.GetChannelParentingInfosForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
        }

        public IEnumerable<Tuple<int, Dictionary<int, ChannelTransform>>> IterateKeyframeDataForThisAnimationState()
        {
            int frameNumber = GetFirstValidStateAnimationKeyframeFrameNumber();
            while (AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(frameNumber))
            {
                yield return new Tuple<int, Dictionary<int, ChannelTransform>>(
                    frameNumber, persoAccessor.GetChannelsKeyframeDataForAnimationFrame(frameNumber));
                frameNumber = GetStateAnimationNextFrameNumberAfter(frameNumber);
            }
        }

        public int GetFirstValidStateAnimationKeyframeFrameNumber()
        {
            return 0;
        }

        public bool AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(int currentFrameNumber)
        {
            return currentFrameNumber < persoAccessor.currentAnimationStateFramesCount;
        }

        public int GetStateAnimationNextFrameNumberAfter(int currentFrameNumber)
        {
            return currentFrameNumber + 1;
        }
    }
}
