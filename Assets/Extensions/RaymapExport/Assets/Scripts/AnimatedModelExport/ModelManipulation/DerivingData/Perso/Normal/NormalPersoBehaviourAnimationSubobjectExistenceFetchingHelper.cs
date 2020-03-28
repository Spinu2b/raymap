using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourAnimationSubobjectExistenceFetchingHelper : NormalPersoBehaviourAnimationSubobjectDataFetchingHelper
    {
        public NormalPersoBehaviourAnimationSubobjectExistenceFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        public List<string> GetPersoBehaviourSubobjectExistenceDataForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetSubobjectExistenceDataForNormalAnimation(frameNumber);
            }
            else if (IsMontrealAnimation())
            {
                return GetSubobjectExistenceDataForMontrealAnimation(frameNumber);
            }
            else if (IsLargoAnimation())
            {
                return GetSubobjectExistenceDataForLargoAnimation(frameNumber);
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private List<string> GetSubobjectExistenceDataForLargoAnimation(int frameNumber)
        {
            var result = new List<string>();
            foreach (SubobjectModel subobject in IterateActualPhysicalSubobjectsForLargoFrame(frameNumber))
            {
                result.Add(subobject.name);
            }
            return result;
        }

        private List<string> GetSubobjectExistenceDataForMontrealAnimation(int frameNumber)
        {
            var result = new List<string>();
            foreach (SubobjectModel subobject in IterateActualPhysicalSubobjectsForMontrealFrame(frameNumber))
            {
                result.Add(subobject.name);
            }
            return result;
        }

        private List<string> GetSubobjectExistenceDataForNormalAnimation(int frameNumber)
        {
            var result = new List<string>();
            foreach (SubobjectModel subobject in IterateActualPhysicalSubobjectsForNormalFrame(frameNumber))
            {
                result.Add(subobject.name);
            }
            return result;
        }
    }
}
