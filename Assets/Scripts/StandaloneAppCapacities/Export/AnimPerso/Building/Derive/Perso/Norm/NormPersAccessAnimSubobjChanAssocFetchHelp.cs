using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm
{
    public class NormalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper : NormalPersoAccessorAnimationDataFetchingHelper
    {
        public NormalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper(NormalPersoAccessor normalPersoAccessor) : base(normalPersoAccessor)
        {
        }

        private SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForNormalFrame()
        {
            return NormalPersoNormalFrameSubobjectsChannelsAssociationDataFetcher.DeriveFor(normalPersoAccessor);
        }

        private SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForLargoFrame()
        {
            throw new NotImplementedException();
        }

        private SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForMontrealFrame()
        {
            throw new NotImplementedException();
        }

        public SubobjectsChannelsAssociation GetPersoBehaviourSubobjectsChannelsAssociationForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetSubobjectsChannelsAssociationForNormalFrame();
            }
            else if (IsMontrealAnimation())
            {
                return GetSubobjectsChannelsAssociationForMontrealFrame();
            }
            else if (IsLargoAnimation())
            {
                return GetSubobjectsChannelsAssociationForLargoFrame();
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }
    }
}
