using OpenSpace.Animation.Component;
using OpenSpace.Object;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourMorphFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourMorphFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

        public List<Tuple<int, int, int>> GetPersoBehaviourMorphDataForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetMorphDataForNormalAnimation();
            }
            else if (IsMontrealAnimation())
            {
                return GetMorphDataForMontrealAnimation();
            }
            else if (IsLargoAnimation())
            {
                return GetMorphDataForLargoAnimation();
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private List<Tuple<int, int, int>> GetMorphDataForLargoAnimation()
        {
            throw new NotImplementedException();
        }

        private List<Tuple<int, int, int>> GetMorphDataForMontrealAnimation()
        {
            throw new NotImplementedException();
        }

        private List<Tuple<int, int, int>> GetMorphDataForNormalAnimation()
        {
            var result = new List<Tuple<int, int, int>>();
            AnimOnlyFrame of = persoBehaviour.a3d.onlyFrames[persoBehaviour.a3d.start_onlyFrames + persoBehaviour.currentFrame];
            for (int i = 0; i < persoBehaviour.a3d.num_channels; i++)
            {
                AnimChannel ch = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i];
                AnimNumOfNTTO numOfNTTO = persoBehaviour.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
                int poNum = numOfNTTO.numOfNTTO - persoBehaviour.a3d.start_NTTO;
                PhysicalObject physicalObject = persoBehaviour.subObjects[i][poNum];

                if (physicalObject != null && persoBehaviour.a3d.num_morphData > 0 && persoBehaviour.morphDataArray != null
                    && i < persoBehaviour.morphDataArray.GetLength(0) && persoBehaviour.currentFrame < persoBehaviour.morphDataArray.GetLength(1))
                {
                    AnimMorphData morphData = persoBehaviour.morphDataArray[i, persoBehaviour.currentFrame];
                    if (morphData != null && ((morphData.morphProgress != 0 && morphData.morphProgress != 100) || morphData.morphProgress == 100))
                    {
                        PhysicalObject morphToPO = persoBehaviour.perso.p3dData.objectList[morphData.objectIndexTo].po;

                        for (int j = 0; j < physicalObject.visualSet.Length; j++)
                        {
                            IGeometricObject obj = physicalObject.visualSet[j].obj;
                            if (obj == null || obj as GeometricObject == null) continue;
                            GeometricObject fromM = obj as GeometricObject;
                            GeometricObject toM = morphToPO.visualSet[j].obj as GeometricObject;
                            if (toM == null) continue;
                            if (fromM.vertices.Length != toM.vertices.Length)
                            {
                                // For those special cases like the mistake in the Clark cinematic
                                continue;
                            }

                            AnimNTTO ntto_link = persoBehaviour.a3d.ntto[numOfNTTO.numOfNTTO];

                            int physicalObjectNumberMorphTo = morphData.objectIndexTo;
                            int physicalObjectNumberMorphFrom = ntto_link.object_index;
                            int morphProgress = morphData.morphProgress;
                            result.Add(new Tuple<int, int, int>(
                                physicalObjectNumberMorphFrom, physicalObjectNumberMorphTo, morphProgress));
                        }
                    }
                }
            }
            return result;
        }
    }
}
