
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm
{
    public static class NormalTextureInfoTexture2DFetcher
    {
        public static VisualData DeriveFor(TextureInfo textureInfo)
        {
            if (NormalTextureInfoTexture2DMapLoaderFetcher.IsForExportDerivedFromMapLoader(textureInfo))
            {
                return NormalTextureInfoTexture2DMapLoaderFetcher.DeriveFor(textureInfo);
            }
            else if (NormalTextureInfoTexture2DMeshFileFetcher.IsForExportDerivedFromMeshFile(textureInfo))
            {
                return NormalTextureInfoTexture2DMeshFileFetcher.DeriveFor(textureInfo);
            }
            else if (NormalTextureInfoTexture2DR2DCLoaderFetcher.IsForExportDerivedFromR2DCLoader(textureInfo))
            {
                return NormalTextureInfoTexture2DR2DCLoaderFetcher.DeriveFor(textureInfo);
            }
            else if (NormalTextureInfoTexture2DR2PS2LoaderFetcher.IsForExportDerivedFromR2PS2Loader(textureInfo))
            {
                return NormalTextureInfoTexture2DR2PS2LoaderFetcher.DeriveFor(textureInfo);
            }
            else if (NormalTextureInfoTexture2DNormalGeometricObjectElementTrianglesFetcher.
                IsForExportDerivedFromNormalGeometricObjectElementTriangles(textureInfo))
            {
                return NormalTextureInfoTexture2DNormalGeometricObjectElementTrianglesFetcher.DeriveFor(textureInfo);
            }
            else
            {
                throw new InvalidOperationException("Could not determine deriving source for this TextureInfo!");
            }
        }
    }
}
