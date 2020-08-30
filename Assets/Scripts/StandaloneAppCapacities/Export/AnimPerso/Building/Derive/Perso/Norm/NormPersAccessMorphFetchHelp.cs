using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm
{
    public class NormalPersoAccessorMorphFetchingHelper : NormalPersoAccessorAnimationDataFetchingHelper
    {
        public NormalPersoAccessorMorphFetchingHelper(NormalPersoAccessor normalPersoAccessor) : base(normalPersoAccessor)
        {
        }

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
            AnimOnlyFrame of = normalPersoAccessor.a3d.onlyFrames[normalPersoAccessor.a3d.start_onlyFrames + normalPersoAccessor.currentFrame];
            for (int i = 0; i < normalPersoAccessor.a3d.num_channels; i++)
            {
                AnimChannel ch = normalPersoAccessor.a3d.channels[normalPersoAccessor.a3d.start_channels + i];
                AnimNumOfNTTO numOfNTTO = normalPersoAccessor.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
                int poNum = numOfNTTO.numOfNTTO - normalPersoAccessor.a3d.start_NTTO;
                PhysicalObject physicalObject = normalPersoAccessor.subObjects[i][poNum];

                if (physicalObject != null && normalPersoAccessor.a3d.num_morphData > 0 && normalPersoAccessor.morphDataArray != null
                    && i < normalPersoAccessor.morphDataArray.GetLength(0) && normalPersoAccessor.currentFrame < normalPersoAccessor.morphDataArray.GetLength(1))
                {
                    AnimMorphData morphData = normalPersoAccessor.morphDataArray[i, normalPersoAccessor.currentFrame];
                    if (morphData != null && ((morphData.morphProgress != 0 && morphData.morphProgress != 100) || morphData.morphProgress == 100))
                    {
                        PhysicalObject morphToPO = normalPersoAccessor.perso.p3dData.objectList[morphData.objectIndexTo].po;

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

                            AnimNTTO ntto_link = normalPersoAccessor.a3d.ntto[numOfNTTO.numOfNTTO];

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
