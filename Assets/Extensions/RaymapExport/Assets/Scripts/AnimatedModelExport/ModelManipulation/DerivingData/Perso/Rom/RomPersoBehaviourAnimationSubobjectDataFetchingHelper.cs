using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoBehaviourAnimationSubobjectDataFetchingHelper : RomPersoBehaviourAnimationDataFetchingHelper
    {
        public RomPersoBehaviourAnimationSubobjectDataFetchingHelper(ROMPersoBehaviour romPersoBehaviour) : base(romPersoBehaviour) {}

        public Tuple<SubobjectsChannelsAssociation, List<SubobjectModel>> GetPersoBehaviourSubobjectsUsedForFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public VisualData GetVisualDataForFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
