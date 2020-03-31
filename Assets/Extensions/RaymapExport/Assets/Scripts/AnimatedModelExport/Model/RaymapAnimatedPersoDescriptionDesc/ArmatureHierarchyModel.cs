using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc
{
    public class ArmatureHierarchyModel
    {
        public List<int> channels = new List<int>();
        public Dictionary<int, int> parenting = new Dictionary<int, int>();
    }
}
