using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Collide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Collide
{
    public static class GeometricObjectCollideExtensions
    {
        public static GeometricObjectCollide ForExportClone(this GeometricObjectCollide geometricObjectCollide)
        {
            GeometricObjectCollide m = (GeometricObjectCollide)ObjectHelper.MemberwiseClone(geometricObjectCollide);
            m.SetRaymapExportGao(new ActualManifestableUnityGameObject("Collide Set @ " + geometricObjectCollide.offset));
            m.GetRaymapExportGao().tag = "Collide";
            m.elements = new IGeometricObjectElementCollide[geometricObjectCollide.num_elements];
            for (uint i = 0; i < m.num_elements; i++)
            {
                if (geometricObjectCollide.elements[i] != null)
                {
                    m.elements[i] = geometricObjectCollide.elements[i].ForExportClone(m);
                }
            }
            for (uint i = 0; i < m.num_elements; i++)
            {
                if (m.elements[i] != null)
                {
                    ActualManifestableUnityGameObject child = m.elements[i].GetRaymapExportGao();
                    child.transform.SetParent(m.GetRaymapExportGao().transform);
                    child.transform.localPosition = Vector3d.zero;
                }
            }
            m.ForExportSetVisualsActive(false); // Invisible by default
            //m.gao.SetActive(false); // Invisible by default
            return m;
        }

        public static void ForExportSetVisualsActive(this GeometricObjectCollide geometricObjectCollide, bool active)
        {

        }

        public static void SetRaymapExportGao(this GeometricObjectCollide geometricObjectCollide, ActualManifestableUnityGameObject gameObject)
        {
            
        }

        public static ActualManifestableUnityGameObject GetRaymapExportGao(this GeometricObjectCollide geometricObjectCollide)
        {
            return new ActualManifestableUnityGameObject();
        }
    }
}
