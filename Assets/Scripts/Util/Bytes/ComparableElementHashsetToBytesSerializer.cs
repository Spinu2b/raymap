using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util.Bytes
{
    public static class ComparableElementHashsetToBytesSerializer
    {
        public static byte[] WithCSharpComparableElementSerializeToBytes<T>(
            HashSet<T> hashSet, Func<T, byte[]> elementSerializer) where T : IComparable
        {
            var result = new byte[] { };
            foreach (var entry in hashSet.OrderBy(x => x))
            {
                result = result.Concat(elementSerializer(entry)).ToArray();
            }
            return result;
        }
    }
}
