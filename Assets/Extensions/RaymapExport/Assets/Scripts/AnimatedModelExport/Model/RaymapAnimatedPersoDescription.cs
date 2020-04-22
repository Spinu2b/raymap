using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model
{
    public class RaymapAnimatedPersoDescription : IExportModel
    {
        public string name;
        public SubobjectsLibraryModel subobjectsLibrary = new SubobjectsLibraryModel();
        public ChannelHierarchies channelHierarchies = new ChannelHierarchies();
        public Dictionary<string, SubobjectsChannelsAssociation> subobjectsChannelsAssociations = new Dictionary<string, SubobjectsChannelsAssociation>();
        public AnimationClipsModel animationClipsModel = new AnimationClipsModel();
    }
}
