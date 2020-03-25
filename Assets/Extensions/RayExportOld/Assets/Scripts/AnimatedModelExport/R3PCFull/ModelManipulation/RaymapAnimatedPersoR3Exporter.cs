using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation
{
    public class RaymapAnimatedPersoR3Exporter
    {
        public RaymapAnimatedPersoDescriptionR3 export(GameObject persoR3GameObject)
        {
            var result = new RaymapAnimatedPersoDescriptionR3();
            result.name = GetPersoName(persoR3GameObject);
            result.animationClipsModel = GetAnimationClipsModel(persoR3GameObject);
            result.exportObjectsLibrary = GetExportObjectsLibrary(persoR3GameObject);
            result.armatureHierarchy = DeriveArmatureHierarchy(persoR3GameObject, result.animationClipsModel);
            return result;
        }

        private ArmatureHierarchyModel DeriveArmatureHierarchy(GameObject persoR3GameObject, AnimationClipsModel animationClipsModel)
        {
            var consolidatedArmatureHierarchyBuilder = new ConsolidatedArmatureHierarchyBuilder();
            foreach (var animationClip in animationClipsModel.IterateAnimationClips())
            {
                consolidatedArmatureHierarchyBuilder.Consolidate(animationClip.GetFirstAnimationFrame());
            }
            return consolidatedArmatureHierarchyBuilder.Build();
        }

        private string GetPersoName(GameObject persoR3GameObject)
        {
            return persoR3GameObject.name;
        }

        private AnimationClipsModel GetAnimationClipsModel(GameObject persoR3GameObject)
        {
            return new AnimationClipsModelExtractor().DeriveFor(persoR3GameObject);
        }

        private ExportObjectsLibraryModel GetExportObjectsLibrary(GameObject persoR3GameObject)
        {
            return new ExportObjectsLibraryExtractor().DeriveFor(persoR3GameObject);
        }
    }
}
