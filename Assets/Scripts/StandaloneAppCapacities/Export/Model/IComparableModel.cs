using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.Model
{
    public interface IComparableModel<T>
    {
        bool EqualsToAnother(T other);
    }
}
