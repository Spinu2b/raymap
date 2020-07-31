﻿using Assets.Scripts.Unity.Export.AnimPerso.Model;
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

            result.animationClips = exportData.Item1;
            result.subobjectsLibrary = exportData.Item2;
            result.channelHierarchies = exportData.Item3;
            result.subobjectsChannelsAssociations = exportData.Item4;

            return result;
        }

        private string GetPersoName(PersoAccessor persoAccessor)
        {
            throw new NotImplementedException();
        }

        private Tuple<AnimationClips, SubobjectsLibrary, ChannelHierarchies, SubobjectsChannelsAssociations>
            GetDataFromPersoAnimationStates(PersoAccessor persoAccessor)
        {
            return new AnimationClipsGeneralDataExtractor().DeriveFor(persoAccessor);
        }
    }
}