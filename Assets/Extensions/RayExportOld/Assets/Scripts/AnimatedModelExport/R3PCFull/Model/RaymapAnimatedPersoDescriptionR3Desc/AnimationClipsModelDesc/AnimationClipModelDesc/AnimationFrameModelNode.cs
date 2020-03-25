using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.MathDescription;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc
{
    public class AnimationFrameModelNode
    {
        public string name;
        public bool isKeyframe;
        public Vector3d position;
        public Vector3d localPosition;
        public Quaternion rotation;
        public Quaternion localRotation;
        public Vector3d scale;
        public Vector3d localScale;

        public AnimationFrameModelNode(
            string name,
            bool isKeyframe,
            Vector3d position,
            Vector3d localPosition,
            Quaternion rotation,
            Quaternion localRotation,
            Vector3d scale,
            Vector3d localScale)
        {
            this.name = name;
            this.isKeyframe = isKeyframe;
            this.position = position;
            this.localPosition = localPosition;
            this.rotation = rotation;
            this.localRotation = localRotation;
            this.scale = scale;
            this.localScale = localScale;
        }
    }
}
