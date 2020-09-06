using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using Assets.Scripts.Util;
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

    public class MaterialDescription : IExportModel, IIdentifiableComputationally, ISerializableToBytes
    {
        public Dictionary<string, string> textures = new Dictionary<string, string>();

        public string ComputeIdentifier()
        {
            return BytesHashHelper.GetHashHexStringFor(SerializeToBytes());
           
        }

        public byte[] SerializeToBytes()
        {
            var texturesBytes = ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                dict: textures,
                keySerializer: BytesHelper.SerializeFunctions.StringSerializerFunction,
                valueSerializer: BytesHelper.SerializeFunctions.StringSerializerFunction
                );

            return texturesBytes.ToArray();
        }
    }

    public class Material : IExportModel, IComparableModel<Material>
    {
        public string identifier;
        public MaterialDescription description = new MaterialDescription();

        public bool EqualsToAnother(Material other)
        {
            return identifier.Equals(other.identifier);
        }

        public void AddTexture(string textureName, Texture2D textureData)
        {
            description.textures.Add(textureName, textureData.textureDescriptionIdentifier);
        }
    }
}
