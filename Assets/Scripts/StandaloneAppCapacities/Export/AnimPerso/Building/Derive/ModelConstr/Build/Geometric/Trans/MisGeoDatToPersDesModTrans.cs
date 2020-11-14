using Assets.Scripts.ResourcesModel.Geometric;
using Assets.Scripts.ResourcesModel.Math;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.GeoObjDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Geometric.Trans
{
    public static class UnityBindPoseHelper
    {
        public static BoneBindPose DecomposeBindPoseMatrix4x4ToBoneBindPose(Matrix4x4 bindposeMatrix)
        {
            var result = new BoneBindPose();
            // lets assume that in here the position is absolute, we strive for it
            result.position = Vector3d.FromResourcesModelVector4(bindposeMatrix.GetColumn(3));
            result.rotation = Math.Quaternion.FromUnityQuaternion(
                UnityEngine.Quaternion.LookRotation(bindposeMatrix.GetUnityColumn(2), bindposeMatrix.GetUnityColumn(1)));
            result.scale = new Math.Vector3d(bindposeMatrix.GetColumn(0).magnitude, bindposeMatrix.GetColumn(1).magnitude, bindposeMatrix.GetColumn(2).magnitude);
            return result;
        }

        public static BoneBindPose BoneBindPoseFromResourcesModelTransform(Transform bindpose)
        {
            var result = new BoneBindPose();
            result.position = Vector3d.FromResourcesModelVector3(bindpose.position);
            result.rotation = Math.Quaternion.FromResourcesModelQuaternion(bindpose.rotation);
            result.scale = Vector3d.FromResourcesModelVector3(bindpose.lossyScale);
            return result;
        }
    }

    public static class MiscellaneousGeometricDataToPersoDescriptionModelTransformer
    {
        public static Dictionary<int, Dictionary<int, float>> 
            TransformResourcesModelBonesWeightsToAnimatedPersoBoneWeightsExportModel(BoneWeight[] boneWeights)
        {
            var result = new Dictionary<int, Dictionary<int, float>>();
            for (int vertexIndex = 0; vertexIndex < boneWeights.Length; vertexIndex++)
            {
                var bonesWeights = boneWeights[vertexIndex];
                if (!result.ContainsKey(bonesWeights.boneIndex0))
                {
                    result.Add(bonesWeights.boneIndex0, new Dictionary<int, float>());
                }
                result[bonesWeights.boneIndex0][vertexIndex] = bonesWeights.weight0;
                if (!result.ContainsKey(bonesWeights.boneIndex1))
                {
                    result.Add(bonesWeights.boneIndex1, new Dictionary<int, float>());
                }
                result[bonesWeights.boneIndex1][vertexIndex] = bonesWeights.weight1;
                if (!result.ContainsKey(bonesWeights.boneIndex2))
                {
                    result.Add(bonesWeights.boneIndex2, new Dictionary<int, float>());
                }
                result[bonesWeights.boneIndex2][vertexIndex] = bonesWeights.weight2;
                if (!result.ContainsKey(bonesWeights.boneIndex3))
                {
                    result.Add(bonesWeights.boneIndex3, new Dictionary<int, float>());
                }
                result[bonesWeights.boneIndex3][vertexIndex] = bonesWeights.weight3;
            }
            return result;
        }

        public static Dictionary<int, BoneBindPose> TransformResourcesModelBindPosesToAnimatedPersoBindBonePosesExportModel(Matrix4x4[] bindposes)
        {
            int boneIndex = 0;
            var result = new Dictionary<int, BoneBindPose>();
            foreach (var bindpose in bindposes)
            {
                BoneBindPose boneBindPose = UnityBindPoseHelper.DecomposeBindPoseMatrix4x4ToBoneBindPose(bindpose);
                result[boneIndex] = boneBindPose;
                boneIndex++;
            }
            return result;
        }

        public static Dictionary<int, BoneBindPose> TransformResourcesModelBindPosesToAnimatedPersoBindBonePosesExportModel(Transform[] bindposes)
        {
            int boneIndex = 0;
            var result = new Dictionary<int, BoneBindPose>();
            foreach (var bindpose in bindposes)
            {
                BoneBindPose boneBindPose = UnityBindPoseHelper.BoneBindPoseFromResourcesModelTransform(bindpose);
                result[boneIndex] = boneBindPose;
                boneIndex++;
            }
            return result;
        }
    }
}
