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
            var persoBehaviourAnimationStatesHelper = new PersoAccessorAnimationStatesHelper(persoAccessor);

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
            return persoAccessor.GetSubobjectsLibrary();
        }  
    }
}
