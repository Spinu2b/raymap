using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Resources;
using OpenSpace;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.Wrappers.Visual
{
    public class TextureInfoWrapper
    {
        private TextureInfo textureInfo;

        private TextureInfoWrapper(TextureInfo textureInfo) {
            this.textureInfo = textureInfo;
        }

        public static TextureInfoWrapper FromNormalTextureInfo(TextureInfo textureInfo)
        {
            var result = new TextureInfoWrapper(textureInfo);
            return result;
        }

        public VisualData GetVisualData()
        {
            throw new NotImplementedException();
            //VisualDataHolder visualDataHolder = MapLoader.VisDataHolder;
           // return visualDataHolder.GetVisualDataForVisualTextureInfo(textureInfo);
        }
    }
}
