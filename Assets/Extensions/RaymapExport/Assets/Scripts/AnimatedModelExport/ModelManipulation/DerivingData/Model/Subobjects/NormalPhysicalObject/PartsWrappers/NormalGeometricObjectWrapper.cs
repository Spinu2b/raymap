using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers.InterfaceWrappers;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers
{
    public class NormalGeometricObjectWrapper
    {
        private GeometricObject geometricObject;
        private EnvironmentContext environmentContext;

        public NormalGeometricObjectWrapper(GeometricObject geometricObject, EnvironmentContext environmentContext)
        {
            this.geometricObject = geometricObject;
            this.environmentContext = environmentContext;
        }

        public IEnumerable<Tuple<int, IGeometricObjectElementWrapper>> IterateIGeometricObjectElements()
        {
            int index = 0;
            foreach (var geometricObjectElement in geometricObject.elements)
            {
                if (geometricObjectElement != null)
                {
                    yield return new Tuple<int, IGeometricObjectElementWrapper>(index, new IGeometricObjectElementWrapper(geometricObjectElement, environmentContext));
                }
                index++;
            }
        }
    }
}
