using Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.Wrappers.Visual
{
    public class TextureInfoWrapper
    {
        private TextureInfoWrapper() { }

        public static TextureInfoWrapper FromNormalTextureInfo(TextureInfo textureInfo)
        {
            var result = new TextureInfoWrapper();
            throw new NotImplementedException();
        }

        public VisualData GetVisualData()
        {
            throw new NotImplementedException();
        }
    }
}
