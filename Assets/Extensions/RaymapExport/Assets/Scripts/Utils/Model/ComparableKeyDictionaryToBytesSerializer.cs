using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model
{
    public static class ComparableKeyDictionaryToBytesSerializer
    {
        public static byte[] WithCSharpComparableKeySerializeToBytes<K, T>(Dictionary<K, T> dict,
            Func<K, byte[]> keySerializer,
            Func<T, byte[]> valueSerializer) 
            where K : IComparable<K>
        {
            var result = new byte[] { };
            foreach (var entry in dict.OrderBy(x => x.Key))
            {
                result = result.Concat(keySerializer(entry.Key).Concat(valueSerializer(entry.Value))).ToArray();
            }
            return result;
        }
    }
}
