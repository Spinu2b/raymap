using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation
{
    public class RaymapAnimatedPersoExporter
    {
        public RaymapAnimatedPersoDescription Export(PersoAccessor persoAccessor)
        {
            var result = new RaymapAnimatedPersoDescription();
            result.name = GetPersoName(persoAccessor);

            var exportData = GetDataFromPersoAnimationStates(persoAccessor);
            result.animationClipsModel = exportData.Item1;
            result.submeshesLibrary = exportData.Item2;
            result.channelHierarchies = exportData.Item3;
            result.subobjectsChannelsAssociations = exportData.Item4;
            return result;
        }

        private Tuple<AnimationClipsModel, SubobjectsLibraryModel, ChannelHierarchies,
            Dictionary<string, SubobjectsChannelsAssociation>> GetDataFromPersoAnimationStates(PersoAccessor persoAccessor)
        {
            return new AnimationClipsGeneralDataExtractor().DeriveFor(persoAccessor);
        }

        private string GetPersoName(PersoAccessor persoAccessor)
        {
            return persoAccessor.name;
        }
    }
}
