using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
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

        private NormalPersoBehaviourAnimationSubobjectDataFetchingHelper normalPersoBehaviourAnimationSubobjectDataFetchingHelper;
        private RomPersoBehaviourAnimationSubobjectDataFetchingHelper romPersoBehaviourAnimationSubobjectDataFetchingHelper;

        private NormalPersoBehaviourMorphFetchingHelper normalPersoBehaviourMorphFetchingHelper;
        private RomPersoBehaviourMorphFetchingHelper romPersoBehaviourMorphFetchingHelper;

        private NormalPersoBehaviourChannelsParentingFetchingHelper normalPersoBehaviourChannelsParentingFetchingHelper;
        private RomPersoBehaviourChannelsParentingFetchingHelper romPersoBehaviourChannelsParentingFetchingHelper;

        private NormalPersoBehaviourStateHelper normalPersoBehaviourStateHelper;
        private RomPersoBehaviourStateHelper romPersoBehaviourStateHelper;

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
                    throw new NotImplementedException("States count currently not supported for ROM Perso Behaviour!");
                }
            }
        }

        public int currentAnimationStateFramesCount
        {
            get
            {
                if (persoBehaviour != null)
                {
                    if (persoBehaviour.a3d != null)
                    {
                        return persoBehaviour.a3d.num_onlyFrames;
                    } else
                    {
                        throw new NotImplementedException("AnimA3DGeneral is null, getting frames count in other ways currently not implemented!");
                    }                    
                }
                else
                {
                    throw new NotImplementedException("Animation state frames count currently not supported for ROM Perso Behaviour!");
                }
            }
        }

        public PersoBehaviourInterface(PersoBehaviour persoBehaviour)
        {
            this.persoBehaviour = persoBehaviour;
            this.normalPersoBehaviourAnimationKeyframesFetchingHelper = new NormalPersoBehaviourAnimationKeyframesFetchingHelper(persoBehaviour);
            this.normalPersoBehaviourAnimationSubobjectDataFetchingHelper = new NormalPersoBehaviourAnimationSubobjectDataFetchingHelper(persoBehaviour);
            this.normalPersoBehaviourMorphFetchingHelper = new NormalPersoBehaviourMorphFetchingHelper(persoBehaviour);
            this.normalPersoBehaviourChannelsParentingFetchingHelper = new NormalPersoBehaviourChannelsParentingFetchingHelper(persoBehaviour);
            this.normalPersoBehaviourStateHelper = new NormalPersoBehaviourStateHelper(persoBehaviour);
        }

        public PersoBehaviourInterface(ROMPersoBehaviour romPersoBehaviour)
        {
            this.romPersoBehaviour = romPersoBehaviour;
            this.romPersoBehaviourAnimationKeyframesFetchingHelper = new RomPersoBehaviourAnimationKeyframesFetchingHelper(romPersoBehaviour);
            this.romPersoBehaviourAnimationSubobjectDataFetchingHelper = new RomPersoBehaviourAnimationSubobjectDataFetchingHelper(romPersoBehaviour);
            this.romPersoBehaviourMorphFetchingHelper = new RomPersoBehaviourMorphFetchingHelper(romPersoBehaviour);
            this.romPersoBehaviourChannelsParentingFetchingHelper = new RomPersoBehaviourChannelsParentingFetchingHelper(romPersoBehaviour);
            this.romPersoBehaviourStateHelper = new RomPersoBehaviourStateHelper(romPersoBehaviour);
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

        public Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForAnimationFrame(int frameNumber)
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

        public List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber)
        {
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourMorphFetchingHelper.GetPersoBehaviourMorphDataForFrame(frameNumber);
            } 
            else
            {
                return romPersoBehaviourMorphFetchingHelper.GetPersoBehaviourMorphDataForFrame(frameNumber);
            }
        }

        public List<SubobjectModel> GetSubobjectsUsedForAnimationFrame(int frameNumber)
        {
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourAnimationSubobjectDataFetchingHelper.GetPersoBehaviourSubobjectsUsedForFrame(frameNumber);
            } 
            else
            {
                return romPersoBehaviourAnimationSubobjectDataFetchingHelper.GetPersoBehaviourSubobjectsUsedForFrame(frameNumber);
            }
        }

        public Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber)
        {
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourChannelsParentingFetchingHelper.GetPersoBehaviourChannelsParentingForFrame(frameNumber);
            }
            else
            {
                return romPersoBehaviourChannelsParentingFetchingHelper.GetPersoBehaviourChannelsParentingForFrame(frameNumber);
            }
        }

        public VisualData GetVisualDataForAnimationFrame(int frameNumber)
        {
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourAnimationSubobjectDataFetchingHelper.GetVisualDataForFrame(frameNumber);
            }
            else
            {
                return romPersoBehaviourAnimationSubobjectDataFetchingHelper.GetVisualDataForFrame(frameNumber);
            }
        }

        public bool IsValidAnimationState(int animationStateIndex)
        {
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourStateHelper.IsValidAnimationState(animationStateIndex);
            } else
            {
                return romPersoBehaviourStateHelper.IsValidAnimationState(animationStateIndex);
            }
        }
    }
}
