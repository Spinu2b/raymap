using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Cache;
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

    public class NormalPersoBehaviourAnimationSubobjectDataFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        private SubobjectsCache subobjectsCache = new SubobjectsCache();

        public NormalPersoBehaviourAnimationSubobjectDataFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        private Tuple<SubobjectsChannelsAssociation, List<Tuple<SubobjectModel, VisualData>>>
            GetActualPhysicalSubobjectsForNormalFrame()
        {
            var resultSubobjectsList = new List<Tuple<SubobjectModel, VisualData>>();
            AnimOnlyFrame of = persoBehaviour.a3d.onlyFrames[persoBehaviour.a3d.start_onlyFrames + persoBehaviour.currentFrame];
            for (int i = 0; i < persoBehaviour.a3d.num_channels; i++)
            {
                AnimChannel ch = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i];
                AnimNumOfNTTO numOfNTTO = persoBehaviour.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
                int poNum = numOfNTTO.numOfNTTO - persoBehaviour.a3d.start_NTTO;

                AnimNTTO ntto = persoBehaviour.a3d.ntto[persoBehaviour.a3d.start_NTTO + poNum];
                if (!ntto.IsInvisibleNTTO)
                {
                    PhysicalObject physicalObject = persoBehaviour.subObjects[i][poNum];
                    subobjectsCache.ConsiderPhysicalObject(
                        physicalObject, persoBehaviour.currentState, (int)persoBehaviour.currentFrame, ch.id, ntto.object_index);
                    resultSubobjectsList.Add(subobjectsCache.GetPhysicalObjectCachedModelFor(ntto.object_index));
                }                    
            }
            throw new NotImplementedException();
        }

        private Tuple<SubobjectsChannelsAssociation, List<Tuple<SubobjectModel, VisualData>>> GetActualPhysicalSubobjectsForLargoFrame()
        {
            throw new NotImplementedException();
        }

        private Tuple<SubobjectsChannelsAssociation, List<Tuple<SubobjectModel, VisualData>>> GetActualPhysicalSubobjectsForMontrealFrame()
        {
            throw new NotImplementedException();
        }

        public Tuple<SubobjectsChannelsAssociation, List<SubobjectModel>> GetPersoBehaviourSubobjectsUsedForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                var result = GetActualPhysicalSubobjectsForNormalFrame();
                return new Tuple<SubobjectsChannelsAssociation, List<SubobjectModel>>(result.Item1,
                    result.Item2.Select(x => x.Item1).ToList());
            }
            else if (IsMontrealAnimation())
            {
                var result = GetActualPhysicalSubobjectsForMontrealFrame();
                return new Tuple<SubobjectsChannelsAssociation, List<SubobjectModel>>(result.Item1,
                    result.Item2.Select(x => x.Item1).ToList());
            }
            else if (IsLargoAnimation())
            {
                var result = GetActualPhysicalSubobjectsForLargoFrame();
                return new Tuple<SubobjectsChannelsAssociation, List<SubobjectModel>>(result.Item1,
                    result.Item2.Select(x => x.Item1).ToList());
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        public VisualData GetVisualDataForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                var result = GetActualPhysicalSubobjectsForNormalFrame();
                var visualsList = result.Item2.Select(x => x.Item2).ToList();

                return VisualDataUnifier.Unify(visualsList);
            }
            else if (IsMontrealAnimation())
            {
                var result = GetActualPhysicalSubobjectsForMontrealFrame();
                var visualsList = result.Item2.Select(x => x.Item2).ToList();

                return VisualDataUnifier.Unify(visualsList);
            }
            else if (IsLargoAnimation())
            {
                var result = GetActualPhysicalSubobjectsForLargoFrame();
                var visualsList = result.Item2.Select(x => x.Item2).ToList();

                return VisualDataUnifier.Unify(visualsList);
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }
    }
}
