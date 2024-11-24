using Assets.Scripts.GenericExport.Model.DataBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GenericExport.GenericExportBones.Model.DataBlocks
{
    public class ExportBones
    {
        public List<ObjectTransform> bindposes = new List<ObjectTransform>();
        public List<ExportBoneWeight> boneWeights = new List<ExportBoneWeight>();
        public List<ObjectTransform> boneTransforms = new List<ObjectTransform>();
    }
}
