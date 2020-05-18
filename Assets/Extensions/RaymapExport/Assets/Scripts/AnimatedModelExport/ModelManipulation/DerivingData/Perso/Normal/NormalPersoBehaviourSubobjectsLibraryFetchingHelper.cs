using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using OpenSpace;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourSubobjectsLibraryFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourSubobjectsLibraryFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) { }

        private PhysicalObjectToSubobjectModelConverter physicalObjectToSubobjectModelConverter = new PhysicalObjectToSubobjectModelConverter();

        public SubobjectsLibraryModel GetPersoBehaviourSubobjectsLibrary()
        {
            var legitimatePhysicalObjects = GetLegitimatePhysicalObjects();
            var result = new SubobjectsLibraryModel();
            //result.subobjects = legitimatePhysicalObjects.ToDictionary(x => x.Key, x => physicalObjectToSubobjectModelConverter.Convert(x.Value, x.Key));
            
            foreach (var entry in legitimatePhysicalObjects)
            {
                result.subobjects.Add(entry.Key, physicalObjectToSubobjectModelConverter.Convert(entry.Value, entry.Key));
            }

            result.visualData = VisualDataUnifier.Unify(legitimatePhysicalObjects.Select(x => x.Value.GetVisualData()).ToList());
            return result;
        }
        private Dictionary<int, PhysicalObjectWrapper> ConvertObjectListToPhysicalObjectWrappersDict(ObjectList objectList)

        {
            var result = new Dictionary<int, PhysicalObjectWrapper>();
            for (int objectIndex = 0; objectIndex < objectList.Count; objectIndex++)
            {
                // we're trying to add only legitimately valid objects
                if (objectList[objectIndex].po != null)
                {
                    result.Add(objectIndex, PhysicalObjectWrapper.FromRaymapNormalPhysicalObject(objectList[objectIndex].po));
                }                
            }
            return result;
        }

        private Dictionary<int, PhysicalObjectWrapper> GetLegitimatePhysicalObjects()
        {
            //we should wait some interval after level loading for logic in PersoBehaviour-kind classes to properly assign objectList to that game entity
            // logic for that is being handled in Update() Unity method (currentPOList, poListIndex)
            MapLoader l = MapLoader.Loader;
            if (persoBehaviour.perso.p3dData != null)
            {
                if (persoBehaviour.poListIndex > 0 && persoBehaviour.poListIndex < persoBehaviour.perso.p3dData.family.objectLists.Count + 1)
                {
                    //currentPOList = poListIndex;
                    //perso.p3dData.objectList = perso.p3dData.family.objectLists[currentPOList - 1];
                    //return ConvertObjectListToPhysicalObjectWrappersDict(persoBehaviour.perso.p3dData.family.objectLists[persoBehaviour.currentPOList - 1]); 
                    return ConvertObjectListToPhysicalObjectWrappersDict(
                        persoBehaviour.perso.p3dData.family.objectLists[persoBehaviour.poListIndex - 1]);
                }
                else if (persoBehaviour.poListIndex >= persoBehaviour.perso.p3dData.family.objectLists.Count + 1 &&
                    persoBehaviour.poListIndex < persoBehaviour.perso.p3dData.family.objectLists.Count + 1 + l.uncategorizedObjectLists.Count)
                {
                    //currentPOList = poListIndex;
                    //perso.p3dData.objectList = l.uncategorizedObjectLists[currentPOList - perso.p3dData.family.objectLists.Count - 1];
                    //return ConvertObjectListToPhysicalObjectWrappersDict(l.uncategorizedObjectLists[currentPOList - perso.p3dData.family.objectLists.Count - 1]);
                    return ConvertObjectListToPhysicalObjectWrappersDict(
                        l.uncategorizedObjectLists[persoBehaviour.poListIndex - persoBehaviour.perso.p3dData.family.objectLists.Count - 1]);
                }
                else
                {
                    //poListIndex = 0;
                    //currentPOList = 0;
                    //perso.p3dData.objectList = null;
                    throw new InvalidOperationException("This perso has no valid objectList index, we should something about it");

                }
            } else
            {
                throw new InvalidOperationException("This perso has null p3dData, we should something about it");
            }
        }
    }
}
