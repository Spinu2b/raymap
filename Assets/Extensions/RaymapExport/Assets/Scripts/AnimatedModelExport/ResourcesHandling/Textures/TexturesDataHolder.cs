using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling.Textures
{
    public class TexturesDataHolder
    {
        private MapLoaderTexturesDataHolder mapLoaderTexturesDataHolder = new MapLoaderTexturesDataHolder();
        private MeshFileTexturesDataHolder meshFileTexturesDataHolder = new MeshFileTexturesDataHolder();
        private R2DCLoaderTexturesDataHolder r2dcLoaderTexturesDataHolder = new R2DCLoaderTexturesDataHolder();
        private R2PS2LoaderTexturesDataHolder r2ps2LoaderTexturesDataHolder = new R2PS2LoaderTexturesDataHolder();
        
        private NormalGeometricObjectElementTrianglesTexturesDataHolder normalGeometricObjectElementTrianglesTexturesDataHolder = 
            new NormalGeometricObjectElementTrianglesTexturesDataHolder();

        public void Init()
        {
            mapLoaderTexturesDataHolder.Init();
            meshFileTexturesDataHolder.Init();
            r2dcLoaderTexturesDataHolder.Init();
            r2ps2LoaderTexturesDataHolder.Init();

            normalGeometricObjectElementTrianglesTexturesDataHolder.Init();
        }

        public VisualData GetVisualDataAppropriateForTextureInfo(TextureInfoWrapper textureInfoWrapper)
        {
            throw new NotImplementedException();
        }
    }
}
