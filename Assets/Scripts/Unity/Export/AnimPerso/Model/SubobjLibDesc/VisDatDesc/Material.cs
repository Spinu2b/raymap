using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc
{
    public enum MaterialBaseClass
    {
        LIGHT_MATERIAL,
        TRANSPARENT_MATERIAL
    }

    public static class BaseMaterialFields
    {
        public const string texturesCount = "TexturesCount";
        public const string AmbientCoefficients = "AmbientCoefficients";
        public const string DiffuseCoefficients = "DiffuseCoefficients";
        public const string billboard = "Billboard";

        private const string textureNameCore = "Texture_";
    }

    public class MaterialDescription
    {
        public Dictionary<string, string> textures = new Dictionary<string, string>();
        public Dictionary<string, float> floats = new Dictionary<string, float>();
        public MaterialBaseClass materialBaseClass;
    }

    public class Material
    {
        public string identifier;
        public MaterialDescription description;
    }
}
