using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class PersoBehaviourInterface
    {
        private PersoBehaviour persoBehaviour;
        private ROMPersoBehaviour romPersoBehaviour;

        private NormalPersoBehaviourAnimationKeyframesFetchingHelper normalPersoBehaviourAnimationKeyframesFetchingHelper;
        private RomPersoBehaviourAnimationKeyframesFetchingHelper romPersoBehaviourAnimationKeyframesFetchingHelper;

        private NormalPersoBehaviourAnimationSubobjectExistenceFetchingHelper normalPersoBehaviourAnimationSubobjectExistenceFetchingHelper;
        private RomPersoBehaviourAnimationSubmeshExistenceFetchingHelper romPersoBehaviourAnimationSubobjectExistenceFetchingHelper;

        public GameObject gameObject
        {
            get
            {
                if (persoBehaviour != null)
                {
                    return persoBehaviour.gameObject;
                }
                else
                {
                    return romPersoBehaviour.gameObject;
                }
            }
        }

        public int statesCount
        {
            get
            {
                if (persoBehaviour != null)
                {
                    return persoBehaviour.perso.p3dData.family.states.Count;
                }
                else
                {
                    throw new NotSupportedException("States count currently not supported for ROM Perso Behaviour!");
                }
            }
        }

        public int currentAnimationStateFramesCount
        {
            get
            {
                if (persoBehaviour != null)
                {
                    return persoBehaviour.a3d.num_onlyFrames;
                }
                else
                {
                    throw new NotSupportedException("Animation state frames count currently not supported for ROM Perso Behaviour!");
                }
            }
        }

        public PersoBehaviourInterface(PersoBehaviour persoBehaviour)
        {
            this.persoBehaviour = persoBehaviour;
            this.normalPersoBehaviourAnimationKeyframesFetchingHelper = new NormalPersoBehaviourAnimationKeyframesFetchingHelper(persoBehaviour);
            this.normalPersoBehaviourAnimationSubobjectExistenceFetchingHelper = new NormalPersoBehaviourAnimationSubobjectExistenceFetchingHelper(persoBehaviour);
        }

        public PersoBehaviourInterface(ROMPersoBehaviour romPersoBehaviour)
        {
            this.romPersoBehaviour = romPersoBehaviour;
            this.romPersoBehaviourAnimationKeyframesFetchingHelper = new RomPersoBehaviourAnimationKeyframesFetchingHelper(romPersoBehaviour);
            this.romPersoBehaviourAnimationSubobjectExistenceFetchingHelper = new RomPersoBehaviourAnimationSubmeshExistenceFetchingHelper(romPersoBehaviour);
        }

        public void SetState(int stateIndex)
        {
            if (persoBehaviour != null)
            {
                persoBehaviour.SetState(stateIndex);
            }
            else
            {
                romPersoBehaviour.SetState(stateIndex);
            }
        }

        public Dictionary<string, ChannelTransformModel> GetChannelsKeyframeDataForAnimationFrame(int frameNumber)
        {
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourAnimationKeyframesFetchingHelper.GetPersoBehaviourChannelsKeyframeDataForFrame(frameNumber);
            }
            else
            {
                return romPersoBehaviourAnimationKeyframesFetchingHelper.GetPersoBehaviourChannelsKeyframeDataForFrame(frameNumber);
            }
        }

        public List<string> GetSubobjectExistenceDataForAnimationFrame(int frameNumber)
        {
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourAnimationSubobjectExistenceFetchingHelper.GetPersoBehaviourSubobjectExistenceDataForFrame(frameNumber);
            }
            else
            {
                return romPersoBehaviourAnimationSubobjectExistenceFetchingHelper.GetPersoBehaviourSubobjectExistenceDataForFrame(frameNumber);
            }
        }

        public bool IsValidAnimationState(int animationStateIndex)
        {
            throw new NotImplementedException();
        }
    }
}
