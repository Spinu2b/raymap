using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm;
using OpenSpace;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal
{
    public static class NormalPersoAccessorPhysicalObjectsFamilyInitializationHelper
    {
        public static void InitializeObjectsWithGeometricData(NormalPersoAccessor normalPersoAccessor)
        {
            MapLoader l = MapLoader.Loader;
            if (normalPersoAccessor.perso.p3dData != null)
            {
                if (normalPersoAccessor.poListIndex > 0 && normalPersoAccessor.poListIndex < normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1)
                {
                    InitializeObjectListWithGeometricData(
                        normalPersoAccessor.perso.p3dData.family.objectLists[normalPersoAccessor.poListIndex - 1]);
                }
                else if (normalPersoAccessor.poListIndex >= normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1 &&
                  normalPersoAccessor.poListIndex < normalPersoAccessor.perso.p3dData.family.objectLists.Count + 1 + l.uncategorizedObjectLists.Count)
                {
                    InitializeObjectListWithGeometricData(
                        l.uncategorizedObjectLists[normalPersoAccessor.poListIndex - normalPersoAccessor.perso.p3dData.family.objectLists.Count - 1]);
                }
                else
                {
                    //This perso has no valid objectList index, we should do something about it
                    throw new InvalidOperationException("This perso has no valid objectList index, we should do something about it");
                }
            }
            else
            {
                //This perso has null p3dData, we should do something about it!
                throw new InvalidOperationException("This perso has null p3dData, we should do something about it!");
            }
        }

        private static void InitializeObjectListWithGeometricData(ObjectList objectList)
        {
            for (int objectIndex = 0; objectIndex < objectList.Count; objectIndex++)
            {
                // we're trying to operate only on legitimately valid objects
                if (NormalPhysicalObjectLegitimacyVerifier.IsValidPhysicalObjectAtAll(objectIndex, objectList[objectIndex].po))
                {
                    var normalPhysicalObjectSubobjectAccessor = new NormalPhysicalObjectSubobjectAccessor(objectIndex, objectList[objectIndex].po);
                    foreach (var entry in normalPhysicalObjectSubobjectAccessor.physicalObject.IterateNormalGeometricObjectElementTriangles())
                    {
                        entry.Item2.ReinitGeometricData();
                    }
                }
            }
        }
    }

    public partial class NormalPersoAccessor
    {
        public List<int> GetChannelByID(short id)
        {
            if (channelIDDictionary.ContainsKey(id))
            {
                return channelIDDictionary[id];
            }
            else return new List<int>();
        }

        public void InitPhysicalObjectsGeometricDataInPersoFamilyAppropriateObjectList()
        {
            NormalPersoAccessorPhysicalObjectsFamilyInitializationHelper.InitializeObjectsWithGeometricData(this);
        }
    }
}
