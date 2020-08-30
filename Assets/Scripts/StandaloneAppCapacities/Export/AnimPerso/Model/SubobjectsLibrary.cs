using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model
{
    public class SubobjectsLibrary
    {
        public VisualData visualData = new VisualData();
        public Dictionary<int, Subobject> subobjects = new Dictionary<int, Subobject>();
    }
}
