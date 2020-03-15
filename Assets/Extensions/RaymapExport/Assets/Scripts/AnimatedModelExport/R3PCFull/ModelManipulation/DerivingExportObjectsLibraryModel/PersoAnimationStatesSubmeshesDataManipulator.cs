using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel
{
    public class PersoAnimationStatesSubmeshesDataManipulator : PersoDataManipulator
    {
        public IEnumerable<SkinnedSubmeshObjectModel> IterateConsolidatedSubmeshObjectListFromAllPersoAnimationStates(GameObject persoR3GameObject)
        {
            var persoAnimationStatesSkinnedSubmeshesExportInterface = new PersoAnimationStatesSkinnedSubmeshesExportInterface(GetFamilyForPerso(persoR3GameObject));
            persoAnimationStatesSkinnedSubmeshesExportInterface.ResetToInitialAnimationState();

            var resultSubmeshesSet = new SkinnedSubmeshesSet();
            while (persoAnimationStatesSkinnedSubmeshesExportInterface.AreAnimationStatesLeft())
            {
                while (persoAnimationStatesSkinnedSubmeshesExportInterface.AreAnimationFramesLeft())
                {
                    resultSubmeshesSet.Consolidate(persoAnimationStatesSkinnedSubmeshesExportInterface.DeriveSubmeshesSetForGivenFrame(
                        persoAnimationStatesSkinnedSubmeshesExportInterface.GetCurrentFrameNumberForExport()));
                    persoAnimationStatesSkinnedSubmeshesExportInterface.NextFrame();
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
