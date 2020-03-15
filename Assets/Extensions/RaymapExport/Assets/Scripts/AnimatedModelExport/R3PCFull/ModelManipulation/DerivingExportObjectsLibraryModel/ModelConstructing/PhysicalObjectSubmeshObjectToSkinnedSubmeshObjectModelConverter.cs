using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.BindBonePosesConstr;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.MeshGeometryConstr;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing
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
            var materialsModelFactory = new MaterialsModelFactory();
            return materialsModelFactory.ConstructFor(physicalObjectSubmeshObject);
        }

        private static MeshGeometry DeriveMeshGeometry(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var skinnedMeshGeometryFactory = new SkinMeshGeometryFactory();
            return skinnedMeshGeometryFactory.ConstructFor(physicalObjectSubmeshObject);
        }

        private static TransformModel DeriveTransformModel(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var transformModelFactory = new TransformModelFactory();
            return transformModelFactory.ConstructFor(physicalObjectSubmeshObject);
        }

        private static Dictionary<string, BoneBindPose> DeriveBindBonePoses(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            var bindBonePosesFactory = new BindBonePosesFactory();
            return bindBonePosesFactory.ConstructFor(physicalObjectSubmeshObject);
        }

        private static string GetName(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            return physicalObjectSubmeshObject.submeshGameObject.name;
        }
    }
}
