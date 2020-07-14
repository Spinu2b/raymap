using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.Perso.Model.SubobjLibDesc
{
    public class GeometricObject
    {
        public List<Vector3d> vertices = new List<Vector3d>();
        public List<Vector3d> normals = new List<Vector3d>();
        public List<int> triangles = new List<int>();
        public List<List<Vector2d>> uvMaps = new List<List<Vector2d>>();
        public string material;

        public Dictionary<int, BoneBindPose> bindBonePoses = new Dictionary<int, BoneBindPose>();
        public Dictionary<int, Dictionary<int, float>> boneWeights = new Dictionary<int, Dictionary<int, float>>();
    }
}
