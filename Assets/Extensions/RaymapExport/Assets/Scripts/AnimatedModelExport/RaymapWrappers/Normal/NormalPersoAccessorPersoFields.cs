using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using OpenSpace.Animation;
using OpenSpace.Animation.Component;
using OpenSpace.Animation.ComponentLargo;
using OpenSpace.Object;
using OpenSpace.Object.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal
{
    public partial class NormalPersoAccessor
    {
        public bool isLoaded { get; set; } = false;
        public Perso perso;
        public Controller controller;

        public AnimA3DLargo animLargo = null;
        public AnimationMontreal animMontreal = null;
        public AnimA3DGeneral a3d = null;

        public bool hasStates = false;

        public float animationSpeed = 15f;

        public State state { get; private set; } = null;
        public int currentState { get; private set; } = 0;
        public int stateIndex = 0;

        public PhysicalObject[][] subObjects { get; set; } = null; // [channel][ntto]

        public ActualManifestableUnityGameObject[] channelObjects { get; set; }

        public int poListIndex = 0;
        public AnimMorphData[,] morphDataArray;

        public bool hasBones = false; // We can optimize a tiny bit if this object doesn't have bones

        public Dictionary<short, List<int>> channelIDDictionary = new Dictionary<short, List<int>>();
    }
}
