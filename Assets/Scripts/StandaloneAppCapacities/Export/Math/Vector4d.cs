using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.Export.Math
{
    public struct Vector4d : IExportModel, Vector
    {
        public float x, y, z, w;
        public Vector4d(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public byte[] SerializeToBytes()
        {
            return BitConverter.GetBytes(x).Concat(BitConverter.GetBytes(y)).Concat(BitConverter.GetBytes(z)).Concat(BitConverter.GetBytes(w)).ToArray();
        }

        public static Vector4d FromUnityVector4(Vector4 unityVector4)
        {
            return new Vector4d(unityVector4.x, unityVector4.y, unityVector4.z, unityVector4.w);
        }
    }
}
