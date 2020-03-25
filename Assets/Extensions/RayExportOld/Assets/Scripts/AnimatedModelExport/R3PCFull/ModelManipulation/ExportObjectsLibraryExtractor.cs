using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation
{
    public class ExportObjectsLibraryExtractor
    {
        public ExportObjectsLibraryModel DeriveFor(GameObject persoR3GameObject)
        {
            var persoAnimationStatesSubmeshesDataManipulator = new PersoAnimationStatesSubmeshesDataManipulator();
            var result = new ExportObjectsLibraryModel();

            foreach (var skinnedSubmeshObjectModel in 
                persoAnimationStatesSubmeshesDataManipulator.IterateConsolidatedSubmeshObjectListFromAllPersoAnimationStates(persoR3GameObject))
            {
                result.skinnedSubmeshObjects.Add(skinnedSubmeshObjectModel.name, skinnedSubmeshObjectModel);
            }

            return result;
        }
    }
}
