using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class ArmatureHierarchyModelFactory
    {
        public ArmatureHierarchyModel DeriveFor(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var result = new ArmatureHierarchyModel();
            foreach (Tuple<int, Dictionary<int, int>> channelParentingInfoForFrame
                in persoBehaviourAnimationStatesHelper.IterateChannelParentingInfosThisAnimationState())
            {
                
            }
            return result;
        }
    }
}
