using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers.InterfaceWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers
{
    public class NormalPhysicalObjectWrapper
    {
        private OpenSpace.Object.PhysicalObject physicalObject;

        public NormalPhysicalObjectWrapper(OpenSpace.Object.PhysicalObject physicalObject)
        {
            this.physicalObject = physicalObject;
        }

        public IEnumerable<Tuple<int, IGeometricObjectWrapper>> IterateIGeometricObjects()
        {
            throw new NotImplementedException();
        }
    }
}
