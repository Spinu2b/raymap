using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model.BytesSerialization
{
    public static class ExportModelSerializer
    {
        public static byte[] SerializeToBytes(IExportModel modelObject)
        {
            var result = SerializeAllPublicNonStaticHandledFields(modelObject);
            return result;
        }

        private static byte[] SerializeAllPublicNonStaticHandledFields(IExportModel modelObject)
        {
            var result = new byte[] { };
            foreach (var field in modelObject.GetType().GetFields().OrderBy(x => x.Name))
            {
                if (!field.IsPublic)
                {
                    throw new InvalidOperationException("The model class has non public fields! Will not serialize.");
                } else
                {
                    if (ModelFieldHelper.IsPrimitiveNumberOrStringType(field))
                    {
                        result = result.Concat(ModelFieldHelper.SerializeCSharpPrimitiveNumberOrStringField(modelObject, field)).ToArray();
                    } else if (ModelFieldHelper.IsCollectionType(field))
                    {
                        result = result.Concat(ExportModelCollectionSerializer.SerializeToBytes(ModelFieldHelper.GetFieldCollectionValue(modelObject, field))).ToArray();
                    } else if (ModelFieldHelper.IsExportModelType(field))
                    {
                        result = result.Concat(SerializeToBytes(ModelFieldHelper.GetFieldModelObjectValue(modelObject, field))).ToArray();
                    } else
                    {
                        throw new InvalidOperationException("Not supported field type! Will not serialize.");
                    }
                }
            }
            return result;
        }
    }
}
