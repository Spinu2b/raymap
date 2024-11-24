using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GenericExport.Model.DataBlocks
{
    public class ObjectTransform
    {
        public ExportVector3 position;
        public ExportQuaternion rotation;
        public ExportVector3 scale;

        public ObjectTransform(ExportVector3 position, ExportQuaternion rotation, ExportVector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        public static ObjectTransform FromUnityMatrix4x4(Matrix4x4 matrix)
        {
            Quaternion rotation = matrix.rotation;
            Vector3 scale = matrix.lossyScale;
            Vector3 position = matrix.GetColumn(3);
            return new ObjectTransform(
                position: ExportVector3.FromVector3(position),
                rotation: ExportQuaternion.FromQuaternion(rotation),
                scale: ExportVector3.FromVector3(scale)
            );
        }

        public static ObjectTransform FromUnityTransform(Transform transform)
        {
            return new ObjectTransform(
                 position: ExportVector3.FromVector3(transform.position),
                 rotation: ExportQuaternion.FromQuaternion(transform.rotation),
                 scale: ExportVector3.FromVector3(transform.lossyScale)
            );
        }
    }
}
