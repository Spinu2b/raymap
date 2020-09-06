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
            throw new NotImplementedException();
        }
    }
}
