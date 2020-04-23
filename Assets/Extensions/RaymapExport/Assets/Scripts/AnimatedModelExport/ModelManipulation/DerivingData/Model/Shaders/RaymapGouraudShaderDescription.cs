using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Shaders
{
    public static class RaymapGouraudShaderDescription
    {
        private static string TEXTURE_COUNT_FIELD_NAME = "_NumTextures";
        private static string TEXTURE_NAME_PREFIX = "_Tex";

        public static int GetTexturesCount(Material material)
        {
            return material.GetInt(TEXTURE_COUNT_FIELD_NAME);
        }

        public static string GetTextureName(int index)
        {
            return TEXTURE_NAME_PREFIX + index;
        }
    }
}
