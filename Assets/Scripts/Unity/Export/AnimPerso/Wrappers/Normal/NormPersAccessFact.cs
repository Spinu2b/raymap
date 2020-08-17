using Assets.Scripts.Unity.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Unity.Export.AnimPerso.Wrappers.Normal
{
    public class NormalPersoAccessorFactory
    {
        public static NormalPersoAccessor FromPersoGameObject(GameObject persoGameObject)
        {
            var result = new NormalPersoAccessor();
            result.name = persoGameObject.name;

            PersoBehaviour persoBehaviour = persoGameObject.GetComponent<PersoBehaviour>();

            result.isLoaded = persoBehaviour.IsLoaded;
            result.perso = persoBehaviour.perso;

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


            throw new NotImplementedException();
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
