using Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc.GeoObjDesc;
using Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using Assets.Scripts.Unity.Export.Math;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts
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
            throw new NotImplementedException();
        }

        public List<Vector3d> GetNormals()
        {
            throw new NotImplementedException();
        }

        public string GetMaterialHash()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Dictionary<int, BoneBindPose> GetBindBonePoses()
        {
            throw new NotImplementedException();
        }

        public List<int> GetTriangles()
        {
            throw new NotImplementedException();
        }

        public List<List<Vector2d>> GetUvMaps()
        {
            throw new NotImplementedException();
        }
    }
}
