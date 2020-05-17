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
    public static class ReadTexturesFixMethodTexturesOffsetsHolder
    {
        public static bool ContainsTextureOffset(TextureInfo textureInfo)
        {
            throw new NotImplementedException();
        }
    }

    public static class NormalTextureInfoTexture2DMapLoaderReadTexturesFixMethodFetcher
    {
        public static bool IsForExportDerivedFromMapLoaderReadTexturesFixMethod(TextureInfo textureInfo)
        {
            return ReadTexturesFixMethodTexturesOffsetsHolder.ContainsTextureOffset(textureInfo);
        }

        public static VisualData DeriveFor(TextureInfo textureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
