using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.MeshGeometryConstr
{
    public class SkinMeshGeometryFactory : BonesDataManipFactory
    {
        BonesWeightsHelper boneWeightsHelper = new BonesWeightsHelper();

        public MeshGeometry ConstructFor(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            Mesh mesh = GetMesh(physicalObjectSubmeshObject);
            UnityBoneTransformModel[] bones = GetUnityMappedBones(physicalObjectSubmeshObject);
            UnityBoneWeightModel[] boneWeights = GetUnityMappedBoneWeights(physicalObjectSubmeshObject);

            var result = new MeshGeometry();
            result.vertices = GetVerticesList(mesh.vertices);
            result.triangles = MeshDataHelper.GetTrianglesList(mesh.triangles);
            result.bonesWeights = GetBonesWeights(boneWeights, bones);
            result.normals = MeshDataHelper.GetNormals(mesh.normals);
            result.uvMaps = MeshDataHelper.GetUvMaps(mesh);
            return result;
        }

        private UnityBoneWeightModel[] GetUnityMappedBoneWeights(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            return physicalObjectSubmeshObject.GetUnityMappedBoneWeights();
        }

        private Dictionary<string, Dictionary<int, float>> GetBonesWeights(UnityBoneWeightModel[] boneWeights, UnityBoneTransformModel[] bones)
        {
            var result = new Dictionary<string, Dictionary<int, float>>();
            foreach (var weights in boneWeightsHelper.IterateBonesWeights(boneWeights, bones))
            {
                result.Add(weights.BoneName, weights.Weights);
            }
            return result;
        }

        private List<Vector3d> GetVerticesList(Vector3[] vertices)
        {
            return vertices.Select(x => new Vector3d(x.x, x.y, x.z)).ToList();
        }

        private Mesh GetMesh(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            return physicalObjectSubmeshObject.GetMesh();
        }
    }
}
