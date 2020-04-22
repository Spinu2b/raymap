using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Rom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoAccessorSubobjectsLibraryFetchingHelper : RomPersoAccessorAnimationDataFetchingHelper
    {
        public RomPersoAccessorSubobjectsLibraryFetchingHelper(RomPersoAccessor romPersoAccessor) : base(romPersoAccessor)
        {
        }

        public SubobjectsLibraryModel GetPersoBehaviourSubobjectsLibrary()
        {
            throw new NotImplementedException();
        }
    }
}
