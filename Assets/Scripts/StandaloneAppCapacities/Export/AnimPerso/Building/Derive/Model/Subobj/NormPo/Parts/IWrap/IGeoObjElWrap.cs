using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts.IWrap
{
    public class IGeometricObjectElementWrapper
    {
        private IGeometricObjectElement geometricObjectElement;

        public IGeometricObjectElementWrapper(IGeometricObjectElement geometricObjectElement)
        {
            this.geometricObjectElement = geometricObjectElement;
        }

        public bool IsNormalGeometricObjectElementTriangles()
        {
            return geometricObjectElement is GeometricObjectElementTriangles;
        }

        public NormalGeometricObjectElementTrianglesWrapper GetNormalGeometricObjectElementTriangles()
        {
            return new NormalGeometricObjectElementTrianglesWrapper(geometricObjectElement as GeometricObjectElementTriangles);
        }
    }
}
