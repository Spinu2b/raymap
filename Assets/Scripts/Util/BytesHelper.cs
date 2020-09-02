using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util
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
        }

        public static byte[] GetBytesForString(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}
