using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization
{
    public class ExportModelHashSetSerializer
    {
        public static byte[] SerializeToBytes(ICollection modelCollectionObject)
        {
            if (modelCollectionObject.GetType().GetGenericTypeDefinition() == typeof(HashSet<>))
            {
                var valuesList = ModelHelper.GetOrderedComparableObjectsOrStringsList(modelCollectionObject);
                return valuesList.Select(x => ModelValueSerializationHelper.SerializeValue(x)).SelectMany(x => x).ToArray();
            }
            else
            {
                throw new InvalidOperationException("Not expected hashset kind! Will not serialize.");
            }
        }
    }
}
