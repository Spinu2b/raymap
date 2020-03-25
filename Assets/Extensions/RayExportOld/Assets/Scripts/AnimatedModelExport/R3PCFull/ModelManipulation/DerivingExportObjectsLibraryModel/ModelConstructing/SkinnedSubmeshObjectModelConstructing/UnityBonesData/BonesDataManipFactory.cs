using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData
{
    public abstract class BonesDataManipFactory
    {
        protected UnityBoneTransformModel[] GetUnityMappedBones(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            return physicalObjectSubmeshObject.GetUnityMappedBones();
        }
    }
}
