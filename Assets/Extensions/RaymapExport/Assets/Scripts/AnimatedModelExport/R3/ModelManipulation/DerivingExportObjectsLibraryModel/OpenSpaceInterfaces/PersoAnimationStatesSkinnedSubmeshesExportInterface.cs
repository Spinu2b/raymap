using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.Model;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces
{
    public class PersoAnimationStatesSkinnedSubmeshesExportInterface
    {
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
            throw new NotImplementedException();
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
