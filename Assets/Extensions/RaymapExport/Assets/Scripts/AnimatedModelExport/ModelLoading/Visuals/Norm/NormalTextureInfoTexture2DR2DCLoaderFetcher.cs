using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm.R2DCLoader;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm
{
    public static class NormalTextureInfoTexture2DR2DCLoaderFetcher
    {
        public static bool IsForExportDerivedFromR2DCLoader(TextureInfo textureInfo)
        {
            throw new NotImplementedException();
        }

        public static VisualData DeriveFor(TextureInfo textureInfo)
        {
            if (NormalTextureInfoTexture2DR2DCLoaderLoadDreamcastMethodFetcher.IsForExportDerivedFromR2DCLoaderLoadDreamcastMethod(textureInfo))
            {
                return NormalTextureInfoTexture2DR2DCLoaderLoadDreamcastMethodFetcher.DeriveFor(textureInfo);
            }
            else if (NormalTextureInfoTexture2DR2DCLoaderLoadMethodFetcher.IsForExportDerivedFromR2DCLoaderLoadMethod(textureInfo))
            {
                return NormalTextureInfoTexture2DR2DCLoaderLoadMethodFetcher.DeriveFor(textureInfo);
            } else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
