using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc
{
    public struct Color
    {
        public float red;
        public float green;
        public float blue;
        public float alpha;
    }

    public class ImageDescription
    {
        public int width = 0;
        public int height = 0;
        public List<Color> pixels = new List<Color>();
    }

    public class Image
    {
        public string imageDescriptionIdentifier;
        public ImageDescription imageDescription = new ImageDescription();
    }
}
