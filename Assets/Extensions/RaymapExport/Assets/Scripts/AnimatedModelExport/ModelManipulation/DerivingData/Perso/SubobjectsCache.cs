﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
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

        private MaterialsTexturesImagesCache materialsTexturesImagesCache = new MaterialsTexturesImagesCache();

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
                subobjectsCache[physicalObjectNumber] = GetSubobjectModel(physicalObject, physicalObjectNumber, channelId);
                newlyAdded = true;
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
                    var existingPhysicalObject = subobjectsCache[physicalObjectNumber];
                    if (!existingPhysicalObject.EqualsToAnother(GetSubobjectModel(physicalObject, physicalObjectNumber, channelId)))
                    {
                        throw new InvalidOperationException(
                            "Two physical objects share same physical object number, but they are not the same physical object!");
                    }
                }
                subobjectsAnimationFramesPersoStatesAssociationsCache[stateIndex][animationFrame].Add(physicalObjectNumber);
            }
            materialsTexturesImagesCache.ConsiderPhysicalObject(physicalObject, stateIndex, animationFrame, channelId, physicalObjectNumber);
        }

        private SubobjectModel GetSubobjectModel(PhysicalObjectWrapper physicalObject, int physicalObjectNumber, int channelId)
        {
            return physicalObjectToSubobjectModelConverter.Convert(physicalObject, physicalObjectNumber, channelId);
        }

        public Tuple<SubobjectModel,
            Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>
            GetPhysicalObjectCachedModelFor(int physicalObjectNumber)
        {
            var materialsTexturesImagesForPhysicalObject = materialsTexturesImagesCache.GetMaterialsTexturesImagesCachedModelFor(physicalObjectNumber);

            return new Tuple<SubobjectModel,
            Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>(
                subobjectsCache[physicalObjectNumber], materialsTexturesImagesForPhysicalObject.Item1, 
                materialsTexturesImagesForPhysicalObject.Item2, materialsTexturesImagesForPhysicalObject.Item3);
        }
    }
}
