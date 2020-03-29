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

        public IEnumerable<Tuple<int, GeometricObjectWrapper>> IterateGeometricObjects()
        {
            if (physicalObject != null)
            {
                int index = 0;
                foreach (var visualSetLOD in physicalObject.visualSet)
                {
                    yield return new Tuple<int, GeometricObjectWrapper>(index, new GeometricObjectWrapper(visualSetLOD.obj));
                    index++;
                }
            } else
            {
                throw new NotImplementedException("Not implemented handling of other physical objects!");
            }
        }
    }
}
