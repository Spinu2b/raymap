using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc.SubmeshObjectModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc
{
    public class SkinnedSubmeshObjectModel : SubmeshObjectModel
    {
        public Dictionary<string, ChannelBindPose> bindChannelPoses;
        public Dictionary<string, Dictionary<int, float>> channelWeights;
    }
}
