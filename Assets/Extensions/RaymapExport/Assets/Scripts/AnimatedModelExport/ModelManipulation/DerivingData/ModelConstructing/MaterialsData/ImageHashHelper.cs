using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class ImageHashHelper
    {
        public static string GetImageHashString(int width, int height,
            List<AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Color> pixels)
        {
            List<byte> imageBytes = pixels.Select(x => ((ISerializableToBytes)x).SerializeToBytes()).SelectMany(x => x).ToList();
            imageBytes.AddRange(BitConverter.GetBytes(width));
            imageBytes.AddRange(BitConverter.GetBytes(height));
            return BytesHashHelper.GetHashHexStringFor(imageBytes.ToArray());
        }
    }
}
