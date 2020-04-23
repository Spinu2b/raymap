using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.Api
{
    public class RaymapSceneHelper
    {
        public static IEnumerable<GameObject> IteratePersoGameObjects()
        {
            var persoGameObjects = UnityEngine.Object.FindObjectsOfType(typeof(PersoBehaviour)).Select(x => ((PersoBehaviour)x).gameObject).ToList();
            persoGameObjects.AddRange(UnityEngine.Object.FindObjectsOfType(typeof(ROMPersoBehaviour)).Select(x => ((ROMPersoBehaviour)x).gameObject).ToList());

            foreach (GameObject persoGameObject in persoGameObjects)
            {
                yield return persoGameObject;
            }
        }

        public static Controller GetController()
        {
            return (Controller)UnityEngine.Object.FindObjectOfType(typeof(Controller));
        }
    }
}
