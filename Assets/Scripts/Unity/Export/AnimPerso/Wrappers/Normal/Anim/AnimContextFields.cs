using Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model.Unity;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Wrappers.Normal
{
    public partial class NormalPersoAccessor
    {
        public float animationSpeed = 15f;
        public PhysicalObject[][] subObjects { get; set; } = null; // [channel][ntto]

        public ActualManifestableUnityGameObject[] channelObjects { get; set; }
        public AnimMorphData[,] morphDataArray;

        public bool hasBones = false; // We can optimize a tiny bit if this object doesn't have bones

        public Dictionary<short, List<int>> channelIDDictionary = new Dictionary<short, List<int>>();
    }
}
