using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using Assets.Scripts.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc
{
    public struct Color : IExportModel, ISerializableToBytes
    {
        public float red;
        public float green;
        public float blue;
        public float alpha;

        public Color(float red, float green, float blue, float alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public byte[] SerializeToBytes()
        {
            return BitConverter.GetBytes(red).
                Concat(BitConverter.GetBytes(green)).
                Concat(BitConverter.GetBytes(blue)).
                Concat(BitConverter.GetBytes(alpha)).ToArray();
        }

        public static Color FromResourcesModelColor(ResourcesModel.Visuals.Color color)
        {
            return new Color(color.r, color.g, color.b, color.a);
        }
    }

    public class ImageDescription : IExportModel, ISerializableToBytes, IIdentifiableComputationally
    {
        public int width = 0;
        public int height = 0;
        public List<Color> pixels = new List<Color>();

        public string ComputeIdentifier()
        {
            var bytes = SerializeToBytes();
            return BytesHashHelper.GetHashHexStringFor(bytes);
        }

        public byte[] SerializeToBytes()
        {
            var pixelBytes = pixels.SelectMany(x => x.SerializeToBytes()).ToArray();
            return BitConverter.GetBytes(width).Concat(BitConverter.GetBytes(height)).Concat(pixelBytes).ToArray();
        }
    }

    public class Image : IExportModel, IComparableModel<Image>
    {
        public string imageDescriptionIdentifier;
        public ImageDescription imageDescription = new ImageDescription();

        public bool EqualsToAnother(Image other)
        {
            return imageDescriptionIdentifier.Equals(other.imageDescriptionIdentifier);
        }
    }
}
