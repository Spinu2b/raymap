using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc

{
    public class Material : IExportModel, IComparableModel<Material>
    {
        public string materialDescriptionHash;
        public List<string> textures = new List<string>();
        public bool isTransparent;

        public bool EqualsToAnother(Material other)
        {
            return materialDescriptionHash.Equals(other.materialDescriptionHash);
        }
    }
}
