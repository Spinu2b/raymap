using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.Model;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing
{
    public class PhysicalObjectSubmeshObjectToSkinnedSubmeshObjectModelConverter
    {
        public static SkinnedSubmeshObjectModel Convert(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var result = new SkinnedSubmeshObjectModel();
            result.name = GetName(physicalObjectSubmeshObject);
            result.bindBonePoses = DeriveBindBonePoses(physicalObjectSubmeshObject);
            result.transform = DeriveTransformModel(physicalObjectSubmeshObject);
            result.meshGeometry = DeriveMeshGeometry(physicalObjectSubmeshObject);
            result.materials = DeriveMaterials(physicalObjectSubmeshObject);
            return result;
        }

        private static List<Material> DeriveMaterials(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var result = new List<Material>();

            return result;
        }

        private static MeshGeometry DeriveMeshGeometry(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var result = new MeshGeometry();

            return result;
        }

        private static TransformModel DeriveTransformModel(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var result = new TransformModel();

            return result;
        }

        private static Dictionary<string, BoneBindPose> DeriveBindBonePoses(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var result = new Dictionary<string, BoneBindPose>();

            return result;
        }

        private static string GetName(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            return physicalObjectSubmeshObject.submeshGameObject.name;
        }
    }
}
