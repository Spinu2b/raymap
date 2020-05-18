using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoBehaviourChannelsParentingFetchingHelper : RomPersoBehaviourAnimationDataFetchingHelper
    {
        public RomPersoBehaviourChannelsParentingFetchingHelper(ROMPersoBehaviour romPersoBehaviour) : base(romPersoBehaviour) {}

        public Dictionary<int, int> GetPersoBehaviourChannelsParentingForFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
