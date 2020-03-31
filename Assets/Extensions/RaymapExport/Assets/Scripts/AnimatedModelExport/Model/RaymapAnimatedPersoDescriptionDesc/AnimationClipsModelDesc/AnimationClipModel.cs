using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc
{
    public class SubobjectUsedAssociationInfo
    {
        public int frameBegin;
        public int frameEnd;

        public SubobjectUsedAssociationInfo(int frameBegin, int frameEnd)
        {
            this.frameBegin = frameBegin;
            this.frameEnd = frameEnd;
        }
    }

    public class SubobjectUsedMorphAssociationInfo
    {
        public int morphSubobjectStart;
        public int morphSubobjectEnd;
        public Dictionary<int, float> morphProgressKeyframes = new Dictionary<int, float>();

        public SubobjectUsedMorphAssociationInfo(int morphSubobjectStart, int morphSubobjectEnd)
        {
            this.morphSubobjectStart = morphSubobjectStart;
            this.morphSubobjectEnd = morphSubobjectEnd;
        }

        public int GetMinimalKeyframeNumber()
        {
            return morphProgressKeyframes.Keys.Min();
        }

        public int GetMaxKeyframeNumber()
        {
            return morphProgressKeyframes.Keys.Max();
        }
    }

    public struct ChannelTransformModel
    {
        public Vector3d position;
        public MathDescription.Quaternion rotation;
        public Vector3d scale;

        public static ChannelTransformModel FromUnityAbsoluteTransform(Transform transform)
        {
            var result = new ChannelTransformModel();
            result.position = Vector3d.FromUnityVector3(transform.position);
            result.rotation = MathDescription.Quaternion.FromUnityQuaternion(transform.rotation);
            result.scale = Vector3d.FromUnityVector3(transform.lossyScale);
            return result;
        }
    }

    public class AnimationClipModel
    {
        public string name;
        public Dictionary<int, Dictionary<int, ChannelTransformModel>> channelKeyframes = new Dictionary<int, Dictionary<int, ChannelTransformModel>>();
        public Dictionary<int, List<SubobjectUsedAssociationInfo>> subobjectsExistenceData = new Dictionary<int, List<SubobjectUsedAssociationInfo>>();
        public List<SubobjectUsedMorphAssociationInfo> morphs = new List<SubobjectUsedMorphAssociationInfo>();
    }
}
