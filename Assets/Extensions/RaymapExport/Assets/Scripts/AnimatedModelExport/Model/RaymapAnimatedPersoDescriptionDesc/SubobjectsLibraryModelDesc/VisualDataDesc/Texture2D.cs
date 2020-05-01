using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc
{
    public class Texture2D : IExportModel, IComparableModel<Texture2D>
    {
        public string textureDescriptionHash;
        public string image;

        public bool EqualsToAnother(Texture2D other)
        {
            return textureDescriptionHash.Equals(other.textureDescriptionHash);
        }
    }
}
