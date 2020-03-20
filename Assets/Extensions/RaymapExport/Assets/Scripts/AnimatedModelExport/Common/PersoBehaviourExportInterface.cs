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

        protected IEnumerable<GameObject> IterateGameObjectsInPersoHierarchy()
        {
            throw new NotImplementedException();
        }
    }
}
