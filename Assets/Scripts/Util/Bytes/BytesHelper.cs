using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util.Bytes
{
    public static class BytesHelper
    {
        public static class SerializeFunctions
        {
            public static byte[] StringSerializerFunction(string arg)
            {
                return GetBytesForString(arg);
            }

            public static byte[] FloatSerializerFunction(float arg)
            {
                return BitConverter.GetBytes(arg);
            }

            public static byte[] ListSerializerFunction<T>(List<T> list, Func<T,byte[]> elementSerializer)
            {
                return list.SelectMany(x => elementSerializer(x)).ToArray();
            }

            public static byte[] IntSerializerFunction(int arg)
            {
                return BitConverter.GetBytes(arg);
            }
        }

        public static byte[] GetBytesForString(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}
