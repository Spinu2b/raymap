using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.BindBonePosesConstr
{
    public class BindBonePosesFactory : BonesDataManipFactory
    {
        public Dictionary<string, BoneBindPose> ConstructFor(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var result = new Dictionary<string, BoneBindPose>();

            UnityBoneTransformModel[] bones = GetUnityMappedBones(physicalObjectSubmeshObject);
            UnityBoneTransformModel[] bindPoses = GetUnityMappedBonesBindPoses(physicalObjectSubmeshObject);

            for (int i = 0; i < bones.Length; i++)
            {
                var unityBoneTransformModel = bones[i];
                var correspondingChannelName = BoneChannelMappingHelper.GetCorrespondingChannelNameForActualBoneAssociation(unityBoneTransformModel);
                result.Add(
                    correspondingChannelName,
                    new TransformModel(
                        bindPoses[i].position,
                        bindPoses[i].rotation,
                        bindPoses[i].scale,
                        new Vector3d(0.0f, 0.0f, 0.0f),
                        new MathDescription.Quaternion(1.0f, 0.0f, 0.0f, 0.0f),
                        new Vector3d(1.0f, 1.0f, 1.0f)
                        )
                    );
            }

            return result;
        }
    }
}
