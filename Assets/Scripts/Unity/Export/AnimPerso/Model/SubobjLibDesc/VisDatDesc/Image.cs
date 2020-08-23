using Assets.Scripts.Unity.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc
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
            throw new NotImplementedException();
        }
    }

    public class ImageDescription : IExportModel, ISerializableToBytes
    {
        public int width = 0;
        public int height = 0;
        public List<Color> pixels = new List<Color>();

        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
        }
    }

    public class Image : IExportModel, IComparableModel<Image>
    {
        public string imageDescriptionIdentifier;
        public ImageDescription imageDescription = new ImageDescription();

        public bool EqualsToAnother(Image other)
        {
            throw new NotImplementedException();
        }
    }
}
