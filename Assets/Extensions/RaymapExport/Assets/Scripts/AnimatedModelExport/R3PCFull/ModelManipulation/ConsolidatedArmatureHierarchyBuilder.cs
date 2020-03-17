using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation
{
    public class ArmatureHierarchiesConsolidator
    {
        public static void Consolidate(ArmatureHierarchyModel baseModel, ArmatureHierarchyModel toConsolidateWith)
        {
            var baseModelNodes = new HashSet<
                TreeBuildingNodeInfo<ArmatureHierarchyModelNode, string>>(baseModel.IterateParentChildPairsWithRoot().Select(
                    x => 
                    new TreeBuildingNodeInfo<ArmatureHierarchyModelNode, string>(
                    x.ParentId, x.ChildId, new ArmatureHierarchyModelNode(x.ChildId))).ToList());
            var toConsolidateWithModelNodes = new HashSet<TreeBuildingNodeInfo<ArmatureHierarchyModelNode, string>>
                (toConsolidateWith.IterateParentChildPairsWithRoot().Select(x => 
                new TreeBuildingNodeInfo<ArmatureHierarchyModelNode, string>(
                    x.ParentId, x.ChildId, new ArmatureHierarchyModelNode(x.ChildId))).ToList());

            var baseModelNodesNames = new HashSet<string>(baseModelNodes.Select(x => x.NodeId).ToList());
            var toConsolidateWithModelNodesNames = new HashSet<string>(toConsolidateWithModelNodes.Select(x => x.NodeId).ToList());

            toConsolidateWithModelNodesNames.ExceptWith(baseModelNodesNames);

            var buildingNodesToExtendArmatureHierarchyBy = new Queue<TreeBuildingNodeInfo<ArmatureHierarchyModelNode, string>>(
                toConsolidateWithModelNodes.ToList().FindAll(x => toConsolidateWithModelNodesNames.Contains(x.NodeId)).ToList());

            baseModel = (ArmatureHierarchyModel)Tree<ArmatureHierarchyModelNode, string>.BuildTreeWithProperNodesPuttingOrder(
                ExistingTree: baseModel, TreeBuildingNodes: buildingNodesToExtendArmatureHierarchyBy);
        }
    }

    public class ConsolidatedArmatureHierarchyBuilder
    {
        ArmatureHierarchyModel result = new ArmatureHierarchyModel();

        public void Consolidate(AnimationFrameModel animationFrameModel)
        {
            ArmatureHierarchiesConsolidator.Consolidate(result, animationFrameModel.ToArmatureHierarchyModel());
        }

        public ArmatureHierarchyModel Build()
        {
            return result;
        }
    }
}
