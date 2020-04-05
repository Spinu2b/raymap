using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public class MaterialsTexturesImagesModelBuilder
    {
        private Dictionary<string, Material> resultMaterials = new Dictionary<string, Material>();
        private Dictionary<string, Texture> resultTextures = new Dictionary<string, Texture>();
        private Dictionary<string, Image> resultImages = new Dictionary<string, Image>();

        public void Consider(Tuple<Material, Dictionary<string, Texture>, Dictionary<string, Image>> materialModeled)
        {
            resultMaterials.Add(materialModeled.Item1.name, materialModeled.Item1);
            resultTextures.Concat(materialModeled.Item2);

            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(resultTextures, materialModeled.Item2);
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(resultImages, materialModeled.Item3);
        }

        public Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>> Build()
        {
            return new Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>
                (resultMaterials, resultTextures, resultImages);
        }
    }
}
