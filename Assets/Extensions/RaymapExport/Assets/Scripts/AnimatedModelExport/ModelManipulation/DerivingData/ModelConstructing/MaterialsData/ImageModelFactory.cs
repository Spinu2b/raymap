using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class ImageModelFactory
    {
        public static Image GetImageModel(Texture2D unityTexture2D)
        {
            var result = new Image();
            result.imageDescription.width = unityTexture2D.width;
            result.imageDescription.height = unityTexture2D.height;
            result.imageDescription.pixels = unityTexture2D.GetPixels().Select(x => new AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc.Color(x.r, x.g, x.b, x.a)).ToList();
            result.imageDescriptionHash = result.imageDescription.ComputeHash();
            return result;
        }
    }
}
