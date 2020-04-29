using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using OpenSpace;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenSpace.Visual.VisualMaterial;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual
{
    public static class VisualMaterialExtensions
    {
        public static VisualData ForExportGetMaterial(this VisualMaterial visualMaterial, Hint hints = Hint.None)
        {
            bool billboard = (hints & Hint.Billboard) == Hint.Billboard;// || (flags & flags_isBillboard) == flags_isBillboard;
            MapLoader l = MapLoader.Loader;

            var resultMaterial = new Material();

            bool transparent = visualMaterial.IsTransparent || ((hints & Hint.Transparent) == Hint.Transparent) || visualMaterial.textures.Count == 0;
            if (visualMaterial.textures.Where(t => ((t.properties & 0x20) != 0 && (t.properties & 0x80000000) == 0)).Count() > 0
                || visualMaterial.IsLight//) {
                || (visualMaterial.textures.Count > 0 && visualMaterial.textures[0].textureOp == 1))
            {
                resultMaterial.isTransparent = false;
            }
            else if (transparent)
            {
                resultMaterial.isTransparent = true;
            }

            var resultTextures = new Dictionary<string, Texture>();
            var resultImages = new Dictionary<string, Image>();

            //material = new Material(baseMaterial);
            if (visualMaterial.textures != null)
            {
                //material.SetFloat("_NumTextures", visualMaterial.num_textures);
                if (visualMaterial.num_textures == 0)
                {
                    // Zero textures? Can only happen in R3 mode. Make it fully transparent.
                    Texture2D tex = new Texture2D(1, 1);
                    tex.SetPixel(0, 0, new Color(0, 0, 0, 0));
                    tex.Apply();
                    material.SetTexture("_Tex0", tex);
                }
                for (int i = 0; i < num_textures; i++)
                {
                    string textureName = "_Tex" + i;
                    if (textures[i].Texture != null)
                    {
                        material.SetTexture(textureName, textures[i].Texture);
                        material.SetVector(textureName + "Params", new Vector4(textures[i].textureOp,
                            textures[i].ScrollingEnabled ? 1f : (textures[i].IsRotate ? 2f : 0f),
                            0f, textures[i].Format));
                        material.SetVector(textureName + "Params2", new Vector4(
                            textures[i].currentScrollX, textures[i].currentScrollY,
                            textures[i].ScrollX, textures[i].ScrollY));
                        //material.SetTextureOffset(textureName, new Vector2(textures[i].texture.currentScrollX, textures[i].texture.currentScrollY));
                    }
                    else
                    {
                        // No texture = just color. So create white texture and let that be colored by other properties.
                        Texture2D tex = new Texture2D(1, 1);
                        tex.SetPixel(0, 0, new Color(1, 1, 1, 1));
                        tex.Apply();
                        material.SetTexture(textureName, tex);
                    }
                }
            }
            resultMaterial.ambientCoefficient = visualMaterial.ambientCoef;
            resultMaterial.diffuseCoefficient = visualMaterial.diffuseCoef;

            //material.SetVector("_AmbientCoef", ambientCoef);
            //material.SetVector("_DiffuseCoef", diffuseCoef);
            if (billboard) resultMaterial.SetBillboard(1f);
            /* if (baseMaterial == l.baseMaterial || baseMaterial == l.baseTransparentMaterial) {
                    material.SetVector("_AmbientCoef", ambientCoef);
                    //material.SetVector("_SpecularCoef", specularCoef);
                    material.SetVector("_DiffuseCoef", diffuseCoef);
                    //material.SetVector("_Color", color);
                    //if (IsPixelShaded) material.SetFloat("_ShadingMode", 1f);
                }*/
            var result = new VisualData();
            result.materials = new Dictionary<string, Material>() { { resultMaterial.materialDescriptionHash, resultMaterial } };
            result.textures = resultTextures;
            result.images = resultImages;

            return result;
        }
    }
}
