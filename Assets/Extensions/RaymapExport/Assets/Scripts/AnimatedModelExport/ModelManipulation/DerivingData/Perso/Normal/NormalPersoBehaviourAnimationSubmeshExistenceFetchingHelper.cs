using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourAnimationSubmeshExistenceFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourAnimationSubmeshExistenceFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        public List<string> GetPersoBehaviourSubmeshExistenceDataForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetSubmeshExistenceDataForNormalAnimation(frameNumber);
            }
            else if (IsMontrealAnimation())
            {
                return GetSubmeshExistenceDataForMontrealAnimation(frameNumber);
            }
            else if (IsLargoAnimation())
            {
                return GetSubmeshExistenceDataForLargoAnimation(frameNumber);
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private List<string> GetSubmeshExistenceDataForLargoAnimation(int frameNumber)
        {
            throw new NotImplementedException();
        }

        private List<string> GetSubmeshExistenceDataForMontrealAnimation(int frameNumber)
        {
            throw new NotImplementedException();
        }

        private List<string> GetSubmeshExistenceDataForNormalAnimation(int frameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
