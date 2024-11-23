using Assets.Scripts.GenericExport.Model;
using Assets.Scripts.GenericExport.Model.DataBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GenericExport.GenericExportBones.Model.DataBlocks
{
    public class FrameBonesDataBlock
    {
        public Dictionary<string, BonesDataBlock> dataBlocks = new Dictionary<string, BonesDataBlock>();

        public static FrameBonesDataBlock GetConcreteWholePotentiallySkinnedSubmeshesInPoseFrameDataBlock(PersoBehaviour persoBehaviour)
        {
            Dictionary<string, ConcreteWholePotentiallySkinnedSubmeshInPoseDataBlock> wholeSubmeshes = new Dictionary<string, ConcreteWholePotentiallySkinnedSubmeshInPoseDataBlock>();

            foreach (var child in persoBehaviour.GetComponentsInChildren<Transform>())
            {
                if (ObjectDeterminer.IsSubmesh(child))
                {
                    wholeSubmeshes[ObjectDeterminer.GetChainedChannelsKey(child)] =
                        ConcreteWholePotentiallySkinnedSubmeshInPoseDataBlock.FromSubmesh(child);
                }
            }

            var result = new FrameBonesDataBlock();
            result.dataBlocks = wholeSubmeshes.ToDictionary(x => x.Key, x => x.Value as BonesDataBlock);
            return result;
        }

        public static FrameBonesDataBlock GetConsolidated(
            Dictionary<int, FrameBonesDataBlock> currentFrameDataBlocks,
            int currentFrame,
            PersoBehaviour persoBehaviour)
        {
            var dataToBeConsideredNow = FrameBonesDataBlock.GetConcreteWholePotentiallySkinnedSubmeshesInPoseFrameDataBlock(persoBehaviour);
            return dataToBeConsideredNow;
        }
    }
}
