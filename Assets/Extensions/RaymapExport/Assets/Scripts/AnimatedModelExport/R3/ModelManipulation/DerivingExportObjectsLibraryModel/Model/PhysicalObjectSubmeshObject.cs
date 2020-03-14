using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.Model
{
    public class PhysicalObjectSubmeshObject
    {
        public GameObject submeshGameObject { get; private set; };

        public PhysicalObjectSubmeshObject(GameObject submeshGameObject)
        {
            this.submeshGameObject = submeshGameObject;
        }

        public bool IsAlphaChannelSubmeshObject { 
            get
            {
                return submeshGameObject.GetComponent<SkinnedMeshRenderer>().materials[0].name.Contains("alpha");
            }
        }
    }
}
