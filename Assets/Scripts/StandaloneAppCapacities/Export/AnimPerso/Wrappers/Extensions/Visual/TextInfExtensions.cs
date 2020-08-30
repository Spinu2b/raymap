using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Wrappers.Visual;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Extensions.Visual
{
    public static class TextureInfoExtensions
    {
        public static VisualData ForExportTexture(this TextureInfo textureInfo)
        {
            TextureInfoWrapper textureInfoWrapper = TextureInfoWrapper.FromNormalTextureInfo(textureInfo);
            return textureInfoWrapper.GetVisualData();
            //return NormalTextureInfoTexture2DFetcher.DeriveFor(textureInfo);
        }
    }
}
