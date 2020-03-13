using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces;
using OpenSpace.Object.Properties;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel
{
    public class PersoAnimationStatesDataManipulator
    {
        public IEnumerable<AnimationClipModel> IterateAnimationClips(GameObject persoR3GameObject)
        {
            var persoAnimationStatesExportInterface = new PersoAnimationStatesExportInterface(GetFamilyForPerso(persoR3GameObject));
            persoAnimationStatesExportInterface.ResetToInitialAnimationState();
            while (persoAnimationStatesExportInterface.AreAnimationClipsLeft())
            {
                var animationClip = new AnimationClipModel(persoAnimationStatesExportInterface.GetCurrentAnimationClipName());
                while (persoAnimationStatesExportInterface.AreAnimationFramesLeft())
                {
                    var animTreeWithChannelsDataHierarchy = persoAnimationStatesExportInterface.DeriveAnimTreeWithChannelsDataHierarchyForGivenFrame(
                    persoAnimationStatesExportInterface.GetCurrentFrameNumberForExport());

                    var animationFrame = new AnimationFrameModel(persoAnimationStatesExportInterface.GetCurrentFrameNumberForExport());
                    animationClip.AddKeyframe(animationFrame.index, animationFrame);
                    persoAnimationStatesExportInterface.NextKeyframe();
                }
                yield return animationClip;
                persoAnimationStatesExportInterface.NextAnimationClip();
            }
        }

        private Family GetFamilyForPerso(GameObject persoR3GameObject)
        {
            throw new NotImplementedException();
        }
    }
}
