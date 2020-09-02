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
            return NormalGeometricObjectElementTrianglesVerticesFetcher.DeriveFor(geometricObjectElementTriangles);
        }

        public List<Vector3d> GetNormals()
        {
            return NormalGeometricObjectElementTrianglesNormalsFetcher.DeriveFor(geometricObjectElementTriangles);
        }

        public string GetMaterialHash()
        {
            return NormalGeometricObjectElementTrianglesMaterialHashFetcher.DeriveFor(geometricObjectElementTriangles);
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
            return NormalGeometricObjectElementTrianglesBoneWeightsFetcher.DeriveFor(geometricObjectElementTriangles);
        }

        public Dictionary<int, BoneBindPose> GetBindBonePoses()
        {
            return NormalGeometricObjectElementTrianglesBindBonePosesFetcher.DeriveFor(geometricObjectElementTriangles);
        }

        public List<int> GetTriangles()
        {
            return NormalGeometricObjectElementTrianglesTrianglesFetcher.DeriveFor(geometricObjectElementTriangles);
        }

        public List<List<Vector2d>> GetUvMaps()
        {
            return NormalGeometricObjectElementTrianglesUvMapsFetcher.DeriveFor(geometricObjectElementTriangles);
        }
    }
}
