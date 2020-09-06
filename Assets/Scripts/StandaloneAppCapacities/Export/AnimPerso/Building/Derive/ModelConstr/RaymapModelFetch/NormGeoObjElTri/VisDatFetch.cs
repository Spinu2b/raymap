using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Extensions.Visual;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch.NormGeoObjElTri
{
    public static class NormalGeometricObjectElementTrianglesVisualDataFetcher
    {
        public static VisualData DeriveFor(
            GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            if (geometricObjectElementTriangles.visualMaterial != null)
            {
                VisualMaterial.Hint materialHints = geometricObjectElementTriangles.geo.lookAtMode != 0 ?
                    VisualMaterial.Hint.Billboard : VisualMaterial.Hint.None;
                return geometricObjectElementTriangles.visualMaterial.ForExportGetMaterialBasingOnTextures2D();
            } else
            {
                throw new InvalidOperationException("This geometric object element triangles has null visual material!");
            }
        }

        public static bool HasAlphaTransparencyMaterial(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            return (geometricObjectElementTriangles.visualMaterial.IsTransparent);
        }
    }
} 
