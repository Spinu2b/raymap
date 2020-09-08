using Assets.Scripts.ResourcesModel.Math;
using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.Math
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

        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
        }

        public static Quaternion FromResourcesModelQuaternion(ResourcesModel.Math.Quaternion quaternion)
        {
            throw new NotImplementedException();
        }

        public static Quaternion FromUnityQuaternion(UnityEngine.Quaternion quaternion)
        {
            return new Quaternion(quaternion.w, quaternion.x, quaternion.y, quaternion.z);
        }
    }
}
