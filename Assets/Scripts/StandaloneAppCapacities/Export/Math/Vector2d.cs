using Assets.Scripts.ResourcesModel.Math;
using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.Math
{
    public struct Vector2d : IExportModel, Vector
    {
        public float x;
        public float y;

        public Vector2d(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
        }

        public static Vector2d FromResourcesModelVector2(Vector2 vector2)
        {
            return new Vector2d(vector2.x, vector2.y);
        }
    }
}
