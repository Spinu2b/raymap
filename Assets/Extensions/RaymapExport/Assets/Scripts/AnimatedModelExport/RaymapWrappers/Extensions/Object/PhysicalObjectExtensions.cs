using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Collide;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Object;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Object
{
    public static class PhysicalObjectExtensions
    {
        public static PhysicalObject ForExportClone(this PhysicalObject physicalObject)
        {
            PhysicalObject po = (PhysicalObject)ObjectHelper.MemberwiseClone(physicalObject);
            po.visualSet = new VisualSetLOD[physicalObject.visualSet.Length];
            po.Reset();
            for (int i = 0; i < physicalObject.visualSet.Length; i++)
            {
                po.visualSet[i].LODdistance = physicalObject.visualSet[i].LODdistance;
                po.visualSet[i].off_data = physicalObject.visualSet[i].off_data;
                po.visualSet[i].obj = physicalObject.visualSet[i].obj.ForExportClone();
                if (po.visualSet[i].obj is GeometricObject)
                {
                    GeometricObject m = ((GeometricObject)po.visualSet[i].obj);
                    //if (m.name != "Mesh") po.Gao.name = "[PO] " + m.name;
                    if (m.name != "Mesh") po.GetRaymapExportGao().name = "[PO] " + m.name;
                    m.GetRaymapExportGao().transform.parent = po.GetRaymapExportGao().transform;
                }
            }
            if (po.visualSet.Length > 1)
            {
                float bestLOD = po.visualSet.Min(v => v.LODdistance);
                foreach (VisualSetLOD lod in po.visualSet)
                {
                    if (lod.obj.GetRaymapExportGao() != null && lod.LODdistance != bestLOD) lod.obj.GetRaymapExportGao().SetActive(false);
                }
            }
            if (physicalObject.collideMesh != null)
            {
                po.collideMesh = physicalObject.collideMesh.ForExportClone();
                po.collideMesh.GetRaymapExportGao().transform.parent = po.GetRaymapExportGao().transform;
            }
            return po;
        }

        public static ActualManifestableUnityGameObject GetRaymapExportGao(this PhysicalObject physicalObject)
        {
            return new ActualManifestableUnityGameObject();
        }
    }
}
