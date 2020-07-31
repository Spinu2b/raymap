using Assets.Scripts.Unity.Export.AnimPerso.Model;
using Assets.Scripts.Unity.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building
{
    public class AnimatedPersoExporter
    {
        public AnimatedPersoDescription Export(PersoAccessor persoAccessor)
        {
            var result = new AnimatedPersoDescription();
            result.name = GetPersoName(persoAccessor);

            var exportData = GetDataFromPersoAnimationStates(persoAccessor);
            throw new NotImplementedException();
        }

        private string GetPersoName(PersoAccessor persoAccessor)
        {
            throw new NotImplementedException();
        }

        private Tuple<AnimationClips, SubobjectsLibrary, ChannelHierarchies, SubobjectsChannelsAssociations>
            GetDataFromPersoAnimationStates(PersoAccessor persoAccessor)
        {
            throw new NotImplementedException();
        }
    }
}
