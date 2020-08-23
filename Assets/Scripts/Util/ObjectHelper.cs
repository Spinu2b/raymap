using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util
{
    public static class ObjectHelper
    {
        public static object GetNonPublicInstanceFieldValue(object obj, string fieldName)
        {
            return obj.GetType().
                GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(obj);
        }
    }
}
