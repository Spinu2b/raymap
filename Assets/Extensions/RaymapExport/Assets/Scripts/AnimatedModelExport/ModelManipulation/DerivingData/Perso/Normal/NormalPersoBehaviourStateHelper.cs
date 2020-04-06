﻿using OpenSpace;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourStateHelper
    {
        private PersoBehaviour persoBehaviour;

        public NormalPersoBehaviourStateHelper(PersoBehaviour persoBehaviour)
        {
            this.persoBehaviour = persoBehaviour;
        }

        public bool IsValidAnimationState(int animationStateIndex)
        {
			if (animationStateIndex < 0 || animationStateIndex >= persoBehaviour.perso.p3dData.family.states.Count) return false;
			State state = persoBehaviour.perso.p3dData.family.states[animationStateIndex];
			State s = state;

			MapLoader l = MapLoader.Loader;
			ushort anim_index = 0;
			byte bank_index = 0;
			if (state.anim_ref != null)
			{
				anim_index = state.anim_ref.anim_index;
				bank_index = persoBehaviour.perso.p3dData.family.animBank;
			}
			if (state.anim_refMontreal != null)
			{
				return true;
			}
			else if (state.anim_ref != null
			  && l.animationBanks != null
			  && l.animationBanks.Length > bank_index
			  && l.animationBanks[bank_index] != null
			  && l.animationBanks[bank_index].animations != null
			  && l.animationBanks[bank_index].animations.Length > anim_index
			  && l.animationBanks[bank_index].animations[anim_index] != null)
			{
				return true;
			}
			else if (state.anim_ref != null && state.anim_ref.a3d != null)
			{
				return true;
			}
			else if (state.anim_ref != null && state.anim_ref.a3dLargo != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
    }
}
