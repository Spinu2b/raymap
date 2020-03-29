using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class SubobjectUsedAssociationInfoListBuilder
    {
        private List<SubobjectUsedAssociationInfo> result = new List<SubobjectUsedAssociationInfo>();

        public List<SubobjectUsedAssociationInfo> Build()
        {
            return result;
        }

        public void AddExistenceFrame(int subobjectExistingFrame)
        {
            if (result.Count == 0)
            {
                result.Add(new SubobjectUsedAssociationInfo(subobjectExistingFrame, subobjectExistingFrame));
            } 
            else
            {
                var lastExistenceElementSoFar = GetLastExistenceElementSoFar();
                if (subobjectExistingFrame > lastExistenceElementSoFar.frameEnd + 1)
                {
                    result.Add(new SubobjectUsedAssociationInfo(subobjectExistingFrame, subobjectExistingFrame));
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

        private SubobjectUsedAssociationInfo GetLastExistenceElementSoFar()
        {
            return result.Last();
        }
    }

    public class SubobjectUsedAssociationInfosBuilder
    {
        private Dictionary<int, List<int>> temporaryBuildingAnimationFrames = new Dictionary<int, List<int>>();

        public void ConsiderAssociation(int subobjectNumber, int frameNumber)
        {
            if (!temporaryBuildingAnimationFrames.ContainsKey(subobjectNumber))
            {
                temporaryBuildingAnimationFrames.Add(subobjectNumber, new List<int>());
            }
            if (!temporaryBuildingAnimationFrames[subobjectNumber].Contains(frameNumber))
            {
                temporaryBuildingAnimationFrames[subobjectNumber].Add(frameNumber);
            }            
        }

        public Dictionary<int, List<SubobjectUsedAssociationInfo>> Build()
        {
            var result = new Dictionary<int, List<SubobjectUsedAssociationInfo>>();
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
    }
}
