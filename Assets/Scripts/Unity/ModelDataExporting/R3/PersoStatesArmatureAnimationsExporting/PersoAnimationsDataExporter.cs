﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Unity.ModelDataExporting.R3.PersoStatesArmatureAnimationsExporting.DataManipulation;
using Assets.Scripts.Unity.ModelDataExporting.R3.PersoStatesArmatureAnimationsExporting.Model;
using OpenSpace;
using OpenSpace.Object.Properties;
using UnityEngine;

namespace Assets.Scripts.Unity.ModelDataExporting.R3.PersoStatesArmatureAnimationsExporting
{
    public class PersoAnimationsDataExporter
    {
        private PersoAnimationStatesDataManipulator persoAnimationStatesDataManipulator;
        private JSONAnimationDataFileWriter jsonAnimationDataFileWriter;

        public PersoAnimationsDataExporter(PersoBehaviour persoBehaviour)
        {
            this.persoAnimationStatesDataManipulator = new PersoAnimationStatesDataManipulator(persoBehaviour);
            this.jsonAnimationDataFileWriter = new JSONAnimationDataFileWriter();
        }

        public void ExportPersoStatesAnimations()
        {
            AnimationsModel animationsModel = new AnimationsModel();
            foreach (var animationClip in persoAnimationStatesDataManipulator.IterateAnimationClips())
            {
                Debug.Log("Animation Clip: " + animationClip.Name);
                foreach (var animationKeyframe in animationClip.IterateKeyframes())
                {
                    animationsModel.addAnimationFrameModelToAnimationClip(
                        animationClip.Name, animationKeyframe.GetAnimationFrameModel(), animationKeyframe.FrameNumber);
                }
            }
            jsonAnimationDataFileWriter.writeAnimationModel(animationsModel);
        }
    }
}