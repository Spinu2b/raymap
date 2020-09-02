using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Visuals.Trans
{
    public static class Texture2DOrImageToVisualDataTransformer
    {
        public static Tuple<Image, Texture2D>
            GetImageAndVisualDataTexture2DForResourcesModelTexture2D(ResourcesModel.Visuals.Texture2D textureModel)
        {
            var resultImage = new ExportImageBuilder().SetPixels(
                textureModel.width, textureModel.height, textureModel.GetPixels().Select(x => Color.FromResourcesModelColor(x)).ToList()).Build();
            var resultTexture = GetAppropriateTexture2DObjectForImage(resultImage);
            return new Tuple<Image, Texture2D>(resultImage, resultTexture);
        }

        public static Texture2D GetAppropriateTexture2DObjectForImage(Image image)
        {
            var result = new Texture2D();
            result.imageIdentifier = image.imageDescriptionIdentifier;
            result.textureDescriptionIdentifier = result.ComputeIdentifier();
            return result;
        }
    }

    public static class MiscellaneousVisualModelToVisualDataTransformer
    {
        public static VisualData TransformResourcesModelTexture2DToVisualData(ResourcesModel.Visuals.Texture2D textureModel)
        {
            Tuple<Image, Texture2D> visualDataImageAndTexture2D = Texture2DOrImageToVisualDataTransformer.GetImageAndVisualDataTexture2DForResourcesModelTexture2D(textureModel);
            var visualData = new VisualDataBuilder()
                .SetImages(
                new Dictionary<string, Image> { { visualDataImageAndTexture2D.Item1.imageDescriptionIdentifier, visualDataImageAndTexture2D.Item1 } })
                .SetTextures(
                new Dictionary<string, Texture2D> { { visualDataImageAndTexture2D.Item2.textureDescriptionIdentifier, visualDataImageAndTexture2D.Item2 } }
                ).Build();
            return visualData;
        }

        public static VisualData TransformImageToVisualData(Image image)
        {
            var accompanyingTexture2D = Texture2DOrImageToVisualDataTransformer.GetAppropriateTexture2DObjectForImage(image);
            var visualData = new VisualDataBuilder()
                .SetImages(
                new Dictionary<string, Image> { { image.imageDescriptionIdentifier, image } })
                .SetTextures(
                new Dictionary<string, Texture2D> { { accompanyingTexture2D.textureDescriptionIdentifier, accompanyingTexture2D } }
                ).Build();
            return visualData;
        }
    }
}
