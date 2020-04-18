using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription
{
    public struct Quaternion : IExportModel, ISerializableToBytes
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

        public bool RoundEquals(Quaternion other)
        {
            return NumberUtils.RoundEquals(w, other.w) && NumberUtils.RoundEquals(x, other.x) && NumberUtils.RoundEquals(y, other.y) &&
                NumberUtils.RoundEquals(z, other.z);
        }

        public byte[] SerializeToBytes()
        {
            return BitConverter.GetBytes(w).Concat(BitConverter.GetBytes(x)).Concat(BitConverter.GetBytes(y)).Concat(BitConverter.GetBytes(z)).ToArray();
        }
    }
}
