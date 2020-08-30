using Assets.Scripts.Unity.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.Math
{
    public struct Vector3d : IExportModel, ISerializableToBytes, Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector3d(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
        }
    }
}
