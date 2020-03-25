using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.Utils;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.AnimationClipsModelDesc.AnimationClipModelDesc
{
    public class AnimationFrameModel : Tree<AnimationFrameModelNode, string>
    {
        public int index;

        public AnimationFrameModel(int index = 0)
        {
            this.index = index;
        }

        public ArmatureHierarchyModel ToArmatureHierarchyModel()
        {
            return MapTree<ArmatureHierarchyModel, ArmatureHierarchyModelNode>(treeNode => new ArmatureHierarchyModelNode(treeNode.name));
        }
    }
}
