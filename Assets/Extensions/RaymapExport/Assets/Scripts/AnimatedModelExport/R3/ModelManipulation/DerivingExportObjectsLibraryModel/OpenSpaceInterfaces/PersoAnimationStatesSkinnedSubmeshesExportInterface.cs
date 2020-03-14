using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces
{
    public class PersoAnimationStatesSkinnedSubmeshesExportInterface
    {
        private FamilyAnimationStatesHelper familyAnimationStatesHelper;
        private int currentFrameNumber = 0;

        public void ResetToInitialAnimationState()
        {
            throw new NotImplementedException();
        }

        public bool AreAnimationStatesLeft()
        {
            throw new NotImplementedException();
        }

        public bool AreAnimationFramesLeft()
        {
            throw new NotImplementedException();
        }

        public SkinnedSubmeshesSet DeriveSubmeshesSetForGivenFrame(int animationFrameNumber)
        {
            var skinnedSubmeshesSetFactory = new SkinnedSubmeshesSetFactory();
            return skinnedSubmeshesSetFactory.ConstructFromGiven(
                new AnimA3DGeneralSubmeshesDataManipulatorInterface(
                    familyAnimationStatesHelper.GetAnimA3DGeneralForCurrentPersoAnimationState()), animationFrameNumber);
        }

        public int GetCurrentFrameNumberForExport()
        {
            throw new NotImplementedException();
        }

        public void NextAnimationFrame()
        {
            throw new NotImplementedException();
        }

        public void NextAnimationState()
        {
            throw new NotImplementedException();
        }
    }
}
