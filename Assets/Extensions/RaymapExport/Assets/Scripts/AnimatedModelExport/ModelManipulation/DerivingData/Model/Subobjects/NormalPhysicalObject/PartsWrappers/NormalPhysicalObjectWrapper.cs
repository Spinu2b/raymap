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
        private EnvironmentContext environmentContext;

        public NormalPhysicalObjectWrapper(OpenSpace.Object.PhysicalObject physicalObject, EnvironmentContext environmentContext)
        {
            this.physicalObject = physicalObject;
            this.environmentContext = environmentContext;
        }

        public IEnumerable<Tuple<int, IGeometricObjectWrapper>> IterateIGeometricObjects()
        {
            int index = 0;
            foreach (var visualSetLOD in physicalObject.visualSet)
            {
                if (visualSetLOD.obj != null)
                {
                    yield return new Tuple<int, IGeometricObjectWrapper>(
                        index, new IGeometricObjectWrapper(visualSetLOD.obj, environmentContext));
                }                
                index++;
            }
        }
    }
}
