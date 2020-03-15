using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.MeshGeometryConstr
{
    public class BoneWeightsInfo
    {
        public string BoneName;
        public string ChannelName;
        public int BoneIndex;

        public BoneWeightsInfo(string BoneName, string ChannelName, int BoneIndex)
        {
            this.BoneName = BoneName;
            this.ChannelName = ChannelName;
            this.BoneIndex = BoneIndex;
        }
    }
}
