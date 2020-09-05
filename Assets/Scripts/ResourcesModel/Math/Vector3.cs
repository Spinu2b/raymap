using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Math
{
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public static Vector3 FromUnityVector3(UnityEngine.Vector3 unityVector3)
        {
            var result = new Vector3();
            result.x = unityVector3.x;
            result.y = unityVector3.y;
            result.z = unityVector3.z;
            return result;
        }
    }
}
