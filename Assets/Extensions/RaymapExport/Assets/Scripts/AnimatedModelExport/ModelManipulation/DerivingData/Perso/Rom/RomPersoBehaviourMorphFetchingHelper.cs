using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoBehaviourMorphFetchingHelper : RomPersoBehaviourAnimationDataFetchingHelper
    {
        public RomPersoBehaviourMorphFetchingHelper(ROMPersoBehaviour romPersoBehaviour) : base(romPersoBehaviour) {}

        public List<Tuple<int, int, int>> GetPersoBehaviourMorphDataForFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
