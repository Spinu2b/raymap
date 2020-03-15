using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.Utils
{
    public class PersoChannelsHierarchyHelper
    {
        public static Transform GetProperChannelForTransform(Transform transform)
        {
            if (transform.gameObject.name.Contains("Channel"))
            {
                return transform;
            }

            Transform currentCandidate = transform.parent;
            while (!currentCandidate.gameObject.name.Contains("Channel"))
            {
                if (currentCandidate.parent == null)
                {
                    throw new InvalidOperationException("Did not find appropriate channel for that gameObject! " + transform.gameObject.name);
                }
                currentCandidate = currentCandidate.parent;
            }
            return currentCandidate;
        }

        public static string GetParentChannelNameOrNullIfNotPresent(Transform transform)
        {
            Transform currentCandidate = transform.parent;
            while (currentCandidate != null && !currentCandidate.gameObject.name.Contains("Channel"))
            {
                currentCandidate = currentCandidate.parent;
            }
            return currentCandidate?.name;
        }
    }
}
