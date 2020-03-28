using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class SubobjectsCache
    {
        private Dictionary<int, Dictionary<int, List<string>>> subobjectsAnimationFramesPersoStatesAssociationsCache
             = new Dictionary<int, Dictionary<int, List<string>>>();
        private Dictionary<string, SubobjectModel> subobjectsCache = new Dictionary<string, SubobjectModel>();

        public bool ContainsPhysicalObject(PhysicalObject physicalObject)
        {
            throw new NotImplementedException();
        }

        public void AddPhysicalObject(PhysicalObject physicalObject)
        {
            throw new NotImplementedException();
        }

        public SubobjectModel GetPhysicalObjectCachedModelFor(PhysicalObject physicalObject)
        {
            throw new NotImplementedException();
        }
    }
}
