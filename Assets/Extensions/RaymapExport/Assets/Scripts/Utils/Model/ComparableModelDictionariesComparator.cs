using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.Utils.Model
{
    public static class ComparableModelDictionariesComparator
    {
        public static bool AreDictionariesCompliant<KeyType, T>(Dictionary<KeyType, T> dictA, Dictionary<KeyType, T> dictB) where T : IComparableModel<T>
        {
            if (dictA.Count != dictB.Count)
            {
                return false;
            }
            foreach (var key in dictA.Keys)
            {
                if (!dictB.ContainsKey(key) || !dictA[key].EqualsToAnother(dictB[key]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreCSharpComparableDictionariesCompliant<KeyType, T>(Dictionary<KeyType, T> dictA, Dictionary<KeyType, T> dictB) where T : IComparable
        {
            if (dictA.Count != dictB.Count)
            {
                return false;
            }
            foreach (var key in dictA.Keys)
            {
                if (!dictB.ContainsKey(key) || dictA[key].CompareTo(dictB[key]) != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
