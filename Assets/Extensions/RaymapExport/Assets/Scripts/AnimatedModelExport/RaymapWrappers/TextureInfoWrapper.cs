using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers
{
    public class TextureInfoWrapper
    {
        private EnvironmentContext environmentContext;

        private TextureInfoWrapper() { }

        public static TextureInfoWrapper FromNormalTextureInfo(TextureInfo textureInfo, EnvironmentContext environmentContext)
        {
            var result = new TextureInfoWrapper();
            result.environmentContext = environmentContext;

            throw new NotImplementedException();
        }

        public VisualData GetVisualData()
        {
            return environmentContext.getResourcesDataHolder().getVisualDataAppropriateForTextureInfo(this);
        }
    }
}
