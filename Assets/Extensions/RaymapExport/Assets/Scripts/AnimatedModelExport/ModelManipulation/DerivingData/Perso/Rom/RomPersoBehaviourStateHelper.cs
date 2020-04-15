using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoBehaviourStateHelper
    {
        private ROMPersoBehaviour romPersoBehaviour;

        public RomPersoBehaviourStateHelper(ROMPersoBehaviour romPersoBehaviour)
        {
            this.romPersoBehaviour = romPersoBehaviour;
        }

        public bool IsValidAnimationState(int animationStateIndex)
        {
            throw new NotImplementedException();
        }
    }
}
