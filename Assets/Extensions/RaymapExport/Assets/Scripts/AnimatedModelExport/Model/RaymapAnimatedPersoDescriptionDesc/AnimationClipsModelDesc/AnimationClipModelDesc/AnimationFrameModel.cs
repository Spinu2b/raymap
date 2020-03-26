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
        // Theoretically in animations based on submeshes using morphs you dont need to use bones - actually use channels positions etc to position actual submeshes
        // objects directly, therefore swapping submeshes in-between is just scaling them down to near zero with zero interpolation
        // You would only need actual armature bones in case of skinned submeshes, in case of swapping submeshes in-between in that case
        // you would need skinned channel/bones (subtrees? if you would like to keep bones hierarchy if you could get it to actually work)
        // duplicates for each submesh parented to actual that same channel, respectively. Quite tricky, but it could work.
        // Of course all the time swapping submeshes during animations occurs with zero interpolation in those cases

        public Dictionary<string, ChannelTransformModel> channels;
        public Dictionary<string, AnimationFrameAssociationSubmeshUsedInfo> submeshes;
    }
}
