using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts.IWrap;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Unity;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm;
using Assets.Scripts.StandaloneAppCapacities.Export.Wrappers;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal
{
    public static class SubobjectsValidityVerifier
    {
        public static bool GivenSubobjectsContainAnyBindBonePosesData(PhysicalObject[][] subObjects)
        {
            return subObjects != null && subObjects.Where(x => SubobjectsSubarrayContainsAnyBindBonePosesData(x)).Count() != 0;
        }

        private static bool SubobjectsSubarrayContainsAnyBindBonePosesData(PhysicalObject[] subObjectsSubarray)
        {
            return subObjectsSubarray != null && subObjectsSubarray.Where(
                x => PhysicalObjectValidityVerifier.ContainsAnyBindBonePosesData(x)).Count() != 0;
        }
    }

    public class NormalPersoAccessorFactory
    {
        public static NormalPersoAccessor FromPersoGameObject(GameObject persoGameObject)
        {
            var result = new NormalPersoAccessor();
            result.name = persoGameObject.name;

            PersoBehaviour persoBehaviour = persoGameObject.GetComponent<PersoBehaviour>();

            //if (!ObjectListValidityVerifier.ObjectListContainsObjectsWithAnyBindBonePosesData(
            //    persoBehaviour.perso.p3dData.family.objectLists[persoBehaviour.poListIndex - 1])) {
            //    throw new InvalidOperationException();
            //}

            /* * /
            if (!SubobjectsValidityVerifier.GivenSubobjectsContainAnyBindBonePosesData(persoBehaviour.subObjects))
            {
                throw new InvalidOperationException();
            } else
            {
                // wow!
                int bbb = 0;
            }
            /* */

            result.isLoaded = persoBehaviour.IsLoaded;
            result.perso = persoBehaviour.perso;
            result.controller = persoBehaviour.controller;

            result.animLargo = persoBehaviour.animLargo;
            result.animMontreal = persoBehaviour.animMontreal;
            result.a3d = persoBehaviour.a3d;

            result.subObjects = GetSubobjects(persoBehaviour);
            result.channelObjects = GetChannelObjects(persoBehaviour);

            result.poListIndex = persoBehaviour.poListIndex;
            result.morphDataArray = persoBehaviour.morphDataArray;

            result.hasBones = (bool)persoBehaviour.GetType().GetField(
                "hasBones", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance).GetValue(persoBehaviour);

            result.channelIDDictionary = CloneChannelIDDictionary(persoBehaviour);

            InitPhysicalObjectsGeometricDataInPersoFamilyAppropriateObjectList(result);
            return result;
        }

        private static void InitPhysicalObjectsGeometricDataInPersoFamilyAppropriateObjectList(
            NormalPersoAccessor normalPersoAccessor)
        {
            normalPersoAccessor.InitPhysicalObjectsGeometricDataInPersoFamilyAppropriateObjectList();
        }

        private static ActualManifestableUnityGameObject[] GetChannelObjects(PersoBehaviour persoBehaviour)
        {
            return persoBehaviour.channelObjects.Select(x => new ActualManifestableUnityGameObject()).ToArray();
        }

        private static PhysicalObject[][] GetSubobjects(PersoBehaviour persoBehaviour)
        {
            var result = new List<List<PhysicalObject>>();
            int sublistIndex = 0;

            foreach (var physicalObjectsArray in persoBehaviour.subObjects)
            {
                result.Add(new List<PhysicalObject>());
                int physicalObjectNumber = 0;
                foreach (var physicalObject in physicalObjectsArray)
                {
                    result[sublistIndex].Add(null);
                    if (physicalObject != null)
                    {
                        result[sublistIndex][physicalObjectNumber] = physicalObject.CloneWithMockedUnityApi();
                    } else
                    {
                        result[sublistIndex][physicalObjectNumber] = null;
                    }
                    physicalObjectNumber++;
                }
                sublistIndex++;
            }

            return result.Select(x => x.ToArray()).ToArray();
        }

        private static Dictionary<short, List<int>> CloneChannelIDDictionary(PersoBehaviour persoBehaviour)
        {
            var result = new Dictionary<short, List<int>>();

            var originalChannelIDDictionary = (Dictionary<short, List<int>>)persoBehaviour.GetType().GetField(
                "channelIDDictionary", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance).GetValue(persoBehaviour);

            foreach (var sublistKey in originalChannelIDDictionary.Keys)
            {
                result[sublistKey] = originalChannelIDDictionary[sublistKey].Select(x => x).ToList();
            }
            return result;
        }
    }
}
