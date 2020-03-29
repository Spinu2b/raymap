using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription
{
    public struct Quaternion
    {
        public float w;
        public float x;
        public float y;
        public float z;

        public Quaternion(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Quaternion FromUnityQuaternion(UnityEngine.Quaternion quaternion)
        {
            return new Quaternion(quaternion.w, quaternion.x, quaternion.y, quaternion.z);
        }
    }
}
