using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization
{
    public static class PrimitiveSupportedTypes {
        public static Type[] primitiveSupportedNumberTypes = new Type[] { typeof(int), typeof(float) };
    }

    public static class ModelFieldHelper
    {
        public static bool IsPrimitiveNumberOrStringType(FieldInfo field)
        {
            return field.FieldType == typeof(string) || PrimitiveSupportedTypes.primitiveSupportedNumberTypes.Contains(field.FieldType);
        }

        public static bool IsCollectionType(FieldInfo field)
        {
            return typeof(ICollection).IsAssignableFrom(field.FieldType);
        }

        public static bool IsExportModelType(FieldInfo field)
        {
            return typeof(IExportModel).IsAssignableFrom(field.FieldType);
        }

        public static IExportModel GetFieldModelObjectValue(IExportModel modelObject, FieldInfo field)
        {
            return (IExportModel)field.GetValue(modelObject);
        }

        public static ICollection GetFieldCollectionValue(IExportModel modelObject, FieldInfo field)
        {
            return (ICollection)field.GetValue(modelObject);
        }

        public static byte[] SerializeCSharpPrimitiveNumberOrStringField(IExportModel modelObject, FieldInfo field)
        {
            if (PrimitiveSupportedTypes.primitiveSupportedNumberTypes.Contains(field.FieldType))
            {
                if (field.FieldType == typeof(float))
                {
                    return BitConverter.GetBytes((float)field.GetValue(modelObject));
                } else if (field.FieldType == typeof(int))
                {
                    return BitConverter.GetBytes((int)field.GetValue(modelObject));
                } else
                {
                    throw new InvalidOperationException("Attempted to serialize to bytes unsupported primitive csharp type!");
                }
            } else if (field.FieldType == typeof(string))
            {
                return Encoding.ASCII.GetBytes((string)field.GetValue(modelObject));
            } else
            {
                throw new InvalidOperationException("Attempted to serialize to bytes unsupported primitive csharp type!");
            }
        }
    }

    public static class ModelHelper
    {
        public static List<object> GetOrderedComparableObjectsOrStringsList(ICollection values)
        {
            var result = new List<object>();
            foreach (var value in values)
            {
                result.Add(value);
            }
            return result.OrderBy(x => (IComparable)x).ToList();
        }

        public static byte[] SerializeCSharpPrimitiveNumberOrString(object value)
        {
            if (PrimitiveSupportedTypes.primitiveSupportedNumberTypes.Contains(value.GetType()))
            {
                if (value is float)
                {
                    return BitConverter.GetBytes((float)value);
                }
                else if (value is int)
                {
                    return BitConverter.GetBytes((int)value);
                }
                else
                {
                    throw new InvalidOperationException("Attempted to serialize to bytes unsupported csharp object!");
                }
            }
            else if (value is string)
            {
                return Encoding.ASCII.GetBytes((string)value);
            }
            else
            {
                throw new InvalidOperationException("Attempted to serialize to bytes unsupported csharp object!");
            }
        }

        public static bool IsPrimitiveNumberOrString(object value)
        {
            return PrimitiveSupportedTypes.primitiveSupportedNumberTypes.Contains(value.GetType()) || value is string;
        }

        public static bool IsExportModelObject(object value)
        {
            return value is IExportModel;
        }

        public static bool IsCollection(object value)
        {
            return value is ICollection;
        }
    }
}
