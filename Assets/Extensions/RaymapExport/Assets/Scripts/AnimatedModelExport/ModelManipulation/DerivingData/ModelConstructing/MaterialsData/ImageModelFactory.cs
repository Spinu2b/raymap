using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class ImageModelFactory
    {
        public static Image GetImageModel(Texture2D unityTexture2D)
        {
            var result = new Image();
            result.width = unityTexture2D.width;
            result.height = unityTexture2D.height;
            result.pixels = unityTexture2D.GetPixels().Select(x => new
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Color(x.r, x.g, x.b, x.a)).ToList();
            result.name = ImageHashHelper.GetImageHashString(result.width, result.height, result.pixels);
            return result;
        }
    }
}
