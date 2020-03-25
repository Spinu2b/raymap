using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.MeshGeometryConstr
{
    public class BoneWeightsInfo
    {
        public string BoneName;
        public int BoneIndex;

        public BoneWeightsInfo(string BoneName, int BoneIndex)
        {
            this.BoneName = BoneName;
            this.BoneIndex = BoneIndex;
        }
    }
}
