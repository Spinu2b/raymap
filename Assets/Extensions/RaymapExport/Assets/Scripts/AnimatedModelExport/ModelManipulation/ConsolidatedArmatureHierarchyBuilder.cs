using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation
{
    public class ConsolidatedArmatureHierarchyBuilder
    {
        ArmatureHierarchyModel result = new ArmatureHierarchyModel();

        public ArmatureHierarchyModel Build()
        {
            return result;
        }

        public void Consolidate(ArmatureHierarchyModel armatureHierarchy)
        {
            ComparableModelDictionariesMerger.MergeCSharpComparableDictionariesToFirstDict(result.parenting, armatureHierarchy.parenting);
            result.channels = new HashSet<int>(result.channels.Concat(armatureHierarchy.channels));
        }
    }
}
