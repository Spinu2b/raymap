using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model
{
    public class RaymapAnimatedPersoDescription
    {
        public string name;
        public SubobjectsLibraryModel submeshesLibrary = new SubobjectsLibraryModel();
        public ChannelHierarchies channelHierarchies = new ChannelHierarchies();
        public AnimationClipsModel animationClipsModel = new AnimationClipsModel();
    }
}
