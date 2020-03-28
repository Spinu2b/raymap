﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model
{
    public class RaymapAnimatedPersoDescription
    {
        public string name;
        public SubobjectsLibraryModel submeshesLibrary;
        public ArmatureHierarchyModel armatureHierarchy;
        public AnimationClipsModel animationClipsModel;
    }
}
