using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.ModelConstructing;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces
{
    public class PersoAnimationStatesExportInterface
    {
        private FamilyAnimationStatesHelper familyAnimationStatesHelper;
        private int currentFrameNumber = 0;

        public PersoAnimationStatesExportInterface(Family family)
        {
            this.familyAnimationStatesHelper = new FamilyAnimationStatesHelper(family);
        }

        public void ResetToInitialAnimationState()
        {
            familyAnimationStatesHelper.SwitchToFirstAnimationState();
        }

        public bool AreAnimationClipsLeft()
        {
            return familyAnimationStatesHelper.AreValidPersoAnimationStatesLeftIncludingCurrentOne();
        }

        public string GetCurrentAnimationClipName()
        {
            return "Animation " + familyAnimationStatesHelper.GetCurrentPersoStateIndex();
        }

        public bool AreAnimationFramesLeft()
        {
            return familyAnimationStatesHelper.AreKeyframesLeftForCurrentAnimationStateStartingWithFrameNumber(currentFrameNumber);
        }

        public object DeriveAnimTreeWithChannelsDataHierarchyForGivenFrame(int animationFrameNumber)
        {
            var animTreeWithChannelsDataHierarchyFactory = new AnimTreeWithChannelsDataHierarchyFactory();
            return animTreeWithChannelsDataHierarchyFactory.ConstructFromGiven(new AnimA3DGeneralAnimationDataManipulationInterface(
                familyAnimationStatesHelper.GetAnimA3DGeneralForCurrentPersoAnimationState()), animationFrameNumber);
        }

        public int GetCurrentFrameNumberForExport()
        {
            return currentFrameNumber;
        }

        public void NextKeyframe()
        {
            currentFrameNumber = familyAnimationStatesHelper.GetStateAnimationNextFrameNumberAfter(currentFrameNumber);
        }

        public void NextAnimationClip()
        {
            familyAnimationStatesHelper.AcquireNextValidPersoAnimationState();
            currentFrameNumber = familyAnimationStatesHelper.GetFirstValidStateAnimationKeyframeFrameNumber();
        }
    }
}
