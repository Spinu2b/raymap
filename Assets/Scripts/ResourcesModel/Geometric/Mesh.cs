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
            if (unityMesh != null)
            {
                var result = new Mesh();
                result.vertices = unityMesh.vertices.Select(x => Vector3.FromUnityVector3(x)).ToArray();
                result.normals = unityMesh.normals.Select(x => Vector3.FromUnityVector3(x)).ToArray();
                result.boneWeights = unityMesh.boneWeights.Select(x => BoneWeight.FromUnityBoneWeight(x)).ToArray();
                result.bindposes = unityMesh.bindposes.Select(x => Matrix4x4.FromUnityMatrix4x4(x)).ToArray();
                result.triangles = unityMesh.triangles.ToArray();
                return result;
            } else
            {
                throw new ArgumentException("Unity Mesh object provided is null in here!");
            }            
        }
    }
}
