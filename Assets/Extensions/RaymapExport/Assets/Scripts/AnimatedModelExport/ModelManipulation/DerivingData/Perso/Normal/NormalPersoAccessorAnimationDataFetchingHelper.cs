using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public abstract class NormalPersoAccessorAnimationDataFetchingHelper
    {
        protected NormalPersoAccessor normalPersoAccessor;

        public NormalPersoAccessorAnimationDataFetchingHelper(NormalPersoAccessor normalPersoAccessor)
        {
            this.normalPersoAccessor = normalPersoAccessor;
        }

        protected void UpdateAnimation(int frameNumber)
        {
            normalPersoAccessor.currentFrame = frameNumber;
            normalPersoAccessor.UpdateAnimation();
        }

        protected bool IsLargoAnimation()
        {
            //throw new NotImplementedException();
            return normalPersoAccessor.isLoaded && normalPersoAccessor.animLargo != null && normalPersoAccessor.channelObjects != null && normalPersoAccessor.subObjects != null;
        }

        protected bool IsMontrealAnimation()
        {
            //throw new NotImplementedException();
            return normalPersoAccessor.isLoaded && normalPersoAccessor.animMontreal != null && normalPersoAccessor.channelObjects != null & normalPersoAccessor.subObjects != null;
        }

        protected bool IsNormalAnimation()
        {
            //throw new NotImplementedException();
            return normalPersoAccessor.isLoaded && normalPersoAccessor.a3d != null && normalPersoAccessor.channelObjects != null & normalPersoAccessor.subObjects != null;
        }
    }
}
