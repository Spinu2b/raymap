using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization
{
    class ExportModelListSerializer
    {
        public static byte[] SerializeToBytes(ICollection modelCollectionObject)
        {
            if (modelCollectionObject.GetType().GetGenericTypeDefinition() == typeof(List<>))
            {
                var result = new byte[] { };
                foreach (var value in modelCollectionObject)
                {
                    result = result.Concat(ModelValueSerializationHelper.SerializeValue(value)).ToArray();
                }
                return result;
            }
            else
            {
                throw new InvalidOperationException("Not expected list kind! Will not serialize.");
            }
        }
    }
}
