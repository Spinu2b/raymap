using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class SubobjectsCache
    {
        private Dictionary<int, Dictionary<int, List<int>>> subobjectsAnimationFramesPersoStatesAssociationsCache
             = new Dictionary<int, Dictionary<int, List<int>>>();
        private Dictionary<int, SubobjectModel> subobjectsCache = new Dictionary<int, SubobjectModel>();

        private PhysicalObjectToSubobjectModelConverter physicalObjectToSubobjectModelConverter = new PhysicalObjectToSubobjectModelConverter();

        public void ConsiderPhysicalObject(PhysicalObject physicalObject, int stateIndex, int animationFrame, int channelId, int physicalObjectNumber)
        {
            var physicalObjectWrapper = new PhysicalObjectWrapper(physicalObject);
            ConsiderPhysicalObject(physicalObjectWrapper, stateIndex, animationFrame, channelId, physicalObjectNumber);
        }

        private void ConsiderPhysicalObject(PhysicalObjectWrapper physicalObject, int stateIndex, int animationFrame, int channelId, int physicalObjectNumber)
        {
            if (!subobjectsCache.ContainsKey(physicalObjectNumber))
            {
                subobjectsCache[physicalObjectNumber] = GetSubobjectModel(physicalObject, physicalObjectNumber, channelId);
            }
            if (!subobjectsAnimationFramesPersoStatesAssociationsCache[stateIndex][animationFrame].Contains(physicalObjectNumber))
            {
                subobjectsAnimationFramesPersoStatesAssociationsCache[stateIndex][animationFrame].Add(physicalObjectNumber);
            }            
        }

        private SubobjectModel GetSubobjectModel(PhysicalObjectWrapper physicalObject, int physicalObjectNumber, int channelId)
        {
            return physicalObjectToSubobjectModelConverter.Convert(physicalObject, physicalObjectNumber, channelId);
        }

        public SubobjectModel GetPhysicalObjectCachedModelFor(int physicalObjectNumber)
        {
            throw new NotImplementedException();
        }
    }
}
