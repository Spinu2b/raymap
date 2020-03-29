using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class SubobjectUsedAssociationInfosBuilder
    {
        private Dictionary<int, List<int>> temporaryBuildingAnimationFrames = new Dictionary<int, List<int>>();

        public void ConsiderAssociation(int subobjectNumber, int frameNumber)
        {
            if (!temporaryBuildingAnimationFrames.ContainsKey(subobjectNumber))
            {
                temporaryBuildingAnimationFrames.Add(subobjectNumber, new List<int());
            }
            temporaryBuildingAnimationFrames[subobjectNumber].Add(frameNumber);
        }

        public Dictionary<int, List<SubobjectUsedAssociationInfo>> Build()
        {
            var result = new Dictionary<int, List<SubobjectUsedAssociationInfo>>();
            foreach (var buildingExistenceFramesForSubobjects in temporaryBuildingAnimationFrames)
            {
                buildingExistenceFramesForSubobjects.Value.Sort();
                var existenceListForSubobject = new List<SubobjectUsedAssociationInfo>();
                for (int i = 0; i < buildingExistenceFramesForSubobjects.Value.Count - 1; i++)
                {
                    if (buildingExistenceFramesForSubobjects.Value[i+1] != buildingExistenceFramesForSubobjects.Value[i] + 1)
                    {

                    }
                }
            }
            return result;
        }
    }
}
