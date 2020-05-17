using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ResourcesHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts
{
    public class EnvironmentContext
    {
        private ResourcesDataHolder resourcesDataHolder = new ResourcesDataHolder();

        public void Init()
        {
            resourcesDataHolder.Init();
        }

        public ResourcesDataHolder getResourcesDataHolder()
        {
            return resourcesDataHolder;
        }
    }
}
