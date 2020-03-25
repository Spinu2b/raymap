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
                var bindPoses = GetMesh().bindposes;
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

            var result = UnityBoneTransformModel.FromUnityTransform(boneWorkingDuplicate.transform);
            UnityEngine.Object.Destroy(boneWorkingDuplicate);
            return result;
        }

        private Transform GetParentChannelTransformForSubmesh(GameObject submeshGameObject)
        {
            return GetParentChannelTransformForTransform(submeshGameObject.transform);
        }

        private Transform GetParentChannelTransformForActualBoneTransform(Transform boneTransform)
        {
            return GetParentChannelTransformForTransform(boneTransform);
        }

        private Transform GetParentChannelTransformForTransform(Transform transform)
        {
            var currentTransform = transform;
            while (currentTransform != null && !currentTransform.gameObject.name.Contains("Channel"))
            {
                currentTransform = currentTransform.parent;
            }
            if (currentTransform == null)
            {
                throw new InvalidOperationException("Could not find parent channel for given transform in the hierarchy!");
            }
            else
            {
                return currentTransform;
            }
        }

        public UnityBoneWeightModel[] GetUnityMappedBoneWeights()
        {
            if (submeshGameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                int verticesLength = GetMesh().vertices.Length;
                var result = new UnityBoneWeightModel[verticesLength];
                var boneWeights = GetMesh().boneWeights;
                for (int vertexIndex = 0; vertexIndex < verticesLength; vertexIndex++)
                {
                    result[vertexIndex] = UnityBoneWeightModel.FromActualUnityBoneWeight(boneWeights[vertexIndex]);
                }
                return result;
            }
            else if (submeshGameObject.GetComponent<MeshRenderer>() != null)
            {
                var vertices = GetMesh().vertices;
                return vertices.Select(vertex => UnityBoneWeightModel.WithParameters(boneIndex: 0, boneWeight: 1.0f)).ToArray();
            } 
            else
            {
                throw new InvalidOperationException("This physical object is neither channel-parented nor skinned one!");
            }
        }

        public UnityBoneTransformModel[] GetUnityMappedBones()
        {
            if (submeshGameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return submeshGameObject.GetComponent<SkinnedMeshRenderer>().bones.Select(
                    boneTransform => UnityBoneTransformModel.FromUnityTransform(
                        GetParentChannelTransformForActualBoneTransform(boneTransform))).ToArray();
            }
            else if (submeshGameObject.GetComponent<MeshRenderer>() != null)
            {
                return new UnityBoneTransformModel[] { UnityBoneTransformModel.FromUnityTransform(GetParentChannelTransformForSubmesh(submeshGameObject)) };
            } 
            else
            {
                throw new InvalidOperationException("This physical object is neither channel-parented nor skinned one!");
            }
        }
    }
}
