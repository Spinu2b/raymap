using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers;
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
        public IEnumerable<AnimationStateGeneralInfo> IterateAnimationStatesGeneralDataForExport(PersoAccessor persoAccessor)
        {
            var persoBehaviourAnimationStatesHelper = new PersoBehaviourAnimationStatesHelper(GetPersoBehaviourFor(persoAccessor));

            persoBehaviourAnimationStatesHelper.DisablePlayingAnimationsAutomatically();

            persoBehaviourAnimationStatesHelper.SwitchToFirstAnimationState();
            while (persoBehaviourAnimationStatesHelper.AreValidPersoAnimationStatesLeftIncludingCurrentOne())
            {
                var result = new AnimationStateGeneralInfo(persoBehaviourAnimationStatesHelper);
                result.BuildData();
                yield return result;
                persoBehaviourAnimationStatesHelper.AcquireNextValidPersoAnimationState();
            }
        }

        public SubobjectsLibraryModel GetSubobjectsLibrary(PersoAccessor persoAccessor)
        {
            var persoBehaviour = GetPersoBehaviourFor(persoAccessor);
            return persoBehaviour.GetSubobjectsLibrary();
        }

        private PersoBehaviourInterface GetPersoBehaviourFor(PersoAccessor persoAccessor)
        {
            return new PersoBehaviourInterface(persoAccessor);
            /* * /
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
            /* */
        }   
    }
}
