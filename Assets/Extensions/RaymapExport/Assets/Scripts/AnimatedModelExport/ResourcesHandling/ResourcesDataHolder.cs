using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling
{
    public class ResourcesDataHolder
    {
        private TexturesDataHolder texturesDataHolder = new TexturesDataHolder();

        public void Init()
        {
            texturesDataHolder.Init();
        }

        public VisualData getVisualDataAppropriateForTextureInfo(TextureInfoWrapper textureInfoWrapper)
        {
            return texturesDataHolder.GetVisualDataAppropriateForTextureInfo(textureInfoWrapper);
        }
    }
}
