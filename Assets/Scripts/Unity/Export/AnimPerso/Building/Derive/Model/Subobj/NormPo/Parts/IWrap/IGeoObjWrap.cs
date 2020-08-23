using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts.IWrap
{
    public class IGeometricObjectWrapper
    {
        private IGeometricObject obj;

        public IGeometricObjectWrapper(IGeometricObject obj)
        {
            this.obj = obj;
        }

        public bool IsNormalGeometricObject()
        {
            return obj is GeometricObject;
        }

        public NormalGeometricObjectWrapper GetNormalGeometricObject()
        {
            return new NormalGeometricObjectWrapper(obj as GeometricObject);
        }
    }
}
