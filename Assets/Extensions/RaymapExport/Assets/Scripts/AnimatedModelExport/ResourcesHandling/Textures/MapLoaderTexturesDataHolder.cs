using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling.Textures
{
    public class MapLoaderLoadMemoryMethodTexturesDataHolder
    {
        public void Init()
        {
            throw new NotImplementedException();
        }
    }

    public class MapLoaderReadTexturesFixMethodTexturesDataHolder
    {
        public void Init()
        {
            throw new NotImplementedException();
        }
    }

    public class MapLoaderReadTexturesLvlMethodTexturesDataHolder
    {
        public void Init()
        {
            throw new NotImplementedException();
        }
    }

    public class MapLoaderTexturesDataHolder
    {
        private MapLoaderLoadMemoryMethodTexturesDataHolder mapLoaderLoadMemoryMethodTexturesDataHolder =
            new MapLoaderLoadMemoryMethodTexturesDataHolder();
        private MapLoaderReadTexturesFixMethodTexturesDataHolder mapLoaderReadTexturesFixMethodTexturesDataHolder =
            new MapLoaderReadTexturesFixMethodTexturesDataHolder();
        private MapLoaderReadTexturesLvlMethodTexturesDataHolder mapLoaderReadTexturesLvlMethodTexturesDataHolder =
            new MapLoaderReadTexturesLvlMethodTexturesDataHolder();

        public void Init()
        {
            mapLoaderLoadMemoryMethodTexturesDataHolder.Init();
            mapLoaderReadTexturesFixMethodTexturesDataHolder.Init();
            mapLoaderReadTexturesLvlMethodTexturesDataHolder.Init();
        }
    }
}
