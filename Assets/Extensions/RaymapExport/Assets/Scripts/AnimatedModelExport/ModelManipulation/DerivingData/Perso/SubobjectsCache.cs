using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Cache
{
    public class SubobjectCacheBlock : IComparableModel<SubobjectCacheBlock>
    {
        public SubobjectModel subobject;
        public VisualData visualData;

        public bool EqualsToAnother(SubobjectCacheBlock other)
        {
            return subobject.EqualsToAnother(other.subobject) && visualData.EqualsToAnother(other.visualData);
        }
    }

    public class SubobjectsCache
    {
        private Dictionary<int, Dictionary<int, List<int>>> subobjectsAnimationFramesPersoStatesAssociationsCache
             = new Dictionary<int, Dictionary<int, List<int>>>();
        private Dictionary<int, SubobjectCacheBlock> subobjectsCache = new Dictionary<int, SubobjectCacheBlock>();

        private PhysicalObjectToSubobjectModelConverter physicalObjectToSubobjectModelConverter = new PhysicalObjectToSubobjectModelConverter();

        public void ConsiderPhysicalObject(PhysicalObject physicalObject, int stateIndex, int animationFrame, int channelId, int physicalObjectNumber)
        {
            var physicalObjectWrapper = PhysicalObjectWrapper.FromRaymapNormalPhysicalObject(physicalObject);
            ConsiderPhysicalObject(physicalObjectWrapper, stateIndex, animationFrame, channelId, physicalObjectNumber);
        }

        private void ConsiderPhysicalObject(PhysicalObjectWrapper physicalObject, int stateIndex, int animationFrame, int channelId, int physicalObjectNumber)
        {
            bool newlyAdded = false;
            if (!subobjectsCache.ContainsKey(physicalObjectNumber))
            {
                subobjectsCache[physicalObjectNumber] = GetSubobjectDescriptiveModel(physicalObject, physicalObjectNumber, channelId);
                newlyAdded = true;
            } 
            else
            {
                PhysicalObjectModelsBasicComplianceVerifier.VerifyBasicCompliance(
                    subobjectsCache[physicalObjectNumber].subobject, physicalObject);
            }
            if (!subobjectsAnimationFramesPersoStatesAssociationsCache.ContainsKey(stateIndex))
            {
                subobjectsAnimationFramesPersoStatesAssociationsCache.Add(stateIndex, new Dictionary<int, List<int>>());
            }
            if (!subobjectsAnimationFramesPersoStatesAssociationsCache[stateIndex].ContainsKey(animationFrame))
            {
                subobjectsAnimationFramesPersoStatesAssociationsCache[stateIndex].Add(animationFrame, new List<int>());
            }
            if (!subobjectsAnimationFramesPersoStatesAssociationsCache[stateIndex][animationFrame].Contains(physicalObjectNumber))
            {
                if (!newlyAdded)
                {
                    // if we ensure that physical object indexes/ids/numbers satisfy that number-unique contract across OpenSpace versions consequently
                    // we can omit consecutive comparisons and repeating model conversions to speed up the process (that is what this cache is for in the first place)
                    
                    //var existingPhysicalObjectDescriptiveModel = subobjectsCache[physicalObjectNumber];
                    //if (!existingPhysicalObjectDescriptiveModel.EqualsToAnother(GetSubobjectDescriptiveModel(physicalObject, physicalObjectNumber, channelId)))
                    //{
                    //    throw new InvalidOperationException(
                    //        "Two physical objects share same physical object number, but they are not the same physical object!");
                    //}
                }
                subobjectsAnimationFramesPersoStatesAssociationsCache[stateIndex][animationFrame].Add(physicalObjectNumber);
            }
        }

        private SubobjectCacheBlock GetSubobjectDescriptiveModel(PhysicalObjectWrapper physicalObject, int physicalObjectNumber, int channelId)
        {
            var result = new SubobjectCacheBlock();
            result.subobject = physicalObjectToSubobjectModelConverter.Convert(physicalObject, physicalObjectNumber, channelId);
            result.visualData = physicalObject.GetVisualData();
            return result;
        }

        public Tuple<SubobjectModel, VisualData> GetPhysicalObjectCachedModelFor(int physicalObjectNumber)
        {
            var result = subobjectsCache[physicalObjectNumber];
            return new Tuple<SubobjectModel, VisualData>(result.subobject, result.visualData);
        }
    }
}
