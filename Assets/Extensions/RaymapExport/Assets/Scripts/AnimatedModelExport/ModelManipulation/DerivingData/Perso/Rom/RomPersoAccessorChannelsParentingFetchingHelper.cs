using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Rom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoAccessorChannelsParentingFetchingHelper : RomPersoAccessorAnimationDataFetchingHelper
    {
        public RomPersoAccessorChannelsParentingFetchingHelper(RomPersoAccessor romPersoAccessor) : base(romPersoAccessor)
        {
        }

        public Dictionary<int, int> GetPersoBehaviourChannelsParentingForFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
