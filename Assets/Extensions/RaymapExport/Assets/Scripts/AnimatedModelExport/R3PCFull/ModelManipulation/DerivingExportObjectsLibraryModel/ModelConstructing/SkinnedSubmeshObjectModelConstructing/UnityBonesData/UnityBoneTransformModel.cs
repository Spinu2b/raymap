﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.UnityBonesData
{
    public class UnityBoneTransformModel
    {
        public string name;
        public Vector3d position;
        public MathDescription.Quaternion rotation;
        public Vector3d scale;
        
        private Transform channelTransform;

        public UnityBoneTransformModel(Transform unityTransform)
        {
            this.channelTransform = channelTransform;
        }
    }
}