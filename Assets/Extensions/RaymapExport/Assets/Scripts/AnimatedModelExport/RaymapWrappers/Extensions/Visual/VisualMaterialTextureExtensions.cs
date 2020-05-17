using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual
{
    public static class VisualMaterialTextureExtensions
    {
        public static UnityEngine.Texture2D ForExportGetTexture2D(this VisualMaterialTexture visualMaterialTexture)
        {
            return (UnityEngine.Texture2D)ObjectHelper.GetNonPublicInstanceFieldValue(visualMaterialTexture, "texture2D");
        }

        public static VisualData ForExportTexture(this VisualMaterialTexture visualMaterialTexture, EnvironmentContext environmentContext)
        {
            VisualData resultTexture = visualMaterialTexture.texture.ForExportTexture(environmentContext);

            if (Settings.s.engineVersion < Settings.EngineVersion.R3)
            {
                if (visualMaterialTexture.texture == null) return null;
                return resultTexture;
            }
            if (visualMaterialTexture.ForExportGetTexture2D() == null && visualMaterialTexture.texture != null && resultTexture != null)
            {
                return resultTexture;
                /* * /
                texture2D = new Texture2D(texture.Texture.width, texture.Texture.height);
                texture2D.SetPixels(texture.Texture.GetPixels());
                texture2D.Apply();
                if (!IsRepeatU)
                {
                    texture2D.wrapModeU = TextureWrapMode.Clamp;
                }
                if (!IsRepeatV)
                {
                    texture2D.wrapModeV = TextureWrapMode.Clamp;
                }
                if (IsMirrorX)
                {
                    texture2D.wrapModeU = TextureWrapMode.Mirror;
                }
                if (IsMirrorY)
                {
                    texture2D.wrapModeV = TextureWrapMode.Mirror;
                }
                /* */
            }
            return null;
            //return texture2D;
        }
    }
}
