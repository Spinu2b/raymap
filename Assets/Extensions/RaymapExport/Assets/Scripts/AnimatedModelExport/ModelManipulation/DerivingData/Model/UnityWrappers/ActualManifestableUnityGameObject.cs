using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers
{
    public class ActualManifestableUnityGameObject
    {
        public string name = "";
        public ManifestableObjectTransform transform = new ManifestableObjectTransform();
        public string tag = "";

        public ActualManifestableUnityGameObject(string name)
        {
        }

        public ActualManifestableUnityGameObject()
        {

        }

        public void SetActive(bool active)
        {

        }
    }
}
