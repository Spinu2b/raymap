using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc
{
    public class Color : IExportModel, ISerializableToBytes
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
            return ExportModelSerializer.SerializeToBytes(this);
        }
    }

    public class ImageDescription : IExportModel, ISerializableToBytes, IHashableModel
    {
        public int width = 0;
        public int height = 0;
        public List<Color> pixels = new List<Color>();

        public string ComputeHash()
        {
            var bytes = SerializeToBytes();
            return BytesHashHelper.GetHashHexStringFor(bytes);
        }

        public byte[] SerializeToBytes()
        {
            return ExportModelSerializer.SerializeToBytes(this);
        }
    }

    public class Image : IComparableModel<Image>
    {
        public string imageDescriptionHash;
        public ImageDescription imageDescription = new ImageDescription();

        public bool EqualsToAnother(Image other)
        {
            return imageDescriptionHash.Equals(other.imageDescriptionHash);
        }
    }
}
