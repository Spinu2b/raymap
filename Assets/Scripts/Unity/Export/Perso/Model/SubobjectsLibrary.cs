using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.Perso.Model
{
    public class SubobjectsLibrary
    {
        public VisualData visualData = new VisualData();
        public Dictionary<int, Subobject> subobjects = new Dictionary<int, Subobject>();
    }
}
