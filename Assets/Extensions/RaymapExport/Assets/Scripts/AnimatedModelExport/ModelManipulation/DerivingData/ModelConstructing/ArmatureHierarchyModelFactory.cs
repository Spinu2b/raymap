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
            var consolidatedArmatureHierarchyBuilder = new ConsolidatedArmatureHierarchyBuilder();
            foreach (Tuple<int, Dictionary<int, int>> channelParentingInfoForFrame
                in persoBehaviourAnimationStatesHelper.IterateChannelParentingInfosThisAnimationState())
            {
                consolidatedArmatureHierarchyBuilder.Consolidate(GetArmatureHierarchyModelForParenting(channelParentingInfoForFrame.Item2));
            }
            return consolidatedArmatureHierarchyBuilder.Build();
        }

        private ArmatureHierarchyModel GetArmatureHierarchyModelForParenting(Dictionary<int, int> channelsParenting)
        {
            var result = new ArmatureHierarchyModel();
            result.parenting = channelsParenting.ToDictionary(x => x.Key, x => x.Value);
            result.channels = new HashSet<int>(channelsParenting.Keys.Concat(channelsParenting.Values));
            return result;
        }
    }
}
