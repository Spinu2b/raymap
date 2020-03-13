using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc
{
    public class AnimationFrameModelNode
    {
        private string name;
        private bool isKeyframe;
        private Vector3d position;
        private Vector3d localPosition;
        private Quaternion rotation;
        private Quaternion localRotation;
        private Vector3d scale;
        private Vector3d localScale;

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
