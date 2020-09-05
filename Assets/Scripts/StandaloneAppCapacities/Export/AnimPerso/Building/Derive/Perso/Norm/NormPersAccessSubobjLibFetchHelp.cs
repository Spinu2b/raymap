using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts.IWrap;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal;
using OpenSpace;
using OpenSpace.Object;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm
{
    public static class NormalPhysicalObjectLegitimacyVerifier
    {
        public static bool HasProperGeometricDataContained(int objectIndex, PhysicalObject physicalObject)
        {
            var physicalSubobjectAccessor = new NormalPhysicalObjectSubobjectAccessor(objectIndex, physicalObject);
            foreach (Tuple<int, IGeometricObjectWrapper> interfaceGeometricObject in physicalSubobjectAccessor.physicalObject.IterateIGeometricObjects())
            {
                if (interfaceGeometricObject.Item2.IsNormalGeometricObject())
                {
                    NormalGeometricObjectWrapper geometricObject = interfaceGeometricObject.Item2.GetNormalGeometricObject();
                    foreach (Tuple<int, IGeometricObjectElementWrapper> interfaceGeometricObjectElement in
                        geometricObject.IterateIGeometricObjectElements())
                    {
                        if (interfaceGeometricObjectElement.Item2.IsNormalGeometricObjectElementTriangles())
                        {
                            NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTriangles =
                                interfaceGeometricObjectElement.Item2.GetNormalGeometricObjectElementTriangles();
                            return geometricObjectElementTriangles.HasValidGeometricDataContained();
                        }
                    }
                }
            }
            return false;
        }
    }

    public class NormalPersoAccessorSubobjectsLibraryFetchingHelper
    {
        private NormalPersoAccessor normalPersoAccessor;

        public NormalPersoAccessorSubobjectsLibraryFetchingHelper(NormalPersoAccessor normalPersoAccessor)
        {
            this.normalPersoAccessor = normalPersoAccessor;
        }

        public SubobjectsLibrary GetPersoSubobjectsLibrary()
        {
            Dictionary<int, SubobjectAccessor> legitimateSubobjects = GetLegitimateSubobjects();
            var result = new SubobjectsLibrary();

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
            // logic for that is being handled in Update() Unity method (currentPOlist, poListIndex)
            MapLoader l = MapLoader.Loader;
            if (normalPersoAccessor.perso.p3dData != null)
            {
                if (normalPersoAccessor.poListIndex > 0 && normalPersoAccessor.poListIndex < normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1)
                {
                    return ConvertObjectListToSubobjectAccessorsDict(
                        normalPersoAccessor.perso.p3dData.family.objectLists[normalPersoAccessor.poListIndex - 1]);
                } else if (normalPersoAccessor.poListIndex >= normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1 && 
                    normalPersoAccessor.poListIndex < normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1 + l.uncategorizedObjectLists.Count)
                {
                    return ConvertObjectListToSubobjectAccessorsDict(
                        l.uncategorizedObjectLists[normalPersoAccessor.poListIndex - normalPersoAccessor.perso.p3dData.family.objectLists.Count - 1]);
                } else
                {
                    //This perso has no valid objectList index, we should do something about it
                    throw new InvalidOperationException("This perso has no valid objectList index, we should do something about it");
                }
            } else
            {
                //This perso has null p3dData, we should do something about it!
                throw new InvalidOperationException("This perso has null p3dData, we should do something about it!");
            }
        }

        private Dictionary<int, SubobjectAccessor> ConvertObjectListToSubobjectAccessorsDict(ObjectList objectList)
        {
            var result = new Dictionary<int, SubobjectAccessor>();
            for (int objectIndex = 0; objectIndex < objectList.Count; objectIndex++) {
                // we're trying to add only legitimately valid objects
                if (IsValidPhysicalObjectWithProperGeometricDataContained(objectIndex, objectList[objectIndex].po))
                {
                    result.Add(objectIndex, new NormalPhysicalObjectSubobjectAccessor(objectIndex, objectList[objectIndex].po));
                }
            }
            return result;
        }

        private bool IsValidPhysicalObjectWithProperGeometricDataContained(int objectIndex, PhysicalObject physicalObject)
        {
            if (physicalObject == null)
            {
                return false;
            }
            return NormalPhysicalObjectLegitimacyVerifier.HasProperGeometricDataContained(objectIndex, physicalObject);
        }
    }
}
