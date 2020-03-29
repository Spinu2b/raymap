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
    public abstract class NormalPersoBehaviourAnimationSubobjectDataFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        private SubobjectsCache subobjectsCache = new SubobjectsCache();

        public NormalPersoBehaviourAnimationSubobjectDataFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        protected IEnumerable<SubobjectModel> IterateActualPhysicalSubobjectsForNormalFrame()
        {
            AnimOnlyFrame of = persoBehaviour.a3d.onlyFrames[persoBehaviour.a3d.start_onlyFrames + persoBehaviour.currentFrame];
            for (int i = 0; i < persoBehaviour.a3d.num_channels; i++)
            {
                AnimChannel ch = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i];
                AnimNumOfNTTO numOfNTTO = persoBehaviour.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
                int poNum = numOfNTTO.numOfNTTO - persoBehaviour.a3d.start_NTTO;
                PhysicalObject physicalObject = persoBehaviour.subObjects[i][poNum];

                subobjectsCache.ConsiderPhysicalObject(
                    physicalObject, persoBehaviour.currentState, (int)persoBehaviour.currentFrame, ch.id, poNum);
                yield return subobjectsCache.GetPhysicalObjectCachedModelFor(poNum);
            }
        }

        protected IEnumerable<SubobjectModel> IterateActualPhysicalSubobjectsForLargoFrame()
        {
            throw new NotImplementedException();
        }

        protected IEnumerable<SubobjectModel> IterateActualPhysicalSubobjectsForMontrealFrame()
        {
            throw new NotImplementedException();
        }
    }
}
