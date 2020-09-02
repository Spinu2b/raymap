using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Visuals;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using OpenSpace;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenSpace.Visual.VisualMaterial;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Extensions.Visual
{
    public static class VisualMaterialExtensions
    {
        public static VisualData ForExportGetMaterial(
            this VisualMaterial visualMaterial, Hint hints = Hint.None)
        {
            bool billboard = (hints & Hint.Billboard) == Hint.Billboard; // || (flags & flags_isBillboard) == flags_isBillboard;
            MapLoader l = MapLoader.Loader;

            MaterialVisualDataBuilder materialVisualDataBuilder = new MaterialVisualDataBuilder();

            bool transparent = visualMaterial.IsTransparent || ((hints & Hint.Transparent) == Hint.Transparent) || visualMaterial.textures.Count == 0;
            if (visualMaterial.textures.Where(t => ((t.properties & 0x20) != 0 && (t.properties & 0x80000000) == 0)).Count() > 0
                || visualMaterial.IsLight 
                || (visualMaterial.textures.Count > 0 && visualMaterial.textures[0].textureOp == 1))
            {
                materialVisualDataBuilder.SetMaterialBaseClass(MaterialBaseClass.LIGHT_MATERIAL);
            } else if (transparent)
            {
                materialVisualDataBuilder.SetMaterialBaseClass(MaterialBaseClass.TRANSPARENT_MATERIAL);
            }

            if (visualMaterial.textures != null)
            {
                materialVisualDataBuilder.SetFloat(BaseMaterialFields.texturesCount, visualMaterial.num_textures);
                if (visualMaterial.num_textures == 0)
                {
                    ExportImageBuilder exportImageBuilder = new ExportImageBuilder();
                    Image textureImage = exportImageBuilder.SetImageSize(1, 1).SetPixel(0, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f)).Build();

                    // Zero textures? Can only happen in R3 mode. Make it fully transparent
                    ExportTexture2DImageDataBuilder exportTextureImageBuilder = new ExportTexture2DImageDataBuilder();
                    VisualData exportTexture2DData = exportTextureImageBuilder.SetImage(textureImage).Build();

                    materialVisualDataBuilder.SetTexture(BaseMaterialFields.GetMaterialTextureFieldName(0), exportTexture2DData);
                }
                for (int i = 0; i < visualMaterial.num_textures; i++)
                {
                    string textureName = BaseMaterialFields.GetMaterialTextureFieldName(i);

                    VisualData forExportTexture = visualMaterial.textures[i].ForExportTexture();

                    if (forExportTexture != null)
                    {
                        materialVisualDataBuilder.SetTexture(textureName, forExportTexture);
                        materialVisualDataBuilder.SetVector(
                            BaseMaterialFields.GetTextureParamsFieldName(textureName),
                            new Vector4d(
                                visualMaterial.textures[i].textureOp,
                                visualMaterial.textures[i].ScrollingEnabled ? 1f : (visualMaterial.textures[i].IsRotate ? 2f : 0f),
                                0f, visualMaterial.textures[i].Format));
                        materialVisualDataBuilder.SetVector(
                            BaseMaterialFields.GetTextureParams2FieldName(textureName),
                            new Vector4d(
                                visualMaterial.textures[i].currentScrollX, visualMaterial.textures[i].currentScrollY,
                                visualMaterial.textures[i].ScrollX, visualMaterial.textures[i].ScrollY
                                )
                            );
                        //material.SetTextureOffset(textureName, new Vector2(textures[i].texture.currentScrollX, textures[i].texture.currentScrollY));
                    }
                    else
                    {
                        // No texture = just color. So create white texture and let that be colored by other properties.
                        ExportImageBuilder exportImageBuilder = new ExportImageBuilder();
                        Image textureImage = exportImageBuilder.SetImageSize(1, 1).SetPixel(0, 0, new Color(1.0f, 1.0f, 1.0f, 1.0f)).Build();

                        // Zero textures? Can only happen in R3 mode. Make it fully transparent.
                        ExportTexture2DImageDataBuilder exportTextureImageBuilder = new ExportTexture2DImageDataBuilder();
                        VisualData exportTextureData = exportTextureImageBuilder.SetImage(textureImage).Build();

                        materialVisualDataBuilder.SetTexture(textureName, exportTextureData);
                    }
                }
            }
            materialVisualDataBuilder.SetVector(BaseMaterialFields.AmbientCoefficients, visualMaterial.ForExportAmbientCoefficients());
            materialVisualDataBuilder.SetVector(BaseMaterialFields.DiffuseCoefficients, visualMaterial.ForExportDiffuseCoefficients());

            if (billboard) materialVisualDataBuilder.SetFloat(BaseMaterialFields.billboard, 1.0f);
            /* if (baseMaterial == l.baseMaterial || baseMaterial == l.baseTransparentMaterial) {
                    material.SetVector("_AmbientCoef", ambientCoef);
                    //material.SetVector("_SpecularCoef", specularCoef);
                    material.SetVector("_DiffuseCoef", diffuseCoef);
                    //material.SetVector("_Color", color);
                    //if (IsPixelShaded) material.SetFloat("_ShadingMode", 1f);
                }*/
            return materialVisualDataBuilder.Build();
        }

        public static Vector4d ForExportAmbientCoefficients(this VisualMaterial visualMaterial)
        {
            return Vector4d.FromUnityVector4(visualMaterial.ambientCoef);
        }

        public static Vector4d ForExportDiffuseCoefficients(this VisualMaterial visualMaterial)
        {
            return Vector4d.FromUnityVector4(visualMaterial.diffuseCoef);
        }
    }
}
