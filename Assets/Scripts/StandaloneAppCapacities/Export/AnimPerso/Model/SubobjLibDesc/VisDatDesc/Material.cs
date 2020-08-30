using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc
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

        public static string GetMaterialTextureFieldName(int textureIndex)
        {
            return textureNameCore + textureIndex;
        }

        public static string GetTextureParamsFieldName(string textureName)
        {
            throw new NotImplementedException();
        }

        public static string GetTextureParams2FieldName(string textureName)
        {
            throw new NotImplementedException();
        }
    }

    public class MaterialDescription
    {
        public Dictionary<string, string> textures = new Dictionary<string, string>();
        public Dictionary<string, float> floats = new Dictionary<string, float>();
        public MaterialBaseClass materialBaseClass;
    }

    public class Material : IExportModel, IComparableModel<Material>
    {
        public string identifier;
        public MaterialDescription description = new MaterialDescription();

        public MaterialBaseClass materialBaseClass
        {
            get
            {
                return description.materialBaseClass;
            }
        }

        public bool EqualsToAnother(Material other)
        {
            throw new NotImplementedException();
        }

        public void SetFloat(string floatName, float floatValue)
        {
            description.floats[floatName] = floatValue;
        }

        public void AddTexture(string textureName, Texture2D textureData)
        {
            throw new NotImplementedException();
        }
    }
}
