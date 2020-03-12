﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation
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
            throw new NotImplementedException();
        }

        private string GetPersoName(GameObject persoR3GameObject)
        {
            throw new NotImplementedException();
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
