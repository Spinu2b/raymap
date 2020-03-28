using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourAnimationSubobjectDataFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        private Dictionary<int, Dictionary<int, List<string>>> subobjectsAnimationFramesPersoStatesAssociationsCache
            = new Dictionary<int, Dictionary<int, List<string>>>();
        private Dictionary<string, SubobjectModel> subobjectsCache = new Dictionary<string, SubobjectModel>();

        public NormalPersoBehaviourAnimationSubobjectDataFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        public IEnumerable<SubobjectModel> IterateActualPhysicalSubobjectsForNormalFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubobjectModel> IterateActualPhysicalSubobjectsForLargoFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubobjectModel> IterateActualPhysicalSubobjectsForMontrealFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
