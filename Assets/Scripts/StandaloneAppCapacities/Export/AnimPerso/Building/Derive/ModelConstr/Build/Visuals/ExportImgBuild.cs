using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Visuals
{
    public class ExportImageBuilder
    {
        Image result = new Image();

        public ExportImageBuilder SetImageSize(int width, int height)
        {
            result.imageDescription.width = width;
            result.imageDescription.height = height;
            result.imageDescription.pixels = new List<Color>(new Color[width * height]);
            return this;
        }

        public ExportImageBuilder SetPixel(int positionX, int positionY, Color color)
        {
            result.imageDescription.pixels[positionY * result.imageDescription.width + positionX] = color;
            return this;
        }

        public ExportImageBuilder SetPixels(int width, int height, List<Color> pixels)
        {
            result.imageDescription.width = width;
            result.imageDescription.height = height;
            result.imageDescription.pixels = pixels;
            return this;
        }

        public Image Build()
        {
            result.imageDescriptionIdentifier = result.imageDescription.ComputeIdentifier();
            return result;
        }
    }
}
