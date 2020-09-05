using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Geometric
{
    public struct BoneWeight
    {
        public int boneIndex0;
        public int boneIndex1;
        public int boneIndex2;
        public int boneIndex3;

        public float weight0;
        public float weight1;
        public float weight2;
        public float weight3;

        public static BoneWeight FromUnityBoneWeight(UnityEngine.BoneWeight unityBoneWeight)
        {
            var result = new BoneWeight();
            result.boneIndex0 = unityBoneWeight.boneIndex0;
            result.boneIndex1 = unityBoneWeight.boneIndex1;
            result.boneIndex2 = unityBoneWeight.boneIndex2;
            result.boneIndex3 = unityBoneWeight.boneIndex3;

            result.weight0 = unityBoneWeight.weight0;
            result.weight1 = unityBoneWeight.weight1;
            result.weight2 = unityBoneWeight.weight2;
            result.weight3 = unityBoneWeight.weight3;
            return result;
        }
    }
}
