using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Common
{
    public abstract class PersoBehaviourExportInterface
    {
        public PersoBehaviourInterface persoBehaviourInterface { get; private set; }

        public PersoBehaviourExportInterface(PersoBehaviourInterface persoBehaviourInterface)
        {
            this.persoBehaviourInterface = persoBehaviourInterface;
        }

        protected IEnumerable<GameObject> IterateGameObjectsInPersoHierarchy(int animationFrameNumber)
        {
            // TODO: First set Perso hierarchy to actually reflect that animation frame!!!
            throw new NotImplementedException();
            foreach (var gameObjectTransform in UnityHierarchyHelper.IterateAllGameObjectChildrenAndSubchildrenRecursively(persoBehaviourInterface.gameObject))
            {
                yield return gameObjectTransform.gameObject;
            }
        }
    }
}
