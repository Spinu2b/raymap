using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using OpenSpace.Collide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions
{
    public static class GeometricObjectCollideExtensions
    {
        public static GeometricObjectCollide ForExportClone(this GeometricObjectCollide geometricObjectCollide)
        {
            
        }

        public static ActualManifestableUnityGameObject GetRaymapExportGao(this GeometricObjectCollide geometricObjectCollide)
        {
            return new ActualManifestableUnityGameObject();
        }
    }
}
