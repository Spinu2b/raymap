using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData
{
    public class PersoAnimationStatesGeneralDataManipulator
    {
        public IEnumerable<AnimationStateGeneralInfo> IterateAnimationStatesGeneralDataForExport(GameObject persoGameObject)
        {
            throw new NotImplementedException();

            var persoBehaviourAnimationStatesHelper = new PersoBehaviourAnimationStatesHelper(GetPersoBehaviourFor(persoGameObject));
            persoBehaviourAnimationStatesHelper.SwitchToFirstAnimationState();
            while (persoBehaviourAnimationStatesHelper.AreValidPersoAnimationStatesLeftIncludingCurrentOne())
            {
                
                /* * /
                var animationClip = new AnimationClipModel(persoBehaviourAnimationStatesHelper.GetCurrentAnimationClipName());
                while (persoBehaviourAnimationStatesHelper.AreAnimationFramesLeft())
                {
                    var animTreeWithChannelsDataHierarchy = persoBehaviourAnimationStatesHelper.DeriveAnimTreeWithChannelsDataHierarchyForGivenFrame(
                    persoBehaviourAnimationStatesHelper.GetCurrentFrameNumberForExport());

                    var animationFrame = new AnimationFrameModel(persoBehaviourAnimationStatesHelper.GetCurrentFrameNumberForExport());
                    animationClip.AddKeyframe(animationFrame.index, animationFrame);
                    persoBehaviourAnimationStatesHelper.NextFrame();
                }
                yield return animationClip;
                /* */
                persoBehaviourAnimationStatesHelper.AcquireNextValidPersoAnimationState();
                
            }
        }

        private PersoBehaviourInterface GetPersoBehaviourFor(GameObject persoGameObject)
        {
            if (persoGameObject.GetComponent<PersoBehaviour>() != null)
            {
                return new PersoBehaviourInterface(persoGameObject.GetComponent<PersoBehaviour>());
            }
            else if (persoGameObject.GetComponent<ROMPersoBehaviour>() != null)
            {
                return new PersoBehaviourInterface(persoGameObject.GetComponent<ROMPersoBehaviour>());
            }
            else
            {
                throw new InvalidOperationException("This game object does not have any Perso Behaviour component!");
            }
        }
    }
}
