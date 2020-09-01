using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Visuals.Trans
{
    public static class ResourcesModelTexture2DToVisualDataTransformer
    {
        public static VisualData Transform(ResourcesModel.Visuals.Texture2D textureModel)
        {
            Tuple<Image, Texture2D> visualDataImageAndTexture2D = GetImageAndVisualDataTexture2DFor(textureModel);
            var visualData = new VisualDataBuilder()
                .SetImages(
                new Dictionary<string, Image> { { visualDataImageAndTexture2D.Item1.imageDescriptionIdentifier, visualDataImageAndTexture2D.Item1 } })
                .SetTextures(
                new Dictionary<string, Texture2D> { { visualDataImageAndTexture2D.Item2.textureDescriptionIdentifier, visualDataImageAndTexture2D.Item2 } }
                ).Build();
            return visualData;
        }

        private static Tuple<Image, Texture2D>
            GetImageAndVisualDataTexture2DFor(ResourcesModel.Visuals.Texture2D textureModel)
        {
            var resultImage = new Image();
            var resultTexture = new Texture2D();

            throw new NotImplementedException();

            return new Tuple<Image, Texture2D>(resultImage, resultTexture);
        }
    }
}
