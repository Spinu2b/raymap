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

        public NormalGeometricObjectElementTrianglesWrapper(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            this.geometricObjectElementTriangles = geometricObjectElementTriangles;
        }

        public bool IsAlphaTransparencyObject()
        {
            return VisualDataHelper.GetOnlyPredictedObjectMaterial(GetVisualData()).materialBaseClass == MaterialBaseClass.TRANSPARENT_MATERIAL;
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
            return NormalGeometricObjectElementTrianglesMaterialHashFetcher.DeriveFor(geometricObjectElementTriangles);
        }

        public void ReinitGeometricData()
        {
            geometricObjectElementTriangles.ReinitOnlyGeometricData();
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
            //in Unity model uv maps are stored as separate fields and we should compactify that into list of lists to be compliant with our model
            // so yeah, this one is to be implemented..

            throw new NotImplementedException();
            //return NormalGeometricObjectElementTrianglesRightMeshFetcher.GetRightMesh(geometricObjectElementTriangles).GetUvMaps();
        }
    }
}
