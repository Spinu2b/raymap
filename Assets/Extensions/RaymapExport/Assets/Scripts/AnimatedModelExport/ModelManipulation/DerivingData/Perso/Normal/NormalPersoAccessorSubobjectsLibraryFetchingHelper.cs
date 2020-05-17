using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal;
using OpenSpace;
using OpenSpace.Object;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoAccessorSubobjectsLibraryFetchingHelper 
    {
        private NormalPersoAccessor normalPersoAccessor;

        public NormalPersoAccessorSubobjectsLibraryFetchingHelper(NormalPersoAccessor normalPersoAccessor)
        {
            this.normalPersoAccessor = normalPersoAccessor;
        }

        public SubobjectsLibraryModel GetPersoSubobjectsLibrary()
        {
            Dictionary<int, SubobjectAccessor> legitimateSubobjects = GetLegitimateSubobjects();
            var result = new SubobjectsLibraryModel();

            foreach (var entry in legitimateSubobjects)
            {
                result.subobjects.Add(entry.Key, entry.Value.GetSubobjectModel());
            }
            result.visualData = VisualDataUnifier.Unify(legitimateSubobjects.Select(x => x.Value.GetVisualData()).ToList());
            return result;
        }

        private Dictionary<int, SubobjectAccessor> GetLegitimateSubobjects()
        {
            //we should wait some interval after level loading for logic in PersoBehaviour-kind classes to properly assign objectList to that game entity
            // logic for that is being handled in Update() Unity method (currentPOList, poListIndex)
            MapLoader l = MapLoader.Loader;
            if (normalPersoAccessor.perso.p3dData != null)
            {
                if (normalPersoAccessor.poListIndex > 0 && normalPersoAccessor.poListIndex < normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1)
                {
                    return ConvertObjectListToSubobjectAccessorsDict(
                        normalPersoAccessor.perso.p3dData.family.objectLists[normalPersoAccessor.poListIndex - 1]);
                }
                else if (normalPersoAccessor.poListIndex >= normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1 &&
                    normalPersoAccessor.poListIndex < normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1 + l.uncategorizedObjectLists.Count)
                {
                    return ConvertObjectListToSubobjectAccessorsDict(
                        l.uncategorizedObjectLists[normalPersoAccessor.poListIndex - normalPersoAccessor.perso.p3dData.family.objectLists.Count - 1]);
                }
                else
                {
                    throw new InvalidOperationException("This perso has no valid objectList index, we should something about it");
                }
            }
            else
            {
                throw new InvalidOperationException("This perso has null p3dData, we should something about it");
            }
        }

        private Dictionary<int, SubobjectAccessor> ConvertObjectListToSubobjectAccessorsDict(ObjectList objectList)
        {
            var result = new Dictionary<int, SubobjectAccessor>();
            for (int objectIndex = 0; objectIndex < objectList.Count; objectIndex++)
            {
                // we're trying to add only legitimately valid objects
                if (objectList[objectIndex].po != null)
                {
                    result.Add(objectIndex, new NormalPhysicalObjectSubobjectAccessor(objectIndex, objectList[objectIndex].po, normalPersoAccessor.environmentContext));
                }
            }
            return result;
        }
    }
}
