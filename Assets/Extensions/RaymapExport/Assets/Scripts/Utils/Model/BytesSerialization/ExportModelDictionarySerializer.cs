using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization
{
    public class ExportModelDictionarySerializer
    {
        public static byte[] SerializeToBytes(ICollection modelCollectionObject)
        {
            var dictionary = (IDictionary)modelCollectionObject;
            var dictionaryType = dictionary.GetType();

            if (dictionaryType.GetGenericTypeDefinition() == typeof(SortedDictionary<,>)
                || dictionaryType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var keysList = ModelHelper.GetOrderedComparableObjectsOrStringsList(dictionary.Keys);
                var result = new byte[] { };

                foreach (var key in keysList)
                {
                    var value = dictionary[key];
                    result = result.Concat(ModelValueSerializationHelper.SerializeValue(key))
                        .Concat(ModelValueSerializationHelper.SerializeValue(value)).ToArray();
                }

                return result;
            }
            else
            {
                throw new InvalidOperationException("Not supported dictionary kind! Will not serialize.");
            }
        }
    }
}
