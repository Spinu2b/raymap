using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc
{
    public class VisualData : IComparableModel<VisualData>
    {
        public Dictionary<string, Material> materials = new Dictionary<string, Material>();
        public Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        public Dictionary<string, Image> images = new Dictionary<string, Image>();

        public bool EqualsToAnother(VisualData other)
        {
            return ComparableModelDictionariesComparator.AreDictionariesCompliant(materials, other.materials) &&
                ComparableModelDictionariesComparator.AreDictionariesCompliant(textures, other.textures) &&
                ComparableModelDictionariesComparator.AreDictionariesCompliant(images, other.images);
        }
    }
}
