using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.AnimationFrameAssociations
{
    public class SubobjectUsedAssociationInfoListBuilder
    {
        private List<AnimationFramesPeriodInfo> result = new List<AnimationFramesPeriodInfo>();

        public List<AnimationFramesPeriodInfo> Build()
        {
            return result;
        }

        public void AddExistenceFrame(int subobjectExistingFrame)
        {
            if (result.Count == 0)
            {
                result.Add(new AnimationFramesPeriodInfo(subobjectExistingFrame, subobjectExistingFrame));
            }
            else
            {
                var lastExistenceElementSoFar = GetLastExistenceElementSoFar();
                if (subobjectExistingFrame > lastExistenceElementSoFar.frameEnd + 1)
                {
                    result.Add(new AnimationFramesPeriodInfo(subobjectExistingFrame, subobjectExistingFrame));
                }
                else if (subobjectExistingFrame == lastExistenceElementSoFar.frameEnd + 1)
                {
                    lastExistenceElementSoFar.frameEnd = subobjectExistingFrame;
                }
                else
                {
                    throw new InvalidOperationException("Wrong order of putting frame numbers in the builder to build subobject existence info in animation clip!");
                }
            }
        }

        private AnimationFramesPeriodInfo GetLastExistenceElementSoFar()
        {
            return result.Last();
        }
    }

    public abstract class AnimationFramesDataUsedAssociationInfosBuilder<T, KeyType>
    {
        private Dictionary<KeyType, List<int>> temporaryBuildingAnimationFrames = new Dictionary<KeyType, List<int>>();

        public void ConsiderAssociation(T data, int frameNumber)
        {
            KeyType key = GetKey(data);

            if (!temporaryBuildingAnimationFrames.ContainsKey(key))
            {
                temporaryBuildingAnimationFrames.Add(key, new List<int>());
            }
            if (!temporaryBuildingAnimationFrames[key].Contains(frameNumber))
            {
                temporaryBuildingAnimationFrames[key].Add(frameNumber);
            }
        }

        public Dictionary<KeyType, List<AnimationFramesPeriodInfo>> Build()
        {
            var result = new Dictionary<KeyType, List<AnimationFramesPeriodInfo>>();
            foreach (var buildingExistenceFramesForSubobject in temporaryBuildingAnimationFrames)
            {
                buildingExistenceFramesForSubobject.Value.Sort();
                var subobjectUsedAssociationInfoListBuilder = new SubobjectUsedAssociationInfoListBuilder();
                foreach (var subobjectExistingFrame in buildingExistenceFramesForSubobject.Value)
                {
                    subobjectUsedAssociationInfoListBuilder.AddExistenceFrame(subobjectExistingFrame);
                }
                result[buildingExistenceFramesForSubobject.Key] = subobjectUsedAssociationInfoListBuilder.Build();
            }
            return result;
        }

        protected abstract KeyType GetKey(T data);
    }
}
