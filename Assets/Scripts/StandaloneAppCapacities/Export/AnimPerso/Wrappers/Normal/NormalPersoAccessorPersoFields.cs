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

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal
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

        public State state { get; private set; } = null;
        public int currentState { get; private set; } = 0;
        public int stateIndex = 0;

        public int poListIndex = 0;
    }
}
