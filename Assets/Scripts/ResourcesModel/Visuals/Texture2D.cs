using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Visuals
{
    public class Texture2D
    {
        private List<Color> pixels = new List<Color>();

        public List<Color> GetPixels()
        {
            return pixels;
        }

        public static Texture2D FromUnityTexture2D(UnityEngine.Texture2D texture)
        {
            var result = new Texture2D();
            result.pixels = texture.GetPixels().Select(x => Color.FromUnityColorStruct(x)).ToList();
            return result;
        }
    }
}
