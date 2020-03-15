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
            if (submeshGameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                int bonesListLength = submeshGameObject.GetComponent<SkinnedMeshRenderer>().bones.Length;
                var result = new UnityBoneTransformModel[bonesListLength];
                var bindPoses = submeshGameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.bindposes;
                var bones = submeshGameObject.GetComponent<SkinnedMeshRenderer>().bones;
                for (int boneIndex = 0; boneIndex < bonesListLength; boneIndex++)
                {
                    var boneName = GetParentChannelTransformForActualBoneTransform(bones[boneIndex]).gameObject.name;
                    var boneBindPoseMatrix = bindPoses[boneIndex];
                    result[boneIndex] = GetBindPoseBoneTransformModelForBindPoseMatrix(boneName, boneBindPoseMatrix);
                }
                return result;
            }
            else
            {
                return new UnityBoneTransformModel[] { UnityBoneTransformModel.HomeTransform(
                    GetParentChannelTransformForSubmesh(submeshGameObject).gameObject.name) };
            } 
        }

        private UnityBoneTransformModel GetBindPoseBoneTransformModelForBindPoseMatrix(string boneName, Matrix4x4 boneBindPoseMatrix)
        {
            GameObject boneWorkingDuplicate = new GameObject(boneName);
            boneWorkingDuplicate.transform.SetParent(null);

            Matrix4x4 localMatrix = boneBindPoseMatrix.inverse;
            boneWorkingDuplicate.transform.localPosition = localMatrix.MultiplyPoint(Vector3.zero);
            boneWorkingDuplicate.transform.localRotation = UnityEngine.Quaternion.LookRotation(localMatrix.GetColumn(2), localMatrix.GetColumn(1));
            boneWorkingDuplicate.transform.localScale =
                new Vector3(localMatrix.GetColumn(0).magnitude, localMatrix.GetColumn(1).magnitude, localMatrix.GetColumn(2).magnitude);

            var result = new UnityBoneTransformModel(boneWorkingDuplicate.transform);
            UnityEngine.Object.Destroy(boneWorkingDuplicate);
            return result;
        }

        private Transform GetParentChannelTransformForSubmesh(GameObject submeshGameObject)
        {
            throw new NotImplementedException();
        }

        private Transform GetParentChannelTransformForActualBoneTransform(Transform boneTransform)
        {
            throw new NotImplementedException();
        }

        public UnityBoneWeightModel[] GetUnityMappedBoneWeights()
        {
            throw new NotImplementedException();
        }

        public UnityBoneTransformModel[] GetUnityMappedBones()
        {
            if (submeshGameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return submeshGameObject.GetComponent<SkinnedMeshRenderer>().bones.Select(
                    boneTransform => new UnityBoneTransformModel(
                        GetParentChannelTransformForActualBoneTransform(boneTransform))).ToArray();
            }
            else
            {
                return new UnityBoneTransformModel[] { new UnityBoneTransformModel(GetParentChannelTransformForSubmesh(submeshGameObject)) };
            }
        }
    }
}
