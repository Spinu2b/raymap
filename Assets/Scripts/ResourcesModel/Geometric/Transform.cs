using Assets.Scripts.ResourcesModel.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Geometric
{
    public class Transform
    {
        public Matrix4x4 worldToLocalMatrix { 
            get
            {
                throw new NotImplementedException();
            }
        }

        public Matrix4x4 localToWorldMatrix { 
            get
            {
                throw new NotImplementedException();
            }
        }

        public static Transform GetUnityHomeTransformedGameObjectTransformMock()
        {
            throw new NotImplementedException();
        }
    }
}
