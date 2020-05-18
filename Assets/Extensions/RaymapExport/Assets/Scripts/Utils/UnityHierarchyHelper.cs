using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils
{
    public class UnityHierarchyHelper
    {
        public static IEnumerable<Transform> IterateAllGameObjectChildrenAndSubchildrenRecursively(GameObject gao)
        {
            var transformSubChildrenList = new List<Transform>();

            TraverseRecursively(gao, transformSubChildrenList);

            foreach (var transform in transformSubChildrenList)
            {
                yield return transform;
            }
        }

        private static void TraverseRecursively(GameObject gao, List<Transform> transformSubChildrenList)
        {
            foreach (Transform child in gao.transform)
            {
                transformSubChildrenList.Add(child);
                TraverseRecursively(child.gameObject, transformSubChildrenList);
            }
        }
    }
}
