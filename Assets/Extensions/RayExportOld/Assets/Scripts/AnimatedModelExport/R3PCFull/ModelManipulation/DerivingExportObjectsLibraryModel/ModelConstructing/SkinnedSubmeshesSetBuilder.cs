using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing
{
    public class SkinnedSubmeshesSetBuilder
    {
        private SkinnedSubmeshesSet result = new SkinnedSubmeshesSet();

        public SkinnedSubmeshesSet Build()
        {
            return result;
        }

        public void AddSubmeshObject(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            result.Add(ConvertPhysicalObjectSubmeshObjectToSkinnedSubmeshObjectModel(physicalObjectSubmeshObject));
        }

        private SkinnedSubmeshObjectModel ConvertPhysicalObjectSubmeshObjectToSkinnedSubmeshObjectModel(PhysicalObjectSubmeshObject physicalObjectSubmeshObject)
        {
            return PhysicalObjectSubmeshObjectToSkinnedSubmeshObjectModelConverter.Convert(physicalObjectSubmeshObject);
        }
    }
}
