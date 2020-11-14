using Assets.Scripts.ResourcesModel.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Geometric
{
    public abstract class MeshBase
    {
        public Vector3[] vertices { get; set; }
        public Vector3[] normals { get; set; }
        public BoneWeight[] boneWeights { get; set; }
        public int[] triangles { get; set; }

        public Vector2[] uv { get; set; }
        public Vector2[] uv2 { get; set; }
        public Vector2[] uv3 { get; set; }
        public Vector2[] uv4 { get; set; }
        public Vector2[] uv5 { get; set; }
        public Vector2[] uv6 { get; set; }
        public Vector2[] uv7 { get; set; }
        public Vector2[] uv8 { get; set; }

        public UnityEngine.Vector3[] verticesUnity { get { throw new InvalidOperationException(); } set { throw new NotImplementedException(); } }
        public UnityEngine.Vector3[] normalsUnity { get { throw new InvalidOperationException(); } set { throw new NotImplementedException(); } }
        public UnityEngine.BoneWeight[] boneWeightsUnity { get { throw new InvalidOperationException(); } set { throw new NotImplementedException(); } }

        public void GetUVsUnity(int uvListIndex, List<UnityEngine.Vector3> uvContainer)
        {
            throw new NotImplementedException();
        }

        public void SetUVsUnity(int uvListIndex, UnityEngine.Vector3[] uv)
        {
            throw new NotImplementedException();
        }

        public void SetUVsUnity(int uvListIndex, List<UnityEngine.Vector3> uv)
        {
            throw new NotImplementedException();
        }

        public void SetUVsUnity(int uvListIndex, List<UnityEngine.Vector4> uv)
        {
            throw new NotImplementedException();
        }
    }
}
