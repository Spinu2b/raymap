using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc.SubmeshObjectModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc
{
    public class MorphSubmeshObjectModel : SubmeshObjectModel
    {
        public Dictionary<string, List<Vector3d>> morphData;
        public ChannelBindPose parentChannelBindPose;
    }
}
