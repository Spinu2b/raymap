using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.Export.Math
{
    public struct Vector3d : IExportModel, Vector
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

        public static Vector3d FromResourcesModelVector3(ResourcesModel.Math.Vector3 vector3)
        {
            throw new NotImplementedException();
        }
    }
}
