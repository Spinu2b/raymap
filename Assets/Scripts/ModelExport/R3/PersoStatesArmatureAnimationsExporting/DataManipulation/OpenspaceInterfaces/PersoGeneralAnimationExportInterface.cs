using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelExport.R3.PersoStatesArmatureAnimationsExporting.DataManipulation.Model;
using ModelExport.R3.PersoStatesArmatureAnimationsExporting.DataManipulation.ModelConstructing;
using ModelExport.R3.PersoStatesArmatureAnimationsExporting.DataManipulation.OpenspaceInterfaces.Helpers;
using OpenSpace.Animation.Component;
using OpenSpace.Object.Properties;

namespace ModelExport.R3.PersoStatesArmatureAnimationsExporting.DataManipulation.OpenspaceInterfaces
{
    public class PersoGeneralAnimationExportInterface
    {
        private FamilyAnimationStatesHelper familyAnimationStatesHelper;

        private ObjectList objectList;

        int currentFrameNumber = 0;

        public PersoGeneralAnimationExportInterface(Family family, ObjectList objectList)
        {
            this.familyAnimationStatesHelper = new FamilyAnimationStatesHelper(family);
            this.objectList = objectList;
        }

        public Dictionary<string, Dictionary<string, float>> GetMorphWeightsForGivenFrame(int animationFrameNumber)
        {
            return new ModelExport.R3.Morphs.R3MorphWeightsCalculator(
                familyAnimationStatesHelper.GetAnimA3DGeneralForCurrentPersoAnimationState(), objectList)
                .WeightsForFrame(animationFrameNumber);
        }

        public bool AreAnimationClipsLeft()
        {
            return familyAnimationStatesHelper.AreValidPersoAnimationStatesLeftIncludingCurrentOne();
        }

        public string GetCurrentAnimationClipName()
        {
            return "Animation " + familyAnimationStatesHelper.GetCurrentPersoStateIndex();
        }

        public void ResetAnimationState()
        {
            familyAnimationStatesHelper.SwitchToFirstAnimationState();
        }

        public bool AreAnimationFramesLeft()
        {
            return familyAnimationStatesHelper.AreKeyframesLeftForCurrentAnimationStateStartingWithFrameNumber(currentFrameNumber);
        }

        public AnimTreeWithChannelsDataHierarchy DeriveAnimTreeWithChannelsDataHierarchyForGivenFrame(
            int animationFrameNumber)
        {
            AnimTreeWithChannelsDataHierarchyConstructor animTreeWithChannelsDataHierarchyConstructor =
                new AnimTreeWithChannelsDataHierarchyConstructor();
            return animTreeWithChannelsDataHierarchyConstructor.ConstructFromGiven(
                new AnimA3DGeneralDataManipulationInterface(familyAnimationStatesHelper.GetAnimA3DGeneralForCurrentPersoAnimationState()),
                animationFrameNumber);
        }

        public int GetCurrentFrameNumberForExport()
        {
            return currentFrameNumber;
        }

        public void NextKeyframe()
        {
            currentFrameNumber = familyAnimationStatesHelper.GetStateAnimationNextKeyframeFrameNumberAfter(currentFrameNumber);
        }

        public void NextAnimationClip()
        {
            familyAnimationStatesHelper.AcquireNextValidPersoAnimationState();
            currentFrameNumber = familyAnimationStatesHelper.GetFirstValidStateAnimationKeyframeFrameNumber();
        }
    }
}