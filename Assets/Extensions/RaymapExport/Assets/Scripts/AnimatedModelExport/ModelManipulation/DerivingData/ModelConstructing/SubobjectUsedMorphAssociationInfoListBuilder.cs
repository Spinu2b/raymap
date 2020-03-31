using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class PhysicalObjectsTransitionSubobjectUsedMorphAssociationInfoListBuilder
    {
        private int physicalObjectNumberFrom;
        private int physicalObjectNumberTo;

        private List<SubobjectUsedMorphAssociationInfo> result = new List<SubobjectUsedMorphAssociationInfo>();

        public PhysicalObjectsTransitionSubobjectUsedMorphAssociationInfoListBuilder(int physicalObjectNumberFrom, int physicalObjectNumberTo)
        {
            this.physicalObjectNumberFrom = physicalObjectNumberFrom;
            this.physicalObjectNumberTo = physicalObjectNumberTo;
        }

        public void Consider(int morphFrameNumber, float morphProgress)
        {
            TakeIntoAccountInResult(morphFrameNumber, morphProgress);
        }

        private void TakeIntoAccountInResult(int morphFrameNumber, float morphProgress)
        {
            // let's assume that we are appending blocks in ascending frame numbers order
            foreach (var morphBlock in result)
            {
                if (morphFrameNumber == morphBlock.GetMinimalKeyframeNumber() - 1 || morphFrameNumber == morphBlock.GetMaxKeyframeNumber() + 1) {
                    morphBlock.morphProgressKeyframes.Add(morphFrameNumber, morphProgress);
                    return;
                }
            }

            var newBlock = new SubobjectUsedMorphAssociationInfo(physicalObjectNumberFrom, physicalObjectNumberTo);
            newBlock.morphProgressKeyframes.Add(morphFrameNumber, morphProgress);
            result.Add(newBlock);
        }

        public List<SubobjectUsedMorphAssociationInfo> Build()
        {
            return result;
        }
    }

    public class SubobjectUsedMorphAssociationInfoListBuilder
    {
        private Dictionary<int, Dictionary<int, Dictionary<int, float>>> objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks =
            new Dictionary<int, Dictionary<int, Dictionary<int, float>>>();

        public List<SubobjectUsedMorphAssociationInfo> Build()
        {
            var result = new List<SubobjectUsedMorphAssociationInfo>();
            foreach (int physicalObjectNumberFrom in objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks.Keys)
            {
                foreach (int physicalObjectNumberTo in objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks[physicalObjectNumberFrom].Keys)
                {
                    result.AddRange(GetMorphFinalDataFor(physicalObjectNumberFrom, physicalObjectNumberTo));
                }
            }
            return result;
        }

        private List<SubobjectUsedMorphAssociationInfo> GetMorphFinalDataFor(int physicalObjectNumberFrom, int physicalObjectNumberTo)
        {
            var resultBuilder = new PhysicalObjectsTransitionSubobjectUsedMorphAssociationInfoListBuilder(physicalObjectNumberFrom, physicalObjectNumberTo);
            foreach (var morphFrameNumber in 
                objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks
                [physicalObjectNumberFrom][physicalObjectNumberTo].Keys.OrderBy(x => x))
            {
                float morphProgress = objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks
                [physicalObjectNumberFrom][physicalObjectNumberTo][morphFrameNumber];
                resultBuilder.Consider(morphFrameNumber, morphProgress);
            }
            return resultBuilder.Build();
        }

        public void Consider(int frameNumber, List<Tuple<int, int, int>> animationFrameMorphData)
        {
            foreach (var morphData in animationFrameMorphData)
            {
                int physicalObjectNumberFrom = morphData.Item1;
                int physicalObjectNumberTo = morphData.Item2;
                float morphProgress = morphData.Item3 / 100.0f;

                AddMorphDataBuildingBlock(frameNumber, physicalObjectNumberFrom, physicalObjectNumberTo, morphProgress);
            }
        }

        private void AddMorphDataBuildingBlock(int frameNumber, int physicalObjectNumberFrom, int physicalObjectNumberTo, float morphProgress)
        {
            if (!objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks.ContainsKey(physicalObjectNumberFrom))
            {
                objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks.Add(
                    physicalObjectNumberFrom, new Dictionary<int, Dictionary<int, float>>());
            }
            if (!objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks[physicalObjectNumberFrom].ContainsKey(physicalObjectNumberTo))
            {
                objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks[physicalObjectNumberFrom].Add(physicalObjectNumberTo, new Dictionary<int, float>());
            }
            if (!objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks[physicalObjectNumberFrom][physicalObjectNumberTo].ContainsKey(frameNumber))
            {
                objectFromObjectToFrameNumberMorphProgressAssociationsBuildingBlocks[physicalObjectNumberFrom][physicalObjectNumberTo][frameNumber] = morphProgress;
            } 
            else
            {
                throw new InvalidOperationException("Already contains that morph info regarding that physical object from, physical object to and animation frame number!");
            }
        }
    }
}
