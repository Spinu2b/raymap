using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription
{
    public struct Vector2d
    {
        public float x, y;
        public Vector2d(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2d FromUnityVector2(Vector2 vector)
        {
            return new Vector2d(vector.x, vector.y);
        }
    }
}
