using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.Converters
{
    public static class GeometricObjectElementTrianglesToSubobjectModelConverter
    {
        public static SubobjectModel Convert(
            int objectNumber, NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTriangles)
        {
            var result = new SubobjectModel();
            result.objectNumber = objectNumber;
            result.geometricObject = GetGeometricObject(geometricObjectElementTriangles);
            return result;
        }

        private static SubmeshGeometricObject GetGeometricObject(NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTriangles)
        {
            var result = new SubmeshGeometricObject();
            result.vertices = geometricObjectElementTriangles.GetVertices();
            result.normals = geometricObjectElementTriangles.GetNormals();
            result.materials = geometricObjectElementTriangles.GetMaterialsHashes();
            result.boneWeights = geometricObjectElementTriangles.GetBoneWeights();
            result.bindBonePoses = geometricObjectElementTriangles.GetBindBonePoses();
            result.triangles = geometricObjectElementTriangles.GetTriangles();
            result.uvMaps = geometricObjectElementTriangles.GetUvMaps();
            return result;
        }
    }
}
