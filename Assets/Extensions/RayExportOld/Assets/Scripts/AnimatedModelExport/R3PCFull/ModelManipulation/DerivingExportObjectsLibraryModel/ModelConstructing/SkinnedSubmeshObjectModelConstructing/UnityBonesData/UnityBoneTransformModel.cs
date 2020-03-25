using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.MathDescription;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData
{
    public class UnityBoneTransformModel
    {
        public string name;
        public Vector3d position = new Vector3d(0.0f, 0.0f, 0.0f);
        public MathDescription.Quaternion rotation = new MathDescription.Quaternion(1.0f, 0.0f, 0.0f, 0.0f);
        public Vector3d scale = new Vector3d(1.0f, 1.0f, 1.0f);

        public UnityBoneTransformModel(string name)
        {
            this.name = name;
        }

        public static UnityBoneTransformModel FromUnityTransform(Transform transform)
        {
            var result = new UnityBoneTransformModel(transform.gameObject.name);
            result.position = new Vector3d(transform.position.x, transform.position.y, transform.position.z);
            result.rotation = new MathDescription.Quaternion(transform.rotation.w, transform.rotation.x, transform.rotation.y, transform.rotation.z);
            result.scale = new Vector3d(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
            return result;
        }

        public static UnityBoneTransformModel HomeTransform(string name)
        {
            return new UnityBoneTransformModel(name);
        }
    }
}
