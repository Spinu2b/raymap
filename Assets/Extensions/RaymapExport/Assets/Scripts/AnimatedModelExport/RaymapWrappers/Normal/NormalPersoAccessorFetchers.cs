using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal
{
    public partial class NormalPersoAccessor
    {
        private NormalPersoAccessorAnimationKeyframesFetchingHelper normalPersoAccessorAnimationKeyframesFetchingHelper;
        private NormalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper
            normalPersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper;
        private NormalPersoAccessorChannelsParentingFetchingHelper normalPersoAccessorChannelsParentingFetchingHelper;
        private NormalPersoAccessorMorphFetchingHelper normalPersoAccessorMorphFetchingHelper;
        private NormalPersoAccessorStateHelper normalPersoAccessorStateHelper;
        private NormalPersoAccessorSubobjectsLibraryFetchingHelper normalPersoAccessorSubobjectsLibraryFetchingHelper;
    }
}
