using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm.MapLoader
{
    public static class NormalTextureInfoTexture2DMapLoaderLoadMemoryMethodFetcher
    {
        public static bool IsForExportDerivedFromMapLoaderLoadMemoryMethod(TextureInfo textureInfo)
        {
            return OpenSpace.MapLoader.Loader.lvlName.EndsWith(".exe");
        }

        public static VisualData DeriveFor(TextureInfo textureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
