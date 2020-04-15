using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils
{
    public static class ListExtensions
    {
        public static void AddWithUniqueCheck<T>(this List<T> list, T element)
        {
            if (list.Contains(element))
            {
                throw new InvalidOperationException("Trying to add duplicated element to list!");
            } else
            {
                list.Add(element);
            }
        }
    }
}
