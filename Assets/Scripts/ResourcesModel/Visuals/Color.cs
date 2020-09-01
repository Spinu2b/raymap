using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Visuals
{
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public static Color FromUnityColorStruct(UnityEngine.Color x)
        {
            return new Color(x.r, x.g, x.b, x.a);
        }
    }
}
