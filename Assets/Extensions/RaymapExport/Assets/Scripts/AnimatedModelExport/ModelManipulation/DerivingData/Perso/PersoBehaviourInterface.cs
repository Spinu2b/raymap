using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class PersoBehaviourInterface
    {
        private PersoAccessor persoAccessor;

        private PersoAccessorAnimationKeyframesFetchingHelper persoAccessorAnimationKeyframesFetchingHelper;

        private PersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper persoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper;

        private PersoAccessorMorphFetchingHelper persoAccessorMorphFetchingHelper;

        private PersoAccessorChannelsParentingFetchingHelper persoAccessorChannelsParentingFetchingHelper;

        private PersoAccessorStateHelper persoAccessorStateHelper;

        private PersoAccessorSubobjectsLibraryFetchingHelper persoAccessorSubobjectsLibraryFetchingHelper;

        public int statesCount
        {
            get
            {
                return persoAccessor.statesCount;
            }
            /* * /
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
            /* */
        }

        public int currentAnimationStateFramesCount
        {
            get
            {
                return persoAccessor.currentAnimationStateFramesCount;
            }
            /* * /
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
            /* */
        }

        public PersoBehaviourInterface(PersoAccessor persoAccessor)
        {
            this.persoAccessor = persoAccessor;
            this.persoAccessorAnimationKeyframesFetchingHelper = new PersoAccessorAnimationKeyframesFetchingHelper(persoAccessor);
            this.persoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper = new PersoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper(persoAccessor);
            this.persoAccessorMorphFetchingHelper = new PersoAccessorMorphFetchingHelper(persoAccessor);
            this.persoAccessorChannelsParentingFetchingHelper = new PersoAccessorChannelsParentingFetchingHelper(persoAccessor);
            this.persoAccessorStateHelper = new PersoAccessorStateHelper(persoAccessor);
            this.persoAccessorSubobjectsLibraryFetchingHelper = new PersoAccessorSubobjectsLibraryFetchingHelper(persoAccessor);
        }

        public void SetState(int stateIndex)
        {
            persoAccessor.SetState(stateIndex);
            /* * /
            if (persoBehaviour != null)
            {
                persoBehaviour.SetState(stateIndex);
            }
            else
            {
                romPersoBehaviour.SetState(stateIndex);
            }
            /* */
        }

        public Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForAnimationFrame(int frameNumber)
        {
            return persoAccessorAnimationKeyframesFetchingHelper.GetPersoAccessorChannelsKeyframeDataForFrame(frameNumber);
            /* * /
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourAnimationKeyframesFetchingHelper.GetPersoBehaviourChannelsKeyframeDataForFrame(frameNumber);
            }
            else
            {
                return romPersoBehaviourAnimationKeyframesFetchingHelper.GetPersoBehaviourChannelsKeyframeDataForFrame(frameNumber);
            }
            /* */
        }

        public List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber)
        {
            return persoAccessorMorphFetchingHelper.GetPersoAccessorMorphDataForFrame(frameNumber);
            /* * /
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourMorphFetchingHelper.GetPersoBehaviourMorphDataForFrame(frameNumber);
            } 
            else
            {
                return romPersoBehaviourMorphFetchingHelper.GetPersoBehaviourMorphDataForFrame(frameNumber);
            }
            /* */
        }

        public SubobjectsLibraryModel GetSubobjectsLibrary()
        {
            return persoAccessorSubobjectsLibraryFetchingHelper.GetPersoAccessorSubobjectsLibrary();
            /* * /
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourSubobjectsLibraryFetchingHelper.GetPersoBehaviourSubobjectsLibrary();
            } else
            {
                return romPersoBehaviourSubobjectsLibraryFetchingHelper.GetPersoBehaviourSubobjectsLibrary();
            }
            /* */
        }

        public SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForAnimationFrame(int frameNumber)
        {
            return persoAccessorAnimationSubobjectsChannelsAssociationFetchingHelper.GetPersoAccessorSubobjectsChannelsAssociationForFrame(frameNumber);
            /* * /
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourAnimationSubobjectsChannelsAssociationFetchingHelper.GetPersoBehaviourSubobjectsChannelsAssociationForFrame(frameNumber);
            } 
            else
            {
                return romPersoBehaviourAnimationSubobjectsChannelsAssociationFetchingHelper.GetPersoBehaviourSubobjectsChannelsAssociationForFrame(frameNumber);
            }
            /* */
        }

        public Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber)
        {
            return persoAccessorChannelsParentingFetchingHelper.GetPersoAccessorChannelsParentingForFrame(frameNumber);
            /* * /
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourChannelsParentingFetchingHelper.GetPersoBehaviourChannelsParentingForFrame(frameNumber);
            }
            else
            {
                return romPersoBehaviourChannelsParentingFetchingHelper.GetPersoBehaviourChannelsParentingForFrame(frameNumber);
            }
            /* */
        }

        public bool IsValidAnimationState(int animationStateIndex)
        {
            return persoAccessorStateHelper.IsValidAnimationState(animationStateIndex);
            /* * /
            if (persoBehaviour != null)
            {
                return normalPersoBehaviourStateHelper.IsValidAnimationState(animationStateIndex);
            } else
            {
                return romPersoBehaviourStateHelper.IsValidAnimationState(animationStateIndex);
            }
            /* */
        }
    }
}
