using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing
{
    public class MaterialsModelFactory
    {
        private static int TEXTURE_MIPMAP_LEVEL = 0;

        public List<R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.
            ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc.Material> 
            ConstructFor(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var result = new List<R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.
                ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc.Material>();
            foreach (var unityMaterial in physicalObjectSubmeshObject.submeshGameObject.GetComponent<Renderer>().materials)
            {
                result.Add(ConvertUnityMaterialToMaterialModel(unityMaterial));
            }
            return result;
        }

        private R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.
            ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc.Material 
            ConvertUnityMaterialToMaterialModel(UnityEngine.Material unityMaterial)
        {
            var result = new R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.
                ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc.Material();

            result.name = unityMaterial.name;
            result.mainTexture = ConvertUnityTextureToTextureModel("_Tex0", unityMaterial.GetTexture("_Tex0"));
            result.mainTextureOffset = new MathDescription.Vector2d(unityMaterial.mainTextureOffset.x, unityMaterial.mainTextureOffset.y);
            result.mainTextureScale = new MathDescription.Vector2d(unityMaterial.mainTextureScale.x, unityMaterial.mainTextureScale.y);
            return result;
        }

        private R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.
            ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc.MaterialDesc.Texture 
            ConvertUnityTextureToTextureModel(string textureName, UnityEngine.Texture unityTexture)
        {
            var result = new R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.
            ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc.MaterialDesc.Texture();

            result.name = unityTexture.name;
            result.width = unityTexture.width;
            result.height = unityTexture.height;
            if (unityTexture.GetType() == typeof(Texture2D))
            {
                result.pixels = ((Texture2D)unityTexture).GetPixels(TEXTURE_MIPMAP_LEVEL)
                .Select(x => new R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.
                    ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc.MaterialDesc.Color(x.r, x.g, x.b, x.a)).ToList();
            } else
            {
                throw new InvalidOperationException("Mesh texture is not Texture2D!");
            }
            return result;
        }
    }
}
