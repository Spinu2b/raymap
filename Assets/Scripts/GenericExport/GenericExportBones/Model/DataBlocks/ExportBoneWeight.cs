using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GenericExport.GenericExportBones.Model.DataBlocks
{
    public class ExportBoneWeight
    {
        public float weight0;

        public float weight1;

        public float weight2;

        public float weight3;

        public int boneIndex0;

        public int boneIndex1;

        public int boneIndex2;

        public int boneIndex3;

        public ExportBoneWeight(float weight0, float weight1, float weight2, float weight3, int boneIndex0, int boneIndex1, int boneIndex2, int boneIndex3)
        {
            this.weight0 = weight0;
            this.weight1 = weight1;
            this.weight2 = weight2;
            this.weight3 = weight3;
            this.boneIndex0 = boneIndex0;
            this.boneIndex1 = boneIndex1;
            this.boneIndex2 = boneIndex2;
            this.boneIndex3 = boneIndex3;
        }

        public static ExportBoneWeight FromUnityBoneWeight(BoneWeight boneWeight)
        {
            return new ExportBoneWeight(
                weight0: boneWeight.weight0,
                weight1: boneWeight.weight1,
                weight2: boneWeight.weight2,
                weight3: boneWeight.weight3,
                boneIndex0: boneWeight.boneIndex0,
                boneIndex1: boneWeight.boneIndex1,
                boneIndex2: boneWeight.boneIndex2,
                boneIndex3: boneWeight.boneIndex3
            );
        }
    }
}
