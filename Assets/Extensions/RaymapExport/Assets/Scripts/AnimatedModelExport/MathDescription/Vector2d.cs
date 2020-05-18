using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription
{
    public struct Vector2d : IExportModel, ISerializableToBytes
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

        public bool RoundEquals(Vector2d other)
        {
            return NumberUtils.RoundEquals(x, other.x) && NumberUtils.RoundEquals(y, other.y);
        }

        public byte[] SerializeToBytes()
        {
            return BitConverter.GetBytes(x).Concat(BitConverter.GetBytes(y)).ToArray();
        }
    }
}
