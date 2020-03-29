using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription
{
    public struct Vector3d
    {
        public float x, y, z;
        public Vector3d(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3d FromUnityVector3(Vector3 vector)
        {
            return new Vector3d(vector.x, vector.y, vector.z);
        }
    }
}
