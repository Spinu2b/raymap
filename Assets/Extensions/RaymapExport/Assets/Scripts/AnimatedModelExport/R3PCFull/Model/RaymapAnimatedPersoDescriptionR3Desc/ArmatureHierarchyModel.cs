using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc
{
    public class ArmatureHierarchyModelNode
    {
        public string name;

        public ArmatureHierarchyModelNode(string name)
        {
            this.name = name;
        }
    }

    public class ArmatureHierarchyModel : Tree<ArmatureHierarchyModelNode, string>
    {
    }
}
