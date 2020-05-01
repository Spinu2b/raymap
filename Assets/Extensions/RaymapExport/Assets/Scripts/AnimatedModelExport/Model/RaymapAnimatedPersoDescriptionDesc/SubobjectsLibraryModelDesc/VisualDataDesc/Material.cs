using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.VisualDataDesc

{
    public enum MaterialBaseClass
    {
        LIGHT_MATERIAL,
        TRANSPARENT_MATERIAL
    }

    public static class BaseMaterialFields
    {
        public const string TexturesCount = "TexturesCount";
        public const string AmbientCoefficients = "AmbientCoefficients";
        public const string DiffuseCoefficients = "DiffuseCoefficients";
        public const string Billboard = "Billboard";

        private const string TextureNameCore = "Texture_";

        public static string GetMaterialTextureFieldName(int textureIndex)
        {
            return TextureNameCore + textureIndex;
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

    public class MaterialDescription : IExportModel, IHashableModel, ISerializableToBytes
    {
        public Dictionary<string, string> textures = new Dictionary<string, string>();
        public Dictionary<string, float> floats = new Dictionary<string, float>();
        public MaterialBaseClass materialBaseClass;

        public string ComputeHash()
        {
            throw new NotImplementedException();
        }

        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
        }
    }

    public class Material : IExportModel, IComparableModel<Material>
    {
        public string materialDescriptionHash;
        public MaterialDescription materialDescription = new MaterialDescription();

        public MaterialBaseClass materialBaseClass
        {
            get
            {
                return materialDescription.materialBaseClass;
            }
        }

        public bool EqualsToAnother(Material other)
        {
            return materialDescriptionHash.Equals(other.materialDescriptionHash);
        }

        public void SetFloat(string floatName, float floatValue)
        {
            materialDescription.floats[floatName] = floatValue;
        }

        public void AddTexture(string textureName, Texture2D textureData)
        {
            throw new NotImplementedException();
        }
    }
}
