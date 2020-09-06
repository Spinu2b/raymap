using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Math
{
    public struct Vector2
    {
        public float x;
        public float y;

        public static Vector2 FromUnityVector2(UnityEngine.Vector2 unityVector2)
        {
            var result = new Vector2();
            result.x = unityVector2.x;
            result.y = unityVector2.y;
            return result;
        }
    }
}
