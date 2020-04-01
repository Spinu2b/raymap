using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils
{
    public static class NumberUtils
    {
        private static float floatComparisonMargin = 0.00001f;

        public static bool RoundEquals(float floatNumberA, float floatNumberB)
        {
            return Math.Abs(floatNumberA - floatNumberB) < floatComparisonMargin;
        }
    }
}
