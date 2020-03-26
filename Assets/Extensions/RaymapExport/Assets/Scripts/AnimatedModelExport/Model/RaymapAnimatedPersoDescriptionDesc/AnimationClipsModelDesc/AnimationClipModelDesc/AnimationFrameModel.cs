using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc.AnimationClipModelDesc
{
    public class AnimationFrameAssociationSubmeshUsedInfo
    {
        public SubmeshObjectType type;
        public string name;
    }

    public class AnimationFrameAssociationMorphSubmeshUsedInfo
    {
        public string morphUsed;
    }

    public class ChannelTransformModel
    {
        public Vector3d position;
        public Quaternion rotation;
        public Vector3d scale;
    }

    public class AnimationFrameModel
    {
        public Dictionary<string, ChannelTransformModel> channels;
        public Dictionary<string, AnimationFrameAssociationSubmeshUsedInfo> submeshes;
    }
}
