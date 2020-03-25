﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.MeshGeometryConstr
{
    public class BonesWeightsHelper
    {
        public IEnumerable<BoneWeights> IterateBonesWeights(UnityBoneWeightModel[] boneWeights, UnityBoneTransformModel[] bones)
        {
            List<BoneWeightsInfo> BoneWeightsInfos = GetBoneWeightsInfos(bones);
            foreach (var BoneWeightsInfo in BoneWeightsInfos)
            {
                yield return GetBoneWeightsFor(BoneWeightsInfo.BoneName, BoneWeightsInfo.BoneIndex, boneWeights);
            }
        }

        private List<BoneWeightsInfo> GetBoneWeightsInfos(UnityBoneTransformModel[] bones)
        {
            var result = new List<BoneWeightsInfo>();
            for (int i = 0; i < bones.Length; i++)
            {
                result.Add(new BoneWeightsInfo(bones[i].name, i));
            }
            return result;
        }

        private BoneWeights GetBoneWeightsFor(string BoneName, int BoneIndex, UnityBoneWeightModel[] boneWeights)
        {
            var result = new BoneWeights();
            result.BoneName = BoneName;
            for (int vertexIndex = 0; vertexIndex < boneWeights.Length; vertexIndex++)
            {
                var weight = boneWeights[vertexIndex];
                if (weight.boneIndex0 == BoneIndex)
                {
                    result.Weights.Add(vertexIndex, weight.weight0);
                }
                else if (weight.boneIndex1 == BoneIndex)
                {
                    result.Weights.Add(vertexIndex, weight.weight1);
                }
                else if (weight.boneIndex2 == BoneIndex)
                {
                    result.Weights.Add(vertexIndex, weight.weight2);
                }
                else if (weight.boneIndex3 == BoneIndex)
                {
                    result.Weights.Add(vertexIndex, weight.weight3);
                }
            }
            return result;
        }
    }
}
