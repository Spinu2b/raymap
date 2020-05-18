﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Rom
{
    public abstract class RomPersoBehaviourAnimationDataFetchingHelper
    {
        protected ROMPersoBehaviour romPersoBehaviour;

        public RomPersoBehaviourAnimationDataFetchingHelper(ROMPersoBehaviour romPersoBehaviour)
        {
            this.romPersoBehaviour = romPersoBehaviour;
        }
    }
}
