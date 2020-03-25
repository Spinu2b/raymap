using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData
{
    public class UnityBoneWeightModel
    {
        public int boneIndex0 = -1;
        public float weight0 = 0;

        public int boneIndex1 = -1;
        public float weight1 = 0;

        public int boneIndex2 = -1;
        public float weight2 = 0;

        public int boneIndex3 = -1;
        public float weight3 = 0;

        public static UnityBoneWeightModel FromActualUnityBoneWeight(BoneWeight boneWeight)
        {
            var result = new UnityBoneWeightModel();
            result.boneIndex0 = boneWeight.boneIndex0;
            result.boneIndex1 = boneWeight.boneIndex1;
            result.boneIndex2 = boneWeight.boneIndex2;
            result.boneIndex3 = boneWeight.boneIndex3;

            result.weight0 = boneWeight.weight0;
            result.weight1 = boneWeight.weight1;
            result.weight2 = boneWeight.weight2;
            result.weight3 = boneWeight.weight3;
            return result;
        }

        public static UnityBoneWeightModel WithParameters(int boneIndex, float boneWeight)
        {
            var result = new UnityBoneWeightModel();
            result.boneIndex0 = boneIndex;
            result.weight0 = boneWeight;
            return result;
        }
    }
}
