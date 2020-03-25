using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.Utils;
using OpenSpace.Object;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model
{
    public class PhysicalObjectWithChannelParentingInfo
    {
        private PhysicalObject physicalObject;

        public PhysicalObjectWithChannelParentingInfo(PhysicalObject physicalObject)
        {
            this.physicalObject = physicalObject;
        }

        public bool IsVisiblePhysicalObject { 
            get
            {
                return !physicalObject.Gao.name.Contains("Invisible");
            }
        }

        public IEnumerable<PhysicalObjectSubmeshObject> IteratePhysicalObjectSubmeshes()
        {
            foreach (Transform childTransform in 
                UnityHierarchyHelper.IterateAllGameObjectChildrenAndSubchildrenRecursively(physicalObject.Gao))
            {
                if (childTransform.gameObject.name.Contains("Submesh"))
                {
                    yield return new PhysicalObjectSubmeshObject(childTransform.gameObject);
                }                
            }
        }
    }
}
