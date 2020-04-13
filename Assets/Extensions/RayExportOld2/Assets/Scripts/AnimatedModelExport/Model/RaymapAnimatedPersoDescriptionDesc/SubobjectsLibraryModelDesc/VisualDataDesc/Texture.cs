using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc
{
    public class Texture : IComparableModel<Texture>
    {
        public string textureDescriptionHash;
        public string image;

        public bool EqualsToAnother(Texture other)
        {
            return textureDescriptionHash.Equals(other.textureDescriptionHash);
        }
    }
}
