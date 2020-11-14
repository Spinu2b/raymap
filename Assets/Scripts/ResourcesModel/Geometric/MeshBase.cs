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
        public Vector3[] vertices { get; set; } = new Vector3[] { };
        public Vector3[] normals { get; set; } = new Vector3[] { };
        public BoneWeight[] boneWeights { get; set; } = new BoneWeight[] { };
        public int[] triangles { get; set; } = new int[] { };

        public Vector2[] uv { get; set; } = new Vector2[] { };
        public Vector2[] uv2 { get; set; } = new Vector2[] { };
        public Vector2[] uv3 { get; set; } = new Vector2[] { };
        public Vector2[] uv4 { get; set; } = new Vector2[] { };
        public Vector2[] uv5 { get; set; } = new Vector2[] { };
        public Vector2[] uv6 { get; set; } = new Vector2[] { };
        public Vector2[] uv7 { get; set; } = new Vector2[] { };
        public Vector2[] uv8 { get; set; } = new Vector2[] { };

        public UnityEngine.Vector3[] verticesUnity {
            get {
                throw new InvalidOperationException();
            } 
            set {
                vertices = value.Select(x => Vector3.FromUnityVector3(x)).ToArray();
            }
        }
        public UnityEngine.Vector3[] normalsUnity {
            get {
                throw new InvalidOperationException();
            } 
            set {
                normals = value.Select(x => Vector3.FromUnityVector3(x)).ToArray();
            }
        }
        public UnityEngine.BoneWeight[] boneWeightsUnity {
            get {
                throw new InvalidOperationException();
            } 
            set {
                boneWeights = value.Select(x => BoneWeight.FromUnityBoneWeight(x)).ToArray();
            }
        }

        public void GetUVsUnity(int uvListIndex, List<UnityEngine.Vector3> uvContainer)
        {
            List<Vector2> uv = GetUvListOfIndex(uvListIndex);
        }

        public void SetUVsUnity(int uvListIndex, UnityEngine.Vector3[] uv)
        {
            SetUVsSimplifiedUnifiedModel(uvListIndex, uv.Select(x => new Vector2(x.x, x.y)).ToList());
        }

        public void SetUVsUnity(int uvListIndex, List<UnityEngine.Vector3> uv)
        {
            SetUVsSimplifiedUnifiedModel(uvListIndex, uv.Select(x => new Vector2(x.x, x.y)).ToList());
        }

        public void SetUVsUnity(int uvListIndex, List<UnityEngine.Vector4> uv)
        {
            SetUVsSimplifiedUnifiedModel(uvListIndex, uv.Select(x => new Vector2(x.x, x.y)).ToList());
        }

        private void SetUVsSimplifiedUnifiedModel(int uvListIndex, List<Vector2> uv)
        {
            if (uvListIndex == 0)
            {
                this.uv = uv.ToArray();
            }
            else if (uvListIndex == 1)
            {
                this.uv2 = uv.ToArray();
            }
            else if (uvListIndex == 2)
            {
                this.uv3 = uv.ToArray();
            }
            else if (uvListIndex == 3)
            {
                this.uv4 = uv.ToArray();
            }
            else if (uvListIndex == 4)
            {
                this.uv5 = uv.ToArray();
            }
            else if (uvListIndex == 5)
            {
                this.uv6 = uv.ToArray();
            }
            else if (uvListIndex == 6)
            {
                this.uv7 = uv.ToArray();
            }
            else if (uvListIndex == 7)
            {
                this.uv8 = uv.ToArray();
            } else
            {
                throw new ArgumentException(string.Format("Wrong uvListIndexPassed in: {0}", uvListIndex));
            }
        }

        private List<Vector2> GetUvListOfIndex(int uvListIndex)
        {
            if (uvListIndex == 0)
            {
                return this.uv.ToList();
            }
            else if (uvListIndex == 1)
            {
                return this.uv2.ToList();
            }
            else if (uvListIndex == 2)
            {
                return this.uv3.ToList();
            }
            else if (uvListIndex == 3)
            {
                return this.uv4.ToList();
            }
            else if (uvListIndex == 4)
            {
                return this.uv5.ToList();
            }
            else if (uvListIndex == 5)
            {
                return this.uv6.ToList();
            }
            else if (uvListIndex == 6)
            {
                return this.uv7.ToList();
            }
            else if (uvListIndex == 7)
            {
                return this.uv8.ToList();
            }
            throw new ArgumentException(string.Format("Wrong uvListIndexPassed in: {0}", uvListIndex));
        }
    }
}
