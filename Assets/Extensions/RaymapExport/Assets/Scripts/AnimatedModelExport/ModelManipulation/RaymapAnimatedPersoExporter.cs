using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation
{
    public class RaymapAnimatedPersoExporter
    {
        public RaymapAnimatedPersoDescription Export(GameObject persoGameObject)
        {
            var result = new RaymapAnimatedPersoDescription();
            result.name = GetPersoName(persoGameObject);

            Tuple<AnimationClipsModel, SubmeshesLibraryModel, ArmatureHierarchyModel> exportData = GetDataFromPersoAnimationStates(persoGameObject);
            result.animationClipsModel = exportData.Item1;
            result.submeshesLibrary = exportData.Item2;
            result.armatureHierarchy = exportData.Item3;
            return result;
        }

        private Tuple<AnimationClipsModel, SubmeshesLibraryModel, ArmatureHierarchyModel> GetDataFromPersoAnimationStates(GameObject persoGameObject)
        {
            return new AnimationClipsGeneralDataExtractor().DeriveFor(persoGameObject);
        }

        private string GetPersoName(GameObject persoGameObject)
        {
            return persoGameObject.name;
        }
    }
}
