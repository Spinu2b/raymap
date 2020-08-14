using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Model.AnimClipsDesc
{
    public class SubobjectUsedMorphAssociationInfo
    {
        public int morphSubobjectStart;
        public int morphSubobjectEnd;
        public Dictionary<int, float> morphProgressKeyframes = new Dictionary<int, float>();

        public SubobjectUsedMorphAssociationInfo(int morphSubobjectStart, int morphSubobjectEnd)
        {
            this.morphSubobjectStart = morphSubobjectStart;
            this.morphSubobjectEnd = morphSubobjectEnd;
        }

        public int GetMinimalKeyframeNumber()
        {
            return morphProgressKeyframes.Keys.Min();
        }

        public int GetMaxKeyframeNumber()
        {
            return morphProgressKeyframes.Keys.Max();
        }
    }
}
