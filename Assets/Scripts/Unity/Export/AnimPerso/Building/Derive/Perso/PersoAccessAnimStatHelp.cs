using Assets.Scripts.Unity.Export.AnimPerso.Model;
using Assets.Scripts.Unity.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.Unity.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Perso
{
    public class PersoAccessorAnimationStatesHelper
    {
        private PersoAccessor persoAccessor;

        public PersoAccessorAnimationStatesHelper(PersoAccessor persoAccessor)
        {
            this.persoAccessor = persoAccessor;
        }

        public void SwitchToFirstAnimationState()
        {
            throw new NotImplementedException();
        }

        public bool AreValidPersoAnimationStatesLeftIncludingCurrentOne()
        {
            throw new NotImplementedException();
        }

        public void AcquireNextValidPersoAnimationState()
        {
            throw new NotImplementedException();
        }

        public int GetCurrentPersoStateIndex()
        {
            throw new NotImplementedException();
        }

        public List<SubobjectUsedMorphAssociationInfo> GetMorphDataForThisAnimationState()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<int, SubobjectsChannelsAssociation>> IterateChannelSubobjectsAssociationsDataForThisAnimationState()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<int, Dictionary<int, int>>> IterateChannelParentingInfosForThisAnimationState()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<int, Dictionary<int, ChannelTransform>>> IterateKeyframeDataForThisAnimationState()
        {
            throw new NotImplementedException();
        }
    }
}
