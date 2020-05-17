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
        private EnvironmentContext environmentContext;

        public IGeometricObjectElementWrapper(IGeometricObjectElement geometricObjectElement, EnvironmentContext environmentContext)
        {
            this.geometricObjectElement = geometricObjectElement;
            this.environmentContext = environmentContext;
        }

        public bool IsNormalGeometricObjectElementTriangles()
        {
            return geometricObjectElement is GeometricObjectElementTriangles;
        }

        public NormalGeometricObjectElementTrianglesWrapper GetNormalGeometricObjectElementTriangles()
        {
            return new NormalGeometricObjectElementTrianglesWrapper(geometricObjectElement as GeometricObjectElementTriangles, environmentContext);
        }
    }
}
