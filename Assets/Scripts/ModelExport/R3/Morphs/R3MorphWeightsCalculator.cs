using System;
using System.Collections.Generic;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using OpenSpace.Object.Properties;
using OpenSpace.Visual;

namespace ModelExport.R3.Morphs
{
    /// <summary>
    /// Per-frame vertex morph weights of an R3 animation, as blend shape weights.
    /// Raymap (PersoBehaviour.UpdateAnimation) morphs a channel's PO step by step: for each morph k of the frame,
    /// v = Lerp(v, target_k, p_k) for a full-mesh target (GeometricObject) or v += p_k * offset_k for a patch target
    /// (PatchGeometricObject). Unrolled, that is exactly base + sum_k w_k * delta_k with delta_k = target_k - base
    /// (or offset_k) and w_k = p_k * product of (1 - p_l) over the later full-mesh steps l > k.
    /// </summary>
    public class R3MorphWeightsCalculator
    {
        private readonly AnimA3DGeneral a3d;
        private readonly ObjectList objectList;

        public R3MorphWeightsCalculator(AnimA3DGeneral a3d, ObjectList objectList)
        {
            this.a3d = a3d;
            this.objectList = objectList;
        }

        public static string ObjectKey(int objectIndex)
        {
            return "PO" + objectIndex;
        }

        /// <returns>source PO key -> target PO key -> weight, or null when the frame has no morphs.</returns>
        public Dictionary<string, Dictionary<string, float>> WeightsForFrame(int frameNumber)
        {
            if (a3d == null || a3d.num_morphData == 0 || a3d.morphData == null || objectList == null) return null;
            // Raymap keeps one morph entry per (first channel with that id, frame): the last one read wins
            var entryPerChannel = new Dictionary<short, AnimMorphData>();
            for (int i = 0; i < a3d.num_morphData; i++)
            {
                AnimMorphData m = a3d.morphData[a3d.start_morphData + i];
                if (m != null && m.frame == frameNumber) entryPerChannel[m.channel] = m;
            }
            if (entryPerChannel.Count == 0) return null;

            Dictionary<string, Dictionary<string, float>> result = null;
            foreach (var pair in entryPerChannel)
            {
                int sourceObjectIndex = SourceObjectIndexOfChannelAtFrame(pair.Key, frameNumber);
                if (sourceObjectIndex < 0) continue;
                AnimMorphData m = pair.Value;
                int count = Math.Max(1, (int)m.numMorphs);
                var targets = new int[count];
                var progress = new float[count];
                var isFullMesh = new bool[count];
                var usable = new bool[count];
                for (int k = 0; k < count; k++)
                {
                    targets[k] = m.objectIndexToArray != null ? m.objectIndexToArray[k] : m.objectIndexTo;
                    progress[k] = m.GetMorphProgressFloat(k);
                    IGeometricObject target = TargetGeometry(targets[k]);
                    usable[k] = target is GeometricObject || target is PatchGeometricObject;
                    isFullMesh[k] = target is GeometricObject;
                }
                for (int k = 0; k < count; k++)
                {
                    if (!usable[k]) continue;
                    float weight = progress[k];
                    for (int l = k + 1; l < count; l++)
                    {
                        if (usable[l] && isFullMesh[l]) weight *= 1f - progress[l];
                    }
                    if (weight == 0f) continue;
                    if (result == null) result = new Dictionary<string, Dictionary<string, float>>();
                    string sourceKey = ObjectKey(sourceObjectIndex);
                    if (!result.ContainsKey(sourceKey)) result[sourceKey] = new Dictionary<string, float>();
                    string targetKey = ObjectKey(targets[k]);
                    float previous;
                    result[sourceKey].TryGetValue(targetKey, out previous);
                    result[sourceKey][targetKey] = previous + weight;
                }
            }
            return result;
        }

        private IGeometricObject TargetGeometry(int objectIndex)
        {
            if (objectIndex < 0 || objectIndex >= objectList.Count) return null;
            PhysicalObject po = objectList[objectIndex].po;
            if (po == null || po.visualSet == null || po.visualSet.Length == 0) return null;
            return po.visualSet[0].obj;
        }

        /// <returns>the object list index of the PO the channel shows at that frame, -1 if none / invisible.</returns>
        public int SourceObjectIndexOfChannelAtFrame(short channelId, int frameNumber)
        {
            AnimOnlyFrame onlyFrame = a3d.onlyFrames[a3d.start_onlyFrames + frameNumber];
            for (int c = 0; c < a3d.num_channels; c++)
            {
                AnimChannel channel = a3d.channels[a3d.start_channels + c];
                if (channel.id != channelId) continue;
                AnimNumOfNTTO numOfNTTO = a3d.numOfNTTO[channel.numOfNTTO + onlyFrame.numOfNTTO];
                AnimNTTO ntto = a3d.ntto[numOfNTTO.numOfNTTO];
                return ntto.IsInvisibleNTTO ? -1 : ntto.object_index;
            }
            return -1;
        }
    }
}
