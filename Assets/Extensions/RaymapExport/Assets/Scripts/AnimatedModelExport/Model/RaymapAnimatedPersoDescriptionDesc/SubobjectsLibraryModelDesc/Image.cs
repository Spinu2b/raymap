using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc
{
    public class Color : ISerializableToBytes
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

        byte[] ISerializableToBytes.SerializeToBytes()
        {
            return BitConverter.GetBytes(red).
                Concat(BitConverter.GetBytes(green)).
                Concat(BitConverter.GetBytes(blue)).
                Concat(BitConverter.GetBytes(alpha)).ToArray();
        }
    }

    public class Image : IComparableModel<Image>
    {
        public string name;
        public int width;
        public int height;
        public List<Color> pixels;

        public bool EqualsToAnother(Image other)
        {
            throw new NotImplementedException();
        }
    }
}
