using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelLoading.Visuals.Norm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling.Textures.MapLoader
{
    public class MapLoaderReadTexturesFixMethodTexturesDataHolder
    {
        public void Init()
        {
            if (IsIndeedUsingReadTexturesFixMethod())
            {
                InternalInit();
            }
        }

        private void InternalInit()
        {
            throw new NotImplementedException();
        }

        private bool IsIndeedUsingReadTexturesFixMethod()
        {
            return MapLoaderHelper.IsR3Loader() || (MapLoaderHelper.IsR2Loader() && MapLoaderHelper.GetR2LoaderSNA().PTX != null);
        }
    }
}
