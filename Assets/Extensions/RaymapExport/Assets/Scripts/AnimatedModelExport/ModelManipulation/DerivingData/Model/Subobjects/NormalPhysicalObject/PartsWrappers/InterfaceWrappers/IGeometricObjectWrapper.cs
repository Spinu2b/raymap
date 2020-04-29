using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers.InterfaceWrappers
{
    public class IGeometricObjectWrapper
    {
        private IGeometricObject obj;

        public IGeometricObjectWrapper(IGeometricObject obj)
        {
            this.obj = obj;
        }

        public bool IsGeometricObject()
        {
            return obj is GeometricObject;
        }

        public GeometricObjectWrapper GetGeometricObject()
        {
            return new GeometricObjectWrapper(obj as GeometricObject);
        }
    }
}
