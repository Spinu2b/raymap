using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public static class MaterialsTexturesImagesModelUnifier
    {
        public static Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>> 
            Unify(List<Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>> parts, 
            bool verifyIdsUniqueContract = false)
        {
            throw new NotImplementedException();
        }
    }

    public class NormalPersoBehaviourAnimationSubobjectDataFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        private SubobjectsCache subobjectsCache = new SubobjectsCache();

        public NormalPersoBehaviourAnimationSubobjectDataFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        private IEnumerable<Tuple<SubobjectModel,
            Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>>
            IterateActualPhysicalSubobjectsForNormalFrame()
        {
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
                        physicalObject, persoBehaviour.currentState, (int)persoBehaviour.currentFrame, ch.id, poNum);
                    yield return subobjectsCache.GetPhysicalObjectCachedModelFor(poNum);
                }                    
            }
        }

        private IEnumerable<Tuple<SubobjectModel,
            Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>> IterateActualPhysicalSubobjectsForLargoFrame()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Tuple<SubobjectModel,
            Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>> IterateActualPhysicalSubobjectsForMontrealFrame()
        {
            throw new NotImplementedException();
        }

        public List<SubobjectModel> GetPersoBehaviourSubobjectsUsedForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return new List<SubobjectModel>(IterateActualPhysicalSubobjectsForNormalFrame().Select(x => x.Item1));
            }
            else if (IsMontrealAnimation())
            {
                return new List<SubobjectModel>(IterateActualPhysicalSubobjectsForMontrealFrame().Select(x => x.Item1));
            }
            else if (IsLargoAnimation())
            {
                return new List<SubobjectModel>(IterateActualPhysicalSubobjectsForLargoFrame().Select(x => x.Item1));
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        public Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>
            GetPersoBehaviourMaterialsTexturesImagesUsedForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return MaterialsTexturesImagesModelUnifier.Unify(
                    IterateActualPhysicalSubobjectsForNormalFrame().Select(x => 
                    new Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>(x.Item2, x.Item3, x.Item4)).ToList());
            }
            else if (IsMontrealAnimation())
            {
                return MaterialsTexturesImagesModelUnifier.Unify(IterateActualPhysicalSubobjectsForMontrealFrame().Select(x =>
                    new Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>(x.Item2, x.Item3, x.Item4)).ToList());
            }
            else if (IsLargoAnimation())
            {
                return MaterialsTexturesImagesModelUnifier.Unify(IterateActualPhysicalSubobjectsForLargoFrame().Select(x =>
                    new Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>(x.Item2, x.Item3, x.Item4)).ToList());
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }
    }
}
