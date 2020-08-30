using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive
{
    public class PersoAnimationStatesGeneralDataManipulator
    {
        public SubobjectsLibrary GetSubobjectsLibrary(PersoAccessor persoAccessor)
        {
            return persoAccessor.GetSubobjectsLibrary();
        }

        public IEnumerable<AnimationStateGeneralInfo> IterateAnimationStatesGeneralDataForExport(PersoAccessor persoAccessor)
        {
            var persoAccessorAnimationStatesHelper = new PersoAccessorAnimationStatesHelper(persoAccessor);
            persoAccessorAnimationStatesHelper.SwitchToFirstAnimationState();

            while (persoAccessorAnimationStatesHelper.AreValidPersoAnimationStatesLeftIncludingCurrentOne())
            {
                var result = new AnimationStateGeneralInfo(persoAccessorAnimationStatesHelper);
                result.BuildData();
                yield return result;
                persoAccessorAnimationStatesHelper.AcquireNextValidPersoAnimationState();
            }
        }
    }
}
