using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Common;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces
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
                    yield return new AnimHierarchyWithChannelInfo(parentChannelGameObject.name, persoHierarchyGameObject.name,
                        persoHierarchyGameObject.transform.localPosition, persoHierarchyGameObject.transform.localRotation,
                        persoHierarchyGameObject.transform.localScale, isKeyframedChannel);
                }
            }
        }

        private bool GetChannelCurrentKeyframeStatus(GameObject persoHierarchyGameObject)
        {
            throw new NotImplementedException();
        }

        private GameObject GetParentChannelGameObject(GameObject persoHierarchyGameObject)
        {
            throw new NotImplementedException();
        }

        private bool IsChannelObject(GameObject persoHierarchyGameObject)
        {
            throw new NotImplementedException();
        }
    }
}
