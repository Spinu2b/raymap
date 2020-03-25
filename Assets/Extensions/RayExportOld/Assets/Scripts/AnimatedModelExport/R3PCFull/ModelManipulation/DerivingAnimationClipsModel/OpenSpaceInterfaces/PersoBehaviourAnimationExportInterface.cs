using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.Common;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces
{
    public class PersoBehaviourAnimationExportInterface : PersoBehaviourExportInterface
    {
        public PersoBehaviourAnimationExportInterface(PersoBehaviourInterface persoBehaviourInterface) : base(persoBehaviourInterface) { }

        public IEnumerable<AnimHierarchyWithChannelInfo> IterateAnimHierarchiesWithChannelInfosForGivenFrame(int animationFrameNumber)
        {
            foreach (var persoHierarchyGameObject in IterateGameObjectsInPersoHierarchy(animationFrameNumber))
            {
                if (IsChannelObject(persoHierarchyGameObject))
                {
                    var parentChannelGameObject = GetParentChannelGameObject(persoHierarchyGameObject);
                    var isKeyframedChannel = GetChannelCurrentKeyframeStatus(persoHierarchyGameObject);
                    yield return new AnimHierarchyWithChannelInfo(parentChannelGameObject?.name, persoHierarchyGameObject.name,
                        persoHierarchyGameObject.transform.localPosition, persoHierarchyGameObject.transform.localRotation,
                        persoHierarchyGameObject.transform.localScale, isKeyframedChannel);
                }
            }
        }

        private bool GetChannelCurrentKeyframeStatus(GameObject persoHierarchyGameObject)
        {
            return persoBehaviourInterface.GetChannelOfIndexKeyframeState(GetChannelIndex(persoHierarchyGameObject));
        }

        private int GetChannelIndex(GameObject channelGameObject)
        {
            return int.Parse(Regex.Match(channelGameObject.name, "[0-9]+").Value);
        }

        private GameObject GetParentChannelGameObject(GameObject persoHierarchyGameObject)
        {
            var parent = persoHierarchyGameObject.transform.parent.gameObject;
            while (!IsRootPersoHierarchyGameObject(parent) && !IsChannelObject(parent))
            {
                parent = parent.transform.parent.gameObject;
            }
            if (IsRootPersoHierarchyGameObject(parent))
            {
                return null;
            } else if (IsChannelObject(parent))
            {
                return parent;
            } else
            {
                throw new InvalidOperationException("Something strange happened during search for channel parent in Perso hierarchy.");
            }
        }

        private bool IsChannelObject(GameObject persoHierarchyGameObject)
        {
            return persoHierarchyGameObject.name.Contains("Channel");
        }
    }
}
