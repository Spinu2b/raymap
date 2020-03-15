using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData.OpenSpaceInterfaces
{
    public abstract class PersoAnimationStatesTraverser
    {
        protected FamilyAnimationStatesHelper familyAnimationStatesHelper;
        protected int currentFrameNumber = 0;

        public PersoAnimationStatesTraverser(Family family)
        {
            this.familyAnimationStatesHelper = new FamilyAnimationStatesHelper(family);
        }

        public void ResetToInitialAnimationState()
        {
            familyAnimationStatesHelper.SwitchToFirstAnimationState();
        }

        public bool AreAnimationStatesLeft()
        {
            return familyAnimationStatesHelper.AreValidPersoAnimationStatesLeftIncludingCurrentOne();
        }

        public bool AreAnimationFramesLeft()
        {
            return familyAnimationStatesHelper.AreKeyframesLeftForCurrentAnimationStateStartingWithFrameNumber(currentFrameNumber);
        }

        public int GetCurrentFrameNumberForExport()
        {
            return currentFrameNumber;
        }

        public void NextFrame()
        {
            currentFrameNumber = familyAnimationStatesHelper.GetStateAnimationNextFrameNumberAfter(currentFrameNumber);
        }

        public void NextAnimationState()
        {
            familyAnimationStatesHelper.AcquireNextValidPersoAnimationState();
            currentFrameNumber = familyAnimationStatesHelper.GetFirstValidStateAnimationKeyframeFrameNumber();
        }
    }
}
