using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling.Textures.MapLoader
{
    public class MapLoaderLoadMemoryMethodTexturesDataHolder
    {
        public void Init()
        {
            if (IsIndeedUsingLoadMemoryMethodRightNow())
            {
                InternalInit();
            }
        }

        private bool IsIndeedUsingLoadMemoryMethodRightNow()
        {
            return OpenSpace.MapLoader.Loader.lvlName.EndsWith(".exe");
        }

        private void InternalInit()
        {
            throw new NotImplementedException();
        }
    }
}
