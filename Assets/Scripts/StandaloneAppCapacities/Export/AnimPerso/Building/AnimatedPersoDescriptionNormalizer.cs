using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building
{
    public static class SubobjectsChannelsAssociationsNormalizationHelper
    {
        public static bool HasBones(AnimatedPersoDescription animatedPersoDescription, int subobjectNumber)
        {
            return animatedPersoDescription.subobjectsLibrary.subobjects[subobjectNumber].geometricObject.boneWeights.Count > 0;
        }

        public static void MakeSubobjectOnlyAssociatedWithItsBones(
            AnimatedPersoDescription animatedPersoDescription, int subobjectNumber)
        {
            // don't bother with recalculating reference hashes/identifiers
            // to keep invariants in the classes model consistent... no being worth it, really
            // if it will cause us pain, we will implement it ;)
            foreach (SubobjectsChannelsAssociation subobjectsChannelsAssociation 
                in animatedPersoDescription.subobjectsChannelsAssociations.subobjectsChannelsAssociations.Values)
            {
                var subobjectsChannelsAssociationDescription = subobjectsChannelsAssociation.subobjectsChannelsAssociationsDescription;
                foreach (int channelId in subobjectsChannelsAssociationDescription.channelsForSubobjectsParenting.Keys)
                {
                    subobjectsChannelsAssociationDescription.channelsForSubobjectsParenting[channelId].Remove(subobjectNumber);
                }
            }
        }
    }

    public static class AnimatedPersoDescriptionNormalizer
    {
        public static void NormalizeData(AnimatedPersoDescription animatedPersoDescription)
        {
            NormalizeChannelsSubobjectsAssociations(animatedPersoDescription);
        }

        private static void NormalizeChannelsSubobjectsAssociations(AnimatedPersoDescription animatedPersoDescription)
        {
            foreach (int subobjectNumber in animatedPersoDescription.subobjectsLibrary.subobjects.Keys)
            {
                if (SubobjectsChannelsAssociationsNormalizationHelper.HasBones(animatedPersoDescription, subobjectNumber))
                {
                    SubobjectsChannelsAssociationsNormalizationHelper
                        .MakeSubobjectOnlyAssociatedWithItsBones(animatedPersoDescription, subobjectNumber);
                }
            }
        }
    }
}
