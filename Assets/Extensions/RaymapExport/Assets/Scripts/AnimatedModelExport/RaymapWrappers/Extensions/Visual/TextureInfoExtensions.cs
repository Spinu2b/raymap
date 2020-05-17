using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual
{
    public static class TextureInfoExtensions
    {
        public static VisualData ForExportTexture(this TextureInfo textureInfo, EnvironmentContext environmentContext)
        {
            TextureInfoWrapper textureInfoWrapper = TextureInfoWrapper.FromNormalTextureInfo(textureInfo, environmentContext);
            return textureInfoWrapper.GetVisualData();
            //return NormalTextureInfoTexture2DFetcher.DeriveFor(textureInfo);
        }
    }
}
