using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util.Bytes
{
    public static class BytesHashHelper
    {
        private static string ToHex(this byte[] bytes, bool upperCase = false)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }

        public static string GetHashHexStringFor(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] byteHashedImage = md5.ComputeHash(bytes.ToArray());
                return ToHex(byteHashedImage);
            }
        }
    }
}
