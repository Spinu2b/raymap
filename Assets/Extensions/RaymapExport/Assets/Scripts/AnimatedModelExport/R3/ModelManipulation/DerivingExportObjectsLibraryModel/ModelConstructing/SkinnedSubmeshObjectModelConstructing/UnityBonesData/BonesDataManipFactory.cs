using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.Model;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData
{
    public abstract class BonesDataManipFactory
    {
        protected UnityBoneTransformModel[] GetUnityMappedBones(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            throw new NotImplementedException();
        }

        protected UnityBoneTransformModel[] GetUnityMappedBonesBindPoses(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            throw new NotImplementedException();
        }
    }
}
