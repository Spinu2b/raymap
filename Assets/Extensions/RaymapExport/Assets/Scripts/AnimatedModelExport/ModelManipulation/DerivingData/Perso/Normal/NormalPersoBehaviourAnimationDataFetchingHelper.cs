using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public abstract class NormalPersoBehaviourAnimationDataFetchingHelper
    {
        protected PersoBehaviour persoBehaviour;

        public NormalPersoBehaviourAnimationDataFetchingHelper(PersoBehaviour persoBehaviour)
        {
            this.persoBehaviour = persoBehaviour;
        }

        protected void UpdateAnimation(int frameNumber)
        {
            persoBehaviour.currentFrame = (uint)frameNumber;
            persoBehaviour.UpdateAnimation();
        }

        protected bool IsLargoAnimation()
        {
            return persoBehaviour.isLoaded && persoBehaviour.animLargo != null && persoBehaviour.channelObjects != null && persoBehaviour.subObjects != null;
        }

        protected bool IsMontrealAnimation()
        {
            return persoBehaviour.isLoaded && persoBehaviour.animMontreal != null && persoBehaviour.channelObjects != null & persoBehaviour.subObjects != null;
        }

        protected bool IsNormalAnimation()
        {
            return persoBehaviour.isLoaded && persoBehaviour.a3d != null && persoBehaviour.channelObjects != null & persoBehaviour.subObjects != null;
        }
    }
}
