using OpenSpace;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal
{
    public partial class NormalPersoAccessor
    {
        private int GetCurrentAnimationStateFramesCount()
        {
            throw new NotImplementedException();
        }

        private void SetState(State s)
        {
            this.state = s;
            stateIndex = s.index;
            currentState = s.index;
            UpdateViewCollision(controller.viewCollision);

            // Set animation
            MapLoader l = MapLoader.Loader;
            ushort anim_index = 0;
            byte bank_index = 0;
            if (state.anim_ref != null)
            {
                anim_index = state.anim_ref.anim_index;
                bank_index = perso.p3dData.family.animBank;
            }
            if (state.anim_refMontreal != null)
            {
                a3d = null;
                animLargo = null;
                animationSpeed = state.speed;
                //animationSpeed = state.speed;
                InitAnimationMontreal(state.anim_refMontreal);
                UpdateAnimation();
            }
            else if (state.anim_ref != null
              && l.animationBanks != null
              && l.animationBanks.Length > bank_index
              && l.animationBanks[bank_index] != null
              && l.animationBanks[bank_index].animations != null
              && l.animationBanks[bank_index].animations.Length > anim_index
              && l.animationBanks[bank_index].animations[anim_index] != null)
            {
                animMontreal = null;
                animLargo = null;
                animationSpeed = state.speed;
                //animationSpeed = state.speed;
                InitAnimation(l.animationBanks[bank_index].animations[anim_index]);
                UpdateAnimation();
            }
            else if (state.anim_ref != null && state.anim_ref.a3d != null)
            {
                animMontreal = null;
                animLargo = null;
                animationSpeed = state.speed;
                InitAnimation(state.anim_ref.a3d);
                UpdateAnimation();
            }
            else if (state.anim_ref != null && state.anim_ref.a3dLargo != null)
            {
                animMontreal = null;
                a3d = null;
                animationSpeed = state.speed;
                InitAnimationLargo(state.anim_ref.a3dLargo);
                UpdateAnimation();
            }
            else
            {
                a3d = null;
            }
        }
    }
}
