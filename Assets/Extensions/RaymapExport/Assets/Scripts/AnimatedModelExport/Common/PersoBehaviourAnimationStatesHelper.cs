using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Common
{
    public class PersoBehaviourAnimationStatesHelper
    {
        public PersoBehaviourInterface persoBehaviourInterface { get; private set; }

        public PersoBehaviourAnimationStatesHelper(PersoBehaviourInterface persoBehaviourInterface)
        {
            this.persoBehaviourInterface = persoBehaviourInterface;
        }

        public void SwitchToFirstAnimationState()
        {
            throw new NotImplementedException();
        }

        public bool AreValidPersoAnimationStatesLeftIncludingCurrentOne()
        {
            throw new NotImplementedException();
        }

        public bool AreFramesLeftForCurrentAnimationStateStartingWithFrameNumber(int currentFrameNumber)
        {
            throw new NotImplementedException();
        }

        public int GetStateAnimationNextFrameNumberAfter(int currentFrameNumber)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentPersoStateIndex()
        {
            throw new NotImplementedException();
        }

        public void AcquireNextValidPersoAnimationState()
        {
            throw new NotImplementedException();
        }

        public int GetFirstValidStateAnimationKeyframeFrameNumber()
        {
            throw new NotImplementedException();
        }
    }
}
