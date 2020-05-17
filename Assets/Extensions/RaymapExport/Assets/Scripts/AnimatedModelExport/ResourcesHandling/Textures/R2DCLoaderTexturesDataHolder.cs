using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling.Textures
{
    public class R2DCLoaderLoadDreamcastMethodTexturesDataHolder
    {
        public void Init()
        {
            throw new NotImplementedException();
        }
    }

    public class R2DCLoaderLoadMethodTexturesDataHolder
    {
        public void Init()
        {
            throw new NotImplementedException();
        }
    }

    public class R2DCLoaderTexturesDataHolder
    {
        private R2DCLoaderLoadDreamcastMethodTexturesDataHolder r2DCLoaderLoadDreamcastMethodTexturesDataHolder;
        private R2DCLoaderLoadMethodTexturesDataHolder R2DCLoaderLoadMethodTexturesDataHolder;

        public void Init()
        {
            r2DCLoaderLoadDreamcastMethodTexturesDataHolder.Init();
            R2DCLoaderLoadMethodTexturesDataHolder.Init();
        }
    }
}
