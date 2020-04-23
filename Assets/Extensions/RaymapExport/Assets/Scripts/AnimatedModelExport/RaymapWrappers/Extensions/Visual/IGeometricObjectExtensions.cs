using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Visual;
using OpenSpace.Visual.Deform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual
{
    public static class GeometricObjectCloner
    {
        public static IGeometricObject ForExportClone(GeometricObject geometricObject)
        {
            GeometricObject m = (GeometricObject)ObjectHelper.MemberwiseClone(geometricObject);
            m.Reset();
            m.elements = new IGeometricObjectElement[geometricObject.num_elements];
            for (uint i = 0; i < m.num_elements; i++)
            {
                if (geometricObject.elements[i] != null)
                {
                    m.elements[i] = geometricObject.elements[i].ForExportClone(m);
                    if (m.elements[i] is DeformSet) m.bones = (DeformSet)m.elements[i];
                }
            }
            return m;
        }
    }

    public static class MeshModificationObjectCloner
    {
        public static IGeometricObject ForExportClone(MeshModificationObject geometricObject)
        {
            MeshModificationObject lodObj = (MeshModificationObject)ObjectHelper.MemberwiseClone(geometricObject);
            return lodObj;
        }
    }

    public static class IGeometricObjectExtensions
    {
        public static IGeometricObject ForExportClone(this IGeometricObject geometricObject)
        {
            if (geometricObject is GeometricObject)
            {
                return GeometricObjectCloner.ForExportClone((GeometricObject)geometricObject);
            } else if (geometricObject is MeshModificationObject)
            {
                return MeshModificationObjectCloner.ForExportClone((MeshModificationObject)geometricObject);
            } else
            {
                throw new NotImplementedException("IGeometricObject implementation unsupported for export cloning!");
            }
        }

        public static ActualManifestableUnityGameObject GetRaymapExportGao(this IGeometricObject geometricObject)
        {
            return new ActualManifestableUnityGameObject();
        }
    }
}
