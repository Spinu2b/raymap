﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSpace;
using OpenSpace.Animation.Component;
using OpenSpace.Object.Properties;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces
{
    public class FamilyAnimationStatesHelper
    {
        private Family family;
        private AnimA3DGeneral animA3DGeneralForCurrentPersoAnimationState;
        private MapLoader loader;

        private int currentPersoAnimationStateIndex;

        public FamilyAnimationStatesHelper(Family family)
        {
            this.family = family;
            this.loader = MapLoader.Loader;
            this.currentPersoAnimationStateIndex = 0;
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

        public bool AreValidPersoAnimationStatesLeftIncludingCurrentOne()
        {
            return currentPersoAnimationStateIndex < family.states.Count;
        }

        public int GetCurrentPersoStateIndex()
        {
            return currentPersoAnimationStateIndex;
        }

        public bool AreKeyframesLeftForCurrentAnimationStateStartingWithFrameNumber(int currentFrameNumber)
        {
            return currentFrameNumber < animA3DGeneralForCurrentPersoAnimationState.num_onlyFrames;
        }

        public AnimA3DGeneral GetAnimA3DGeneralForCurrentPersoAnimationState()
        {
            return animA3DGeneralForCurrentPersoAnimationState;
        }

        public int GetStateAnimationNextKeyframeFrameNumberAfter(int currentFrameNumber)
        {
            return currentFrameNumber + 1;
        }

        public void AcquireNextValidPersoAnimationState()
        {
            int currentStateIndex = currentPersoAnimationStateIndex;
            currentStateIndex++;

            while (!IsValidPersoAnimationState(currentStateIndex))
            {
                currentStateIndex++;
                if (currentStateIndex >= family.states.Count)
                {
                    currentPersoAnimationStateIndex = currentStateIndex;
                    return;
                }
            }
            SwitchContextToAnimationStateOfIndex(currentStateIndex);
        }

        private void SwitchContextToAnimationStateOfIndex(int stateIndex)
        {
            State state = family.states[stateIndex];
            int animationIndex = state.anim_ref.anim_index;
            int animationBankIndex = family.animBank;
            animA3DGeneralForCurrentPersoAnimationState = loader.animationBanks[animationBankIndex].animations[animationIndex];
            currentPersoAnimationStateIndex = stateIndex;
        }

        private bool IsValidPersoAnimationState(int animationStateIndex)
        {
            if (animationStateIndex >= family.states.Count)
            {
                return false;
            }
            else
            {
                State state = family.states[animationStateIndex];
                int animationIndex = state.anim_ref.anim_index;
                int animationBankIndex = family.animBank;

                return state.anim_ref != null
                && loader.animationBanks != null
                && loader.animationBanks.Length > animationBankIndex
                && loader.animationBanks[animationBankIndex] != null
                && loader.animationBanks[animationBankIndex].animations != null
                && loader.animationBanks[animationBankIndex].animations.Length > animationIndex
                && loader.animationBanks[animationBankIndex].animations[animationIndex] != null;
            }
        }

        public int GetFirstValidStateAnimationKeyframeFrameNumber()
        {
            return 1;
        }
    }
}
