using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.Common;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData.OpenSpaceInterfaces
{
    public abstract class PersoAnimationStatesTraverser
    {
        protected PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper;
        protected int currentFrameNumber = 0;

        public PersoAnimationStatesTraverser(PersoBehaviourInterface persoBehaviourInterface)
        {
            this.persoBehaviourAnimationStatesHelper = new PersoBehaviourAnimationStatesHelper(persoBehaviourInterface);
        }

        public void ResetToInitialAnimationState()
        {
            persoBehaviourAnimationStatesHelper.SwitchToFirstAnimationState();
        }

        public bool AreAnimationStatesLeft()
        {
            return persoBehaviourAnimationStatesHelper.AreValidPersoAnimationStatesLeftIncludingCurrentOne();
        }

        public bool AreAnimationFramesLeft()
        {
            return persoBehaviourAnimationStatesHelper.AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(currentFrameNumber);
        }

        public int GetCurrentFrameNumberForExport()
        {
            return currentFrameNumber;
        }

        public void NextFrame()
        {
            currentFrameNumber = persoBehaviourAnimationStatesHelper.GetStateAnimationNextFrameNumberAfter(currentFrameNumber);
        }

        public void NextAnimationState()
        {
            persoBehaviourAnimationStatesHelper.AcquireNextValidPersoAnimationState();
            currentFrameNumber = persoBehaviourAnimationStatesHelper.GetFirstValidStateAnimationKeyframeFrameNumber();
        }
    }
}
