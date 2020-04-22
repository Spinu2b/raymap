using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Rom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers
{
    public static class PersoAccessorFactory
    {
        public static PersoAccessor FromPersoGameObject(GameObject persoGameObject)
        {
            if (persoGameObject.GetComponent<PersoBehaviour>() != null)
            {
                return NormalPersoAccessorFactory.FromPersoGameObject(persoGameObject);
            } else if (persoGameObject.GetComponent<ROMPersoBehaviour>() != null)
            {
                return RomPersoAccessorFactory.FromPersoGameObject(persoGameObject);
            } else
            {
                throw new InvalidOperationException("This gameobject has neither normal nor rom perso behaviour component!");
            }
        }
    }
}
