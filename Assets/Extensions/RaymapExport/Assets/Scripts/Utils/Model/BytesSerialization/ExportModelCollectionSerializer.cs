using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization
{
    public static class ExportModelCollectionSerializer
    {
        public static byte[] SerializeToBytes(ICollection modelCollectionObject)
        {
            if (IsHashSet(modelCollectionObject))
            {
                return ExportModelHashSetSerializer.SerializeToBytes(modelCollectionObject);
            }
            else if (IsList(modelCollectionObject))
            {
                return ExportModelListSerializer.SerializeToBytes(modelCollectionObject);
            }
            else if (IsDictionary(modelCollectionObject))
            {
                return ExportModelDictionarySerializer.SerializeToBytes(modelCollectionObject);
            }
            else
            {
                throw new NotSupportedException("Unsupported collection type! Will not serialize.");
            }
        }

        private static bool IsDictionary(ICollection modelCollectionObject)
        {
            return modelCollectionObject is IDictionary;
        }

        private static bool IsList(ICollection modelCollectionObject)
        {
            return modelCollectionObject is IList;
        }

        private static bool IsHashSet(ICollection modelCollectionObject)
        {
            if (modelCollectionObject != null)
            {
                var t = modelCollectionObject.GetType();
                if (t.IsGenericType)
                {
                    return t.GetGenericTypeDefinition() == typeof(HashSet<>);
                }
            }
            return false;
        }
    }
}
