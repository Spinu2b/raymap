using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription
{
    public struct Vector4d : IExportModel, ISerializableToBytes, Vector
    {
        public float x, y, z, w;
        public Vector4d(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
        }
    }
}
