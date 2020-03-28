using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public class RomPersoBehaviourAnimationKeyframesFetchingHelper : RomPersoBehaviourAnimationDataFetchingHelper
    {
        public RomPersoBehaviourAnimationKeyframesFetchingHelper(ROMPersoBehaviour romPersoBehaviour) : base(romPersoBehaviour) {}

        public Dictionary<string, ChannelTransformModel> GetPersoBehaviourChannelsKeyframeDataForFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
