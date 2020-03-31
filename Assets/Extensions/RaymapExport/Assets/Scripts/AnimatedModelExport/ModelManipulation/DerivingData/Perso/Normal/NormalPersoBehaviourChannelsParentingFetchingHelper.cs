using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourChannelsParentingFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourChannelsParentingFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        public Dictionary<int, int> GetPersoBehaviourChannelsParentingForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetChannelsParentingForNormalAnimation();
            }
            else if (IsMontrealAnimation())
            {
                return GetChannelsParentingForMontrealAnimation();
            }
            else if (IsLargoAnimation())
            {
                return GetChannelsParentingForLargoAnimation();
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private Dictionary<int, int> GetChannelsParentingForLargoAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, int> GetChannelsParentingForMontrealAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, int> GetChannelsParentingForNormalAnimation()
        {
            throw new NotImplementedException();
        }
    }
}
