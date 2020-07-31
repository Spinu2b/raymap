using Assets.Scripts.Unity.Export.AnimPerso.Building.Derive;
using Assets.Scripts.Unity.Export.AnimPerso.Model;
using Assets.Scripts.Unity.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building
{
    public class AnimationClipsGeneralDataExtractor
    {
        public Tuple<AnimationClips, SubobjectsLibrary, ChannelHierarchies, SubobjectsChannelsAssociations>
            DeriveFor(PersoAccessor persoAccessor)
        {
            var persoAnimationStatesDataManipulator = new PersoAnimationStatesGeneralDataManipulator();
            
            var consolidatedChannelHierarchiesBuilder = new ConsolidatedChannelHierarchiesBuilder();
            var resultingAnimationClipsModel = new AnimationClips();

            var subobjectsLibrary = persoAnimationStatesDataManipulator.GetSubobjectsLibrary(persoAccessor);
            var subobjectsChannelsAssociationsInfoBuilder = new SubobjectsChannelsAssociationsInfoBuilder();

            foreach (var animationStateGeneralInfo in persoAnimationStatesDataManipulator.IterateAnimationStatesGeneralDataForExport(persoAccessor))
            {
                resultingAnimationClipsModel.animationClips.Add(animationStateGeneralInfo.animationClipId, animationStateGeneralInfo.GetAnimationClipObj());
                consolidatedChannelHierarchiesBuilder.Consolidate(animationStateGeneralInfo.GetChannelHierarchiesInfo());
                subobjectsChannelsAssociationsInfoBuilder.Consolidate(animationStateGeneralInfo.GetSubobjectsChannelsAssociationsInfo());
            }
            return new Tuple<AnimationClips, SubobjectsLibrary, ChannelHierarchies, SubobjectsChannelsAssociations>(
                    resultingAnimationClipsModel, subobjectsLibrary, consolidatedChannelHierarchiesBuilder.Build(), subobjectsChannelsAssociationsInfoBuilder.Build()
                );
        }
    }
}
