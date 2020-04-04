using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils
{
    public static class HashSetExtensions
    {
        public static void AddWithUniqueCheck<T>(this HashSet<T> hashSet, T element)
        {
            if (hashSet.Contains(element))
            {
                throw new InvalidOperationException("Trying to add duplicated element to hashSet!");
            } else
            {
                hashSet.Add(element);
            }
        }
    }
}
