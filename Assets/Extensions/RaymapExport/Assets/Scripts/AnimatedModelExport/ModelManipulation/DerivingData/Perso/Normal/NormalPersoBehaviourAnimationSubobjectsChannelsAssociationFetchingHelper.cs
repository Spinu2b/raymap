using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.RaymapModelFetching;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public static class VisualDataUnifier
    {
        public static VisualData Unify(List<VisualData> parts)
        {
            var result = new VisualData();

            foreach (var mergingPart in parts)
            {
                ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result.materials, mergingPart.materials);
                ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result.textures, mergingPart.textures);
                ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result.images, mergingPart.images);
            }

            return result;
        }
    }

    public class NormalPersoBehaviourAnimationSubobjectsChannelsAssociationFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourAnimationSubobjectsChannelsAssociationFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        private SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForNormalFrame()
        {
            return NormalPersoNormalFrameSubobjectsChannelsAssociationDataFetcher.DeriveFor(persoBehaviour);
        }

        private SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForLargoFrame()
        {
            throw new NotImplementedException();
        }

        private SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForMontrealFrame()
        {
            throw new NotImplementedException();
        }

        public SubobjectsChannelsAssociation GetPersoBehaviourSubobjectsChannelsAssociationForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetSubobjectsChannelsAssociationForNormalFrame();
            }
            else if (IsMontrealAnimation())
            {
                return GetSubobjectsChannelsAssociationForMontrealFrame();
            }
            else if (IsLargoAnimation())
            {
                return GetSubobjectsChannelsAssociationForLargoFrame();
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }
    }
}
