using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization
{
    public static class ModelValueSerializationHelper
    {
        public static byte[] SerializeValue(object value)
        {
            if (ModelHelper.IsExportModelObject(value))
            {
                return ExportModelSerializer.SerializeToBytes((IExportModel)value);
            }
            else if (ModelHelper.IsPrimitiveNumberOrString(value))
            {
                return ModelHelper.SerializeCSharpPrimitiveNumberOrString(value);
            }
            else if (ModelHelper.IsCollection(value))
            {
                return ExportModelCollectionSerializer.SerializeToBytes((ICollection)value);
            }
            else
            {
                throw new InvalidOperationException("Not supported value type! Will not serialize");
            }
        }
    }
}
