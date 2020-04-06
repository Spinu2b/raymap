using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model
{
    public static class ComparableModelDictionariesMerger
    {
        public static void MergeDictionariesToFirstDict<KeyType, T>(
            Dictionary<KeyType, T> dictA, Dictionary<KeyType, T> dictB) where T : IComparableModel<T>
        {
            foreach (var item in dictB)
            {
                if (!dictA.ContainsKey(item.Key))
                {
                    dictA.Add(item.Key, item.Value);
                }
                else
                {
                    if (!dictA[item.Key].EqualsToAnother(item.Value))
                    {
                        throw new InvalidOperationException("Attempting to merge comparable models with same keys but indeed being different!");
                    }
                }
            }
        }

        public static void MergeCSharpComparableDictionariesToFirstDict<KeyType, T>(
            Dictionary<KeyType, T> dictA, Dictionary<KeyType, T> dictB) where T : IComparable<T>
        {
            foreach (var item in dictB)
            {
                if (!dictA.ContainsKey(item.Key))
                {
                    dictA.Add(item.Key, item.Value);
                }
                else
                {
                    if (dictA[item.Key].CompareTo(item.Value) != 0)
                    {
                        throw new InvalidOperationException("Attempting to merge comparable models with same keys but indeed being different!");
                    }
                }
            }
        }
    }
}
