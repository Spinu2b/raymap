using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Rom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoAccessorStateHelper
    {
        private RomPersoAccessor romPersoAccessor;

        public RomPersoAccessorStateHelper(RomPersoAccessor romPersoAccessor)
        {
            this.romPersoAccessor = romPersoAccessor;
        }

        public bool IsValidAnimationState(int animationStateIndex)
        {
            throw new NotImplementedException();
        }
    }
}
