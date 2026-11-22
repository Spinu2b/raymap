using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModelExport.R3.PersoStatesArmatureAnimationsExporting.Model
{
    public class AnimationFrameModel : Tree<AnimationFrameModelNode, string>
    {
        // R3 vertex morphs in this frame: source PO ("PO<index>") -> target PO -> blend shape weight (0..1).
        // Null when nothing morphs.
        public Dictionary<string, Dictionary<string, float>> morphWeights;
    }
}
