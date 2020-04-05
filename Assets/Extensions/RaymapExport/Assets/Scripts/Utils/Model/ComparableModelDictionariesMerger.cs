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
                    if (dictA[item.Key].EqualsToAnother(item.Value))
                    {
                        dictA.Add(item.Key, item.Value);
                    }
                    else
                    {
                        throw new InvalidOperationException("Attempting to merge material-associated models with same keys but indeed being different!");
                    }
                }
            }
        }
    }
}
