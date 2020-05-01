using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc
{
    public class VisualData : IExportModel, IComparableModel<VisualData>
    {
        public Dictionary<string, Material> materials = new Dictionary<string, Material>();
        public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public Dictionary<string, Image> images = new Dictionary<string, Image>();

        public bool EqualsToAnother(VisualData other)
        {
            return ComparableModelDictionariesComparator.AreDictionariesCompliant(materials, other.materials) &&
                ComparableModelDictionariesComparator.AreDictionariesCompliant(textures, other.textures) &&
                ComparableModelDictionariesComparator.AreDictionariesCompliant(images, other.images);
        }
    }
}
