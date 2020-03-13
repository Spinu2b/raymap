using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.Model
{
    public class AnimTreeWithChannelsDataHierarchy : Tree<AnimTreeChannelsHierarchyNode, string>
    {
        public AnimationFrameModel ToAnimationFrameModel()
        {
            return AnimTreeWithChannelsDataHierarchyToAnimationFrameModelConverter.Convert(this);
        }

        public void AddNode(
            string parentChannelName,
            string channelName,
            bool isKeyframe,
            Vector3 absolutePosition,
            Quaternion absoluteRotation,
            Vector3 absoluteScale,
            Vector3 localPosition,
            Quaternion localRotation,
            Vector3 localScale)
        {
            AnimTreeChannelsHierarchyNode node = new AnimTreeChannelsHierarchyNode(
                channelName,
                isKeyframe,
                localPosition,
                localRotation,
                localScale,
                absolutePosition,
                absoluteRotation,
                absoluteScale
                );
            AddNode(parentChannelName, channelName, node);
        }

        public IEnumerable<AnimTreeChannelsHierarchyNode> IterateChannels()
        {
            foreach (var Channel in IterateNodes())
            {
                yield return Channel.Node;
            }
        }
    }
}
