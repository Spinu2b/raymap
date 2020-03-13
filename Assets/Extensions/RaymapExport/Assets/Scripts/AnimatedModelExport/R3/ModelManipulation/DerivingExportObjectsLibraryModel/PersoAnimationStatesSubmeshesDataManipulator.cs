using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel
{
    public class PersoAnimationStatesSubmeshesDataManipulator
    {
        public IEnumerable<SkinnedSubmeshObjectModel> IterateConsolidatedSubmeshObjectListFromAllPersoAnimationStates()
        {
            var persoAnimationStatesSkinnedSubmeshesExportInterface = new PersoAnimationStatesSkinnedSubmeshesExportInterface();
            persoAnimationStatesSkinnedSubmeshesExportInterface.ResetToInitialAnimationState();

            var resultSubmeshesSet = new SkinnedSubmeshesSet();
            while (persoAnimationStatesSkinnedSubmeshesExportInterface.AreAnimationStatesLeft())
            {
                while (persoAnimationStatesSkinnedSubmeshesExportInterface.AreAnimationFramesLeft())
                {
                    resultSubmeshesSet.Consolidate(persoAnimationStatesSkinnedSubmeshesExportInterface.DeriveSubmeshesSetForGivenFrame(
                        persoAnimationStatesSkinnedSubmeshesExportInterface.GetCurrentFrameNumberForExport()));
                    persoAnimationStatesSkinnedSubmeshesExportInterface.NextAnimationFrame();
                }
                persoAnimationStatesSkinnedSubmeshesExportInterface.NextAnimationState();
            }

            foreach (var submeshObjectModel in resultSubmeshesSet.IterateSubmeshes())
            {
                yield return submeshObjectModel;
            }
        }
    }
}
