using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model
{
    public class AnimatedPersoDescription
    {
        public string name;
        public SubobjectsLibrary subobjectsLibrary = new SubobjectsLibrary();
        public ChannelHierarchies channelHierarchies = new ChannelHierarchies();
        public SubobjectsChannelsAssociations subobjectsChannelsAssociations = new SubobjectsChannelsAssociations();
        public AnimationClips animationClips = new AnimationClips();
    }
}
