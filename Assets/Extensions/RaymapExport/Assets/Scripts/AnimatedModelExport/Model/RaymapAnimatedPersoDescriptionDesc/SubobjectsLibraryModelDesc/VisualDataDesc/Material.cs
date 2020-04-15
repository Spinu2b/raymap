using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc

{
    public class Material : IComparableModel<Material>
    {
        public string materialDescriptionHash;
        public List<string> textures = new List<string>();

        public bool EqualsToAnother(Material other)
        {
            return materialDescriptionHash.Equals(other.materialDescriptionHash);
        }
    }
}
