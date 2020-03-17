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
            foreach (PersoBehaviour persoBehaviour in UnityEngine.Object.FindObjectsOfType(typeof(PersoBehaviour)))
            {
                yield return persoBehaviour.gameObject;
            }
        }
    }
}
