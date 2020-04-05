using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class TextureModelFactory
    {
        public static
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture
            GetTextureModel(Texture2D unityTexture2D, string imageHash = null)
        {
            var result = new AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture();
            if (imageHash != null)
            {
                result.name = imageHash;
                result.image = imageHash;
            }
            else
            {
                string computedHash = ImageModelFactory.GetImageModel(unityTexture2D).name;
                result.name = computedHash;
                result.image = computedHash;
            }
            return result;
        }
    }
}
