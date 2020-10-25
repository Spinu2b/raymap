using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Conv
{
    public static class NormalGeometricObjectElementTrianglesToSubobjectModelConverter
    {
        public static Subobject Convert(int objectNumber, NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTriangles)
        {
            var result = new Subobject();
            result.objectNumber = objectNumber;
            result.geometricObject = GetGeometricObject(geometricObjectElementTriangles);
            return result;
        }

        private static GeometricObject GetGeometricObject(NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTriangles)
        {
            var result = new GeometricObject();

            var geo = geometricObjectElementTriangles.getGeometricObjectElementTriangles();

            result.vertices = geometricObjectElementTriangles.GetVertices();
            result.normals = geometricObjectElementTriangles.GetNormals();
            result.material = geometricObjectElementTriangles.GetMaterialHash();
            result.boneWeights = geometricObjectElementTriangles.GetBoneWeights();
            result.bindBonePoses = geometricObjectElementTriangles.GetBindBonePoses();
            result.triangles = geometricObjectElementTriangles.GetTriangles();
            result.uvMaps = geometricObjectElementTriangles.GetUvMaps();
            return result;
        }
    }
}
