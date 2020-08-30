using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.AnimFrameAssoc
{
    public class DataUsedAssociationInfoListBuilder
    {
        private List<AnimationFramesPeriodInfo> result = new List<AnimationFramesPeriodInfo>();

        public List<AnimationFramesPeriodInfo> Build()
        {
            return result;
        }

        public void AddExistenceFrame(int dataExistingFrame)
        {
            if (result.Count == 0)
            {
                result.Add(new AnimationFramesPeriodInfo(dataExistingFrame, dataExistingFrame));
            }
            else
            {
                var lastExistenceElementSoFar = GetLastExistenceElementSoFar();
                if (dataExistingFrame > lastExistenceElementSoFar.frameEnd + 1)
                {
                    result.Add(new AnimationFramesPeriodInfo(dataExistingFrame, dataExistingFrame));
                }
                else if (dataExistingFrame == lastExistenceElementSoFar.frameEnd + 1)
                {
                    lastExistenceElementSoFar.frameEnd = dataExistingFrame;
                } 
                else
                {
                    throw new InvalidOperationException("Wrong order of putting frame numbers in the builder to build data existence info in animation clip!");
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
            foreach (var buildingExistenceFramesForData in temporaryBuildingAnimationFrames)
            {
                buildingExistenceFramesForData.Value.Sort();
                var dataUsedAssociationInfoListBuilder = new DataUsedAssociationInfoListBuilder();
                foreach (var dataExistingFrame in buildingExistenceFramesForData.Value)
                {
                    dataUsedAssociationInfoListBuilder.AddExistenceFrame(dataExistingFrame);
                }
                result[buildingExistenceFramesForData.Key] = dataUsedAssociationInfoListBuilder.Build();
            }
            return result;
        }

        protected abstract KeyType GetKey(T data);
    }
}
