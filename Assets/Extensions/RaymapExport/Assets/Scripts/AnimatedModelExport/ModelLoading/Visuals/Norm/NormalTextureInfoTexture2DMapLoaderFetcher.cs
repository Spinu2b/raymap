using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm.MapLoader;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.BoolExpressions;
using OpenSpace.FileFormat;
using OpenSpace.Loader;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm
{
    public static class MapLoaderHelper
    {
        public static bool IsR2Loader()
        {
            return OpenSpace.MapLoader.Loader is R2Loader;
        }

        public static bool IsR3Loader()
        {
            return OpenSpace.MapLoader.Loader is R3Loader;
        }

        public static bool IsLWLoader()
        {
            return OpenSpace.MapLoader.Loader is LWLoader;
        }

        public static SNA GetR2LoaderSNA()
        {
            SNA sna = (SNA)(OpenSpace.MapLoader.Loader as R2Loader).files_array[OpenSpace.MapLoader.Mem.Lvl];
            return sna;
        }
    }

    public static class NormalTextureInfoTexture2DMapLoaderDerivingDeterminer
    {
        public static bool IsDerivedFromLoadMemoryMethodR2Loader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsR2Loader();
        }

        public static bool IsDerivedFromLoadMemoryMethodR3Loader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsR3Loader();
        }

        public static bool IsDerivedFromLoadMemoryMethodLWLoader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsLWLoader();
        }

        public static bool IsDerivedFromReadTexturesFixMethodR2Loader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsR2Loader();
        }

        public static bool IsDerivedFromReadTexturesFixMethodR3Loader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsR3Loader();
        }

        public static bool IsDerivedFromReadTexturesLvlMethodLWLoader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsLWLoader();
        }

        public static bool IsDerivedFromReadTexturesLvlMethodR2Loader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsR2Loader();
        }

        public static bool IsDerivedFromReadTexturesLvlMethodR3Loader(TextureInfo textureInfo)
        {
            return MapLoaderHelper.IsR3Loader();
        }
    }

    public static class NormalTextureInfoTexture2DMapLoaderFetcher
    {
        public static bool IsForExportDerivedFromMapLoader(TextureInfo textureInfo)
        {
            return new
                LogicalAlternativeConclusionValueBuilder()
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromLoadMemoryMethodR2Loader((TextureInfo)args[0]))
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromLoadMemoryMethodR3Loader((TextureInfo)args[0]))
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromLoadMemoryMethodLWLoader((TextureInfo)args[0]))
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromReadTexturesFixMethodR2Loader((TextureInfo)args[0]))
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromReadTexturesFixMethodR3Loader((TextureInfo)args[0]))
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromReadTexturesLvlMethodLWLoader((TextureInfo)args[0]))
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromReadTexturesLvlMethodR2Loader((TextureInfo)args[0]))
                    .Or(args => NormalTextureInfoTexture2DMapLoaderDerivingDeterminer.IsDerivedFromReadTexturesLvlMethodR3Loader((TextureInfo)args[0]))
                    .ConcludeFor(new object[] { textureInfo });
        }

        public static VisualData DeriveFor(TextureInfo textureInfo)
        {
            if (NormalTextureInfoTexture2DMapLoaderLoadMemoryMethodFetcher.IsForExportDerivedFromMapLoaderLoadMemoryMethod(textureInfo))
            {
                return NormalTextureInfoTexture2DMapLoaderLoadMemoryMethodFetcher.DeriveFor(textureInfo);
            } else if (NormalTextureInfoTexture2DMapLoaderReadTexturesFixMethodFetcher.IsForExportDerivedFromMapLoaderReadTexturesFixMethod(textureInfo))
            {
                return NormalTextureInfoTexture2DMapLoaderReadTexturesFixMethodFetcher.DeriveFor(textureInfo);
            } else if (NormalTextureInfoTexture2DMapLoaderReadTexturesLvlMethodFetcher.IsForExportDerivedFromMapLoaderReadTexturesLvlMethod(textureInfo))
            {
                return NormalTextureInfoTexture2DMapLoaderReadTexturesLvlMethodFetcher.DeriveFor(textureInfo);
            } else
            {
                throw new InvalidOperationException("Could not determine deriving source");
            }
        }
    }
}
