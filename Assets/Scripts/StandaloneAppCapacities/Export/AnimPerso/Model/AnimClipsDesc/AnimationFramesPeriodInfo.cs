using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc
{
    public class AnimationFramesPeriodInfo
    {
        public int frameBegin;
        public int frameEnd;

        public AnimationFramesPeriodInfo(int frameBegin, int frameEnd)
        {
            this.frameBegin = frameBegin;
            this.frameEnd = frameEnd;
        }
    }
}
