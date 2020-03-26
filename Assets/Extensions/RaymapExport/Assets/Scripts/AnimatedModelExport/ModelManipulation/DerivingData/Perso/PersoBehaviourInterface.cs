using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class PersoBehaviourInterface
    {
        private PersoBehaviour persoBehaviour;
        private ROMPersoBehaviour romPersoBehaviour;

        public GameObject gameObject
        {
            get
            {
                if (persoBehaviour != null)
                {
                    return persoBehaviour.gameObject;
                }
                else
                {
                    return romPersoBehaviour.gameObject;
                }
            }
        }

        public int currentAnimationFrame
        {
            set
            {
                if (persoBehaviour != null)
                {
                    persoBehaviour.currentFrame = (uint)value;
                }
                else
                {
                    throw new NotSupportedException("Setting current animation frame number not supported for ROM Perso Behaviour!");
                }
            }
        }

        public int statesCount
        {
            get
            {
                if (persoBehaviour != null)
                {
                    return persoBehaviour.perso.p3dData.family.states.Count;
                }
                else
                {
                    throw new NotSupportedException("States count currently not supported for ROM Perso Behaviour!");
                }
            }
        }

        public void UpdateAnimation()
        {
            if (persoBehaviour != null)
            {
                persoBehaviour.UpdateAnimation();
            }
            else
            {
                romPersoBehaviour.UpdateAnimation();
            }
        }

        public bool GetChannelOfIndexKeyframeState(int channelIndex)
        {
            throw new NotImplementedException();
        }

        public int currentAnimationStateFramesCount
        {
            get
            {
                if (persoBehaviour != null)
                {
                    return persoBehaviour.a3d.num_onlyFrames;
                }
                else
                {
                    throw new NotSupportedException("Animation state frames count currently not supported for ROM Perso Behaviour!");
                }
            }
        }

        public PersoBehaviourInterface(PersoBehaviour persoBehaviour)
        {
            this.persoBehaviour = persoBehaviour;
        }

        public PersoBehaviourInterface(ROMPersoBehaviour romPersoBehaviour)
        {
            this.romPersoBehaviour = romPersoBehaviour;
        }

        public void SetState(int stateIndex)
        {
            if (persoBehaviour != null)
            {
                persoBehaviour.SetState(stateIndex);
            }
            else
            {
                romPersoBehaviour.SetState(stateIndex);
            }
        }

        public bool IsValidAnimationState(int animationStateIndex)
        {
            throw new NotImplementedException();
        }
    }
}
