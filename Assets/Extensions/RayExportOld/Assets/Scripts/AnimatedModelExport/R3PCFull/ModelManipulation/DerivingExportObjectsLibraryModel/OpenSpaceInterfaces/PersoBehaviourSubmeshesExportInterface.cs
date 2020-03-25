using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Common;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces
{
    public class PersoBehaviourSubmeshesExportInterface : PersoBehaviourExportInterface
    {
        public PersoBehaviourSubmeshesExportInterface(PersoBehaviourInterface persoBehaviourInterface) : base(persoBehaviourInterface) { }

        public IEnumerable<PhysicalObjectWithChannelParentingInfo> IteratePhysicalObjectsWithChannelParentingInfosForGivenFrame(int animationFrameNumber)
        {
            throw new NotImplementedException();
        }
    }
}
