using Assets.Scripts.ResourcesModel.Geometric;
using Assets.Scripts.ResourcesModel.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel
{
    public class Mesh : MeshBase
    {
        public Matrix4x4[] bindposes { get; set; } = new Matrix4x4[] { };

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

                result.uv = unityMesh.uv.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                result.uv2 = unityMesh.uv2.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                result.uv3 = unityMesh.uv3.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                result.uv4 = unityMesh.uv4.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                result.uv5 = unityMesh.uv5.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                result.uv6 = unityMesh.uv6.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                result.uv7 = unityMesh.uv7.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                result.uv8 = unityMesh.uv8.Select(x => Vector2.FromUnityVector2(x)).ToArray();
                return result;
            } else
            {
                throw new ArgumentException("Unity Mesh object provided is null in here!");
            }            
        }
    }
}
