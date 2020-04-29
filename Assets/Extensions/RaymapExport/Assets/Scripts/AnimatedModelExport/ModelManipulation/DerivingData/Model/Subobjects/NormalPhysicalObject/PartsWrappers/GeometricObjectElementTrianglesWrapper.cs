using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers
{
    public class GeometricObjectElementTrianglesWrapper
    {
        private GeometricObjectElementTriangles geometricObjectElementTriangles;

        public GeometricObjectElementTrianglesWrapper(GeometricObjectElementTriangles geometricObjectElementTriangles)
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
            throw new NotImplementedException();
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
