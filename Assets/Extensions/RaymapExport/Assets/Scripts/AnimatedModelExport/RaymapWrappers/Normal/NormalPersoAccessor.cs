using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using OpenSpace.Animation;
using OpenSpace.Animation.Component;
using OpenSpace.Animation.ComponentLargo;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal
{
    public class NormalPersoAccessor : PersoAccessor
    {
        #region NormalPerso definition 
        public bool isLoaded { get; private set; } = false;
        public Perso perso;

        public AnimA3DLargo animLargo = null;
        public AnimationMontreal animMontreal = null;
        public AnimA3DGeneral a3d = null;

        public PhysicalObject[][] subObjects { get; private set; } = null; // [channel][ntto]

        public ActualManifestableUnityGameObject[] channelObjects { get; private set; }

        public int poListIndex = 0;
        public AnimMorphData[,] morphDataArray;

        public bool hasBones = false; // We can optimize a tiny bit if this object doesn't have bones

        public Dictionary<short, List<int>> channelIDDictionary = new Dictionary<short, List<int>>();


        public List<int> GetChannelByID(short id)
        {
            if (channelIDDictionary.ContainsKey(id))
            {
                return channelIDDictionary[id];
            }
            else return new List<int>();
        }


        #endregion


        #region Base PersoAccessor interface
        public override int statesCount => throw new NotImplementedException();

        public override int currentAnimationStateFramesCount => throw new NotImplementedException();

        public void UpdateAnimation()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, int> GetChannelParentingInfosForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, ChannelTransformModel> GetChannelsKeyframeDataForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override List<Tuple<int, int, int>> GetMorphDataForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override SubobjectsChannelsAssociation GetSubobjectsChannelsAssociationForAnimationFrame(int frameNumber)
        {
            throw new NotImplementedException();
        }

        public override SubobjectsLibraryModel GetSubobjectsLibrary()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidAnimationState(int animationStateIndex)
        {
            throw new NotImplementedException();
        }

        public override void SetState(int stateIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
