using Assets.Scripts.ResourcesModel.Geometric;
using Assets.Scripts.ResourcesModel.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel
{
    public class Mesh
    {
        public Vector3[] vertices { get; set; }
        public Vector3[] normals { get; set; }
        public BoneWeight[] boneWeights { get; set; }
        public Matrix4x4[] bindposes { get; set; }
        public int[] triangles { get; set; }

        public static Mesh FromUnityMesh(UnityEngine.Mesh unityMesh)
        {
            throw new NotImplementedException();
        }
    }
}
