using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils
{
    public static class ObjectHelper
    {
        public static object MemberwiseClone(object obj)
        {
            var memberwiseCloneMethod = typeof(object).GetMethod("MemberwiseClone",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            return memberwiseCloneMethod.Invoke(obj, new object[] { });
        }
    }
}
