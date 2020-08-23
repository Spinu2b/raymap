using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch
{
    public static class NormalGeometricObjectElementTrianglesVisualDataFetcher
    {
        public static VisualDataHelper DeriveFor(
            GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            if (geometricObjectElementTriangles.visualMaterial != null)
            {
                VisualMaterial.Hint materialHints = geometricObjectElementTriangles.geo.lookAtMode != 0 ?
                    VisualMaterial.Hint.Billboard : VisualMaterial.Hint.None;
                return geometricObjectElementTriangles.visualMaterial.ForExportGetMaterial();
            } else
            {
                throw new InvalidOperationException("This geometric object element triangles has null visual material!");
            }
        }
    }
}
