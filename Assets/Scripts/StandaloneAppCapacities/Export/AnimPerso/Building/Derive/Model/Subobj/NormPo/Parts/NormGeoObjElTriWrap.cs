using Assets.Scripts.ResourcesModel;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Geometric.Trans;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch.NormGeoObjElTri;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.GeoObjDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts
{
    public static class NormalGeometricObjectElementTrianglesRightMeshFetcher
    {
        public static bool HasRightMesh(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            return geometricObjectElementTriangles.unityMeshModel != null;
        }

        public static Mesh GetRightMesh(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            return geometricObjectElementTriangles.unityMeshModel;
        }
    }

    public class NormalGeometricObjectElementTrianglesWrapper
    {
        private GeometricObjectElementTriangles geometricObjectElementTriangles;
        private VisualData visualData;

        public GeometricObjectElementTriangles getGeometricObjectElementTriangles()
        {
            return geometricObjectElementTriangles;
        }

        public NormalGeometricObjectElementTrianglesWrapper(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            this.geometricObjectElementTriangles = geometricObjectElementTriangles;
        }

        public bool IsAlphaTransparencyObject()
        {
            return NormalGeometricObjectElementTrianglesVisualDataFetcher.HasAlphaTransparencyMaterial(geometricObjectElementTriangles);
        }

        public List<Vector3d> GetVertices()
        {
            return NormalGeometricObjectElementTrianglesRightMeshFetcher.GetRightMesh(geometricObjectElementTriangles)
                .vertices.Select(x => Vector3d.FromResourcesModelVector3(x)).ToList();
        }

        public bool HasValidGeometricDataContained()
        {
            return NormalGeometricObjectElementTrianglesRightMeshFetcher.HasRightMesh(geometricObjectElementTriangles);
        }

        public List<Vector3d> GetNormals()
        {
            return NormalGeometricObjectElementTrianglesRightMeshFetcher.GetRightMesh(geometricObjectElementTriangles)
                .normals.Select(x => Vector3d.FromResourcesModelVector3(x)).ToList();
        }

        public string GetMaterialHash()
        {
            var visualData = GetVisualData();
            Material material = VisualDataHelper.GetOnlyPredictedObjectMaterial(visualData);
            return material.identifier;
        }

        public VisualData GetVisualData()
        {
            if (visualData == null)
            {
                visualData = NormalGeometricObjectElementTrianglesVisualDataFetcher.DeriveFor(geometricObjectElementTriangles);
            }
            return visualData;
        }

        public Dictionary<int, Dictionary<int, float>> GetBoneWeights()
        {
            return MiscellaneousGeometricDataToPersoDescriptionModelTransformer.TransformResourcesModelBonesWeightsToAnimatedPersoBoneWeightsExportModel(
                NormalGeometricObjectElementTrianglesRightMeshFetcher.GetRightMesh(geometricObjectElementTriangles).boneWeights);
        }

        public Dictionary<int, BoneBindPose> GetBindBonePoses()
        {
            return MiscellaneousGeometricDataToPersoDescriptionModelTransformer.TransformResourcesModelBindPosesToAnimatedPersoBindBonePosesExportModel(
                NormalGeometricObjectElementTrianglesRightMeshFetcher.GetRightMesh(geometricObjectElementTriangles).bindposes);
        }

        public List<int> GetTriangles()
        {
            return NormalGeometricObjectElementTrianglesRightMeshFetcher.GetRightMesh(geometricObjectElementTriangles).triangles.ToList();
        }

        public List<List<Vector2d>> GetUvMaps()
        {
            var result = new List<List<Vector2d>>();
            var appropriateMesh = NormalGeometricObjectElementTrianglesRightMeshFetcher.GetRightMesh(geometricObjectElementTriangles);

            result.Add(appropriateMesh.uv.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            result.Add(appropriateMesh.uv2.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            result.Add(appropriateMesh.uv3.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            result.Add(appropriateMesh.uv4.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            result.Add(appropriateMesh.uv5.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            result.Add(appropriateMesh.uv6.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            result.Add(appropriateMesh.uv7.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            result.Add(appropriateMesh.uv8.Select(x => Vector2d.FromResourcesModelVector2(x)).ToList());
            return result;
        }
    }
}
