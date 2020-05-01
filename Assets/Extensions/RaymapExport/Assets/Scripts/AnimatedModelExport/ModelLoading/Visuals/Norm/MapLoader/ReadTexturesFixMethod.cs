using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.BoolExpressions;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm.MapLoader
{
    public static class NormalTextureInfoTexture2DMapLoaderReadTexturesFixMethodDerivingDeterminer
    {
        public static bool IsDerivedFromR2LoaderLoadFIXSNAMethod(TextureInfo textureInfo)
        {
            throw new NotImplementedException();
        }

        public static bool IsDerivedFromR3LoaderLoadFIXMethod(TextureInfo textureInfo)
        {
            throw new NotImplementedException();
        }
    }

    public static class NormalTextureInfoTexture2DMapLoaderReadTexturesFixMethodFetcher
    {
        public static bool IsForExportDerivedFromMapLoaderReadTexturesFixMethod(TextureInfo textureInfo)
        {
            return new LogicalAlternativeConclusionValueBuilder()
                .Or(args => NormalTextureInfoTexture2DMapLoaderReadTexturesFixMethodDerivingDeterminer.
                    IsDerivedFromR2LoaderLoadFIXSNAMethod((TextureInfo)args[0]))
                .Or(args => NormalTextureInfoTexture2DMapLoaderReadTexturesFixMethodDerivingDeterminer.
                    IsDerivedFromR3LoaderLoadFIXMethod((TextureInfo)args[0]))
                .ConcludeFor(new object[] { textureInfo });
        }

        public static VisualData DeriveFor(TextureInfo textureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
