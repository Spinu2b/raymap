using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.RaymapModelFetching.GeometricObjectElementTriangles;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers
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
            throw new NotImplementedException();
        }

        public List<Vector3d> GetVertices()
        {
            throw new NotImplementedException();
        }

        public List<Vector3d> GetNormals()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMaterialsHashes()
        {
            VisualData visualData = GetVisualData();
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
