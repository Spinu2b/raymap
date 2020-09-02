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
        public Dictionary<string, float> floats = new Dictionary<string, float>();
        public Dictionary<string, Vector> vectors = new Dictionary<string, Vector>(); 
        public MaterialBaseClass materialBaseClass;

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

            var floatsBytes = ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                dict: floats,
                keySerializer: BytesHelper.SerializeFunctions.StringSerializerFunction,
                valueSerializer: BytesHelper.SerializeFunctions.FloatSerializerFunction);

            var vectorsBytes = ComparableKeyDictionaryToBytesSerializer.WithCSharpComparableKeySerializeToBytes(
                dict: vectors,
                keySerializer: BytesHelper.SerializeFunctions.StringSerializerFunction,
                valueSerializer: x => x.SerializeToBytes());

            var materialBaseClassBytes = BitConverter.GetBytes((int)materialBaseClass);

            return texturesBytes.Concat(floatsBytes).Concat(vectorsBytes).Concat(materialBaseClassBytes).ToArray();
        }
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
            description.textures.Add(textureName, textureData.textureDescriptionIdentifier);
        }
    }
}
