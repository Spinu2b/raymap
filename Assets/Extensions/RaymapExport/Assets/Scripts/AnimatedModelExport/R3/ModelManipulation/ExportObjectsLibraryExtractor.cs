using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation
{
    public class ExportObjectsLibraryExtractor
    {
        public ExportObjectsLibraryModel DeriveFor(GameObject persoR3GameObject)
        {
            var persoAnimationStatesSubmeshesDataManipulator = new PersoAnimationStatesSubmeshesDataManipulator();
            var result = new ExportObjectsLibraryModel();

            foreach (var skinnedSubmeshObjectModel in 
                persoAnimationStatesSubmeshesDataManipulator.IterateConsolidatedSubmeshObjectListFromAllPersoAnimationStates())
            {
                result.skinnedSubmeshObjects.Add(skinnedSubmeshObjectModel.name, skinnedSubmeshObjectModel);
            }

            return result;
        }
    }
}
