using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Cache
{
    public class ComparableModelPersoAnimationStatesCache<IdentifierType, T> where T : IComparableModel<T>
    {
        private Dictionary<int, Dictionary<int, List<IdentifierType>>> modelAnimationFramesPersoStatesAssociationsCache
             = new Dictionary<int, Dictionary<int, List<IdentifierType>>>();
        private Dictionary<IdentifierType, T> modelCache = new Dictionary<IdentifierType, T>();

        public void ConsiderModelObject(T modelObject, IdentifierType modelObjectIdentifier, int stateIndex, int animationFrame)
        {

        }
    }
}
