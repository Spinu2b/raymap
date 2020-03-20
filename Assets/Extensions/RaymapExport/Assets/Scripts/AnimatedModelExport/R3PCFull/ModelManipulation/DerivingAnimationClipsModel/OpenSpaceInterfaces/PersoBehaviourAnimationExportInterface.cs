using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Common;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingAnimationClipsModel.OpenSpaceInterfaces
{
    public class PersoBehaviourAnimationExportInterface : PersoBehaviourExportInterface
    {
        public PersoBehaviourAnimationExportInterface(PersoBehaviourInterface persoBehaviourInterface) : base(persoBehaviourInterface) { }

        public IEnumerable<AnimHierarchyWithChannelInfo> IterateAnimHierarchiesWithChannelInfosForGivenFrame(int animationFrameNumber)
        {
            throw new NotImplementedException();
            foreach (var persoHierarchyGameObject in IterateGameObjectsInPersoHierarchy(animationFrameNumber))
            {

            }
        }
    }
}
