using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData;
using OpenSpace.Object.Properties;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel
{
    public class PersoAnimationStatesDataManipulator : PersoDataManipulator
    {
        public IEnumerable<AnimationClipModel> IterateAnimationClips(GameObject persoR3GameObject)
        {
            var persoAnimationStatesExportInterface = new PersoAnimationStatesExportInterface(GetFamilyForPerso(persoR3GameObject));
            persoAnimationStatesExportInterface.ResetToInitialAnimationState();
            while (persoAnimationStatesExportInterface.AreAnimationStatesLeft())
            {
                var animationClip = new AnimationClipModel(persoAnimationStatesExportInterface.GetCurrentAnimationClipName());
                while (persoAnimationStatesExportInterface.AreAnimationFramesLeft())
                {
                    var animTreeWithChannelsDataHierarchy = persoAnimationStatesExportInterface.DeriveAnimTreeWithChannelsDataHierarchyForGivenFrame(
                    persoAnimationStatesExportInterface.GetCurrentFrameNumberForExport());

                    var animationFrame = new AnimationFrameModel(persoAnimationStatesExportInterface.GetCurrentFrameNumberForExport());
                    animationClip.AddKeyframe(animationFrame.index, animationFrame);
                    persoAnimationStatesExportInterface.NextFrame();
                }
                yield return animationClip;
                persoAnimationStatesExportInterface.NextAnimationState();
            }
        }
    }
}
