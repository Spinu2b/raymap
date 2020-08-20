using Assets.Scripts.Unity.Export.AnimPerso.Model;
using Assets.Scripts.Unity.Export.AnimPerso.Model.AnimClipsDesc;
using Assets.Scripts.Unity.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Wrappers.Normal
{
    public partial class NormalPersoAccessor : PersoAccessor
    {
        public override int statesCount => throw new NotImplementedException();

        public override int currentAnimationStateFramesCount => throw new NotImplementedException();

        public override Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, ChannelTransform> GetChannelsKeyframeDataForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationsForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override SubobjectsLibrary GetSubobjectsLibrary()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidAnimationState(int animationStateIndex)
        {
            throw new NotImplementedException();
        }

        public override void SetState(int stateIndex)
        {
            throw new NotImplementedException();
        }
    }
}
