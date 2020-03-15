using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model
{
    public class PhysicalObjectSubmeshObject
    {
        public GameObject submeshGameObject { get; private set; }

        public PhysicalObjectSubmeshObject(GameObject submeshGameObject)
        {
            this.submeshGameObject = submeshGameObject;
        }

        public bool IsAlphaChannelSubmeshObject { 
            get
            {
                return submeshGameObject.GetComponent<Renderer>().materials[0].name.Contains("alpha");
            }
        }

        public Mesh GetMesh()
        {
            if (submeshGameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return submeshGameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
            } 
            else if (submeshGameObject.GetComponent<MeshFilter>() != null)
            {
                return submeshGameObject.GetComponent<MeshFilter>().sharedMesh;
            } 
            else
            {
                throw new InvalidOperationException("There is no component in this submesh gameobject that allows to access actual Unity mesh!");
            }
        }

        public UnityBoneTransformModel[] GetUnityMappedBonesBindPoses()
        {
            throw new NotImplementedException();
        }

        public UnityBoneWeightModel[] GetUnityMappedBoneWeights()
        {
            throw new NotImplementedException();
        }

        public UnityBoneTransformModel[] GetUnityMappedBones()
        {
            throw new NotImplementedException();
        }
    }
}
