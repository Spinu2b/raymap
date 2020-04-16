using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
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
        public RaymapAnimatedPersoDescription Export(GameObject persoGameObject)
        {
            var result = new RaymapAnimatedPersoDescription();
            result.name = GetPersoName(persoGameObject);

            var exportData = GetDataFromPersoAnimationStates(persoGameObject);
            result.animationClipsModel = exportData.Item1;
            result.submeshesLibrary = exportData.Item2;
            result.channelHierarchies = exportData.Item3;
            result.subobjectsChannelsAssociations = exportData.Item4;
            return result;
        }

        private Tuple<AnimationClipsModel, SubobjectsLibraryModel, ChannelHierarchies,
            Dictionary<string, SubobjectsChannelsAssociation>> GetDataFromPersoAnimationStates(GameObject persoGameObject)
        {
            return new AnimationClipsGeneralDataExtractor().DeriveFor(persoGameObject);
        }

        private string GetPersoName(GameObject persoGameObject)
        {
            return persoGameObject.name;
        }
    }
}
