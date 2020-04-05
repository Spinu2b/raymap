using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
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

            MergeSeparableDictionariesToFirstDict(resultTextures, materialModeled.Item2);
            MergeSeparableDictionariesToFirstDict(resultImages, materialModeled.Item3);
        }

        public Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>> Build()
        {
            return new Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>
                (resultMaterials, resultTextures, resultImages);
        }

        private void MergeSeparableDictionariesToFirstDict<T>(Dictionary<string, T> dictA, Dictionary<string, T> dictB) where T : IComparableModel<T> {
            foreach (var item in dictB)
            {
                if (!dictA.ContainsKey(item.Key))
                {
                    dictA.Add(item.Key, item.Value);
                } else
                {
                    if (dictA[item.Key].EqualsToAnother(item.Value))
                    {
                        dictA.Add(item.Key, item.Value);
                    } else
                    {
                        throw new InvalidOperationException("Attempting to merge material-associated models with same keys but indeed being different!");
                    }
                }
            }
        }
    }
}
