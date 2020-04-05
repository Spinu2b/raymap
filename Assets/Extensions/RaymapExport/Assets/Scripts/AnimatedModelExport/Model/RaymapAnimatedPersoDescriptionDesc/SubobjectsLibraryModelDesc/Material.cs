using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc
{
    public class Material : IComparableModel<Material>
    {
        public string name;
        public List<string> textures = new List<string>();

        public bool EqualsToAnother(Material other)
        {
            throw new NotImplementedException();
        }
    }
}
