using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Common
{
    public class PersoBehaviourInterface
    {
        private PersoBehaviour persoBehaviour;
        private ROMPersoBehaviour romPersoBehaviour;

        public PersoBehaviourInterface(PersoBehaviour persoBehaviour)
        {
            this.persoBehaviour = persoBehaviour;
        }

        public PersoBehaviourInterface(ROMPersoBehaviour romPersoBehaviour)
        {
            this.romPersoBehaviour = romPersoBehaviour;
        }
    }
}
