using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ResourcesModel.Math
{
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public float magnitude { 
            get {
                return Mathf.Sqrt(x*x + y*y + z*z + w*w);
            }
        }
    }
}
