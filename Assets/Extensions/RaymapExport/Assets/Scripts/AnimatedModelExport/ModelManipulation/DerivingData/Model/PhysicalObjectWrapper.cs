using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model
{
    public class PhysicalObjectWrapper
    {
        private PhysicalObject physicalObject;

        public PhysicalObjectWrapper(PhysicalObject physicalObject)
        {
            this.physicalObject = physicalObject;
        }

        public IEnumerable<GeometricObjectWrapper> IterateGeometricObjects()
        {
            throw new NotImplementedException();
        }
    }
}
