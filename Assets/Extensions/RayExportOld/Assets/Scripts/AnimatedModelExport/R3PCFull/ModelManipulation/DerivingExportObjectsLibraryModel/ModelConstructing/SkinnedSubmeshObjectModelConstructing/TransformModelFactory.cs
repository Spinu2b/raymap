using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing
{
    public class TransformModelFactory
    {
        public TransformModel ConstructFor(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var unityTransform = physicalObjectSubmeshObject.submeshGameObject.transform;
            var result = new TransformModel();
            result.position = new MathDescription.Vector3d(unityTransform.position.x, unityTransform.position.y, unityTransform.position.z);
            result.rotation = new MathDescription.Quaternion(unityTransform.rotation.w, unityTransform.rotation.x, unityTransform.rotation.y, unityTransform.rotation.z);
            result.scale = new MathDescription.Vector3d(unityTransform.lossyScale.x, unityTransform.lossyScale.y, unityTransform.lossyScale.z);

            result.localPosition = new MathDescription.Vector3d(unityTransform.localPosition.x, unityTransform.localPosition.y, unityTransform.localPosition.z);
            result.localRotation = new MathDescription.Quaternion(unityTransform.localRotation.w, unityTransform.localRotation.x, unityTransform.localRotation.y, unityTransform.localRotation.z);
            result.localScale = new MathDescription.Vector3d(unityTransform.localScale.x, unityTransform.localScale.y, unityTransform.localScale.z);
            return result;
        }
    }
}
