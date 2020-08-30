using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj
{
    public abstract class SubobjectAccessor
    {
        public abstract Subobject GetSubobjectModel();
        public abstract VisualData GetVisualData();
    }
}
