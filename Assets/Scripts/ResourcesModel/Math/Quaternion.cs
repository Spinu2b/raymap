using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Math
{
    public struct Quaternion
    {
        public float w;
        public float x;
        public float y;
        public float z;

        public Quaternion(float w = 1f, float x = 0f, float y = 0f, float z = 0f)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Quaternion LookRotation(Vector3 forward, Vector3 upwards)
        {
            throw new NotImplementedException();
        }

        public static Quaternion FromUnityQuaternion(UnityEngine.Quaternion unityQuaternion)
        {
            return new Quaternion(w: unityQuaternion.w, x: unityQuaternion.x, y: unityQuaternion.y, z: unityQuaternion.z);
        }
    }
}
