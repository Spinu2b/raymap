using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers.InterfaceWrappers
{
    public class IGeometricObjectElementWrapper
    {
        private IGeometricObjectElement geometricObjectElement;

        public IGeometricObjectElementWrapper(IGeometricObjectElement geometricObjectElement)
        {
            this.geometricObjectElement = geometricObjectElement;
        }

        public bool IsGeometricObjectElementTriangles()
        {
            return geometricObjectElement is GeometricObjectElementTriangles;
        }

        public GeometricObjectElementTrianglesWrapper GetGeometricObjectElementTriangles()
        {
            return new GeometricObjectElementTrianglesWrapper(geometricObjectElement as GeometricObjectElementTriangles);
        }
    }
}
