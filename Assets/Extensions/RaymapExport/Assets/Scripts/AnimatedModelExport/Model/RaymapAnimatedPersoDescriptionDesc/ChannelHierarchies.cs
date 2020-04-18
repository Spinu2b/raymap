using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.ChannelHierarchiesDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc
{
    public class ChannelHierarchies : IExportModel
    {
        public Dictionary<string, ChannelHierarchyModel> channelHierarchies = new Dictionary<string, ChannelHierarchyModel>();
    }
}
