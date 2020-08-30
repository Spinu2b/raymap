using Assets.Scripts.Unity.Export.AnimPerso.Wrappers;
using Assets.Scripts.Unity.Export.AnimPerso.Wrappers.Normal;
using Assets.Scripts.Unity.Export.AnimPerso.Wrappers.Ps1;
using Assets.Scripts.Unity.Export.AnimPerso.Wrappers.Rom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Unity.Export.Wrappers
{
    public class PersoAccessorFactory
    {
        public static PersoAccessor FromPersoGameObject(GameObject persoGameObject)
        {
            if (persoGameObject.GetComponent<PersoBehaviour>() != null)
            {
                return NormalPersoAccessorFactory.FromPersoGameObject(persoGameObject);
            } else if (persoGameObject.GetComponent<ROMPersoBehaviour>() != null)
            {
                return RomPersoAccessorFactory.FromPersoGameObject(persoGameObject);
            } else if (persoGameObject.GetComponent<PS1PersoBehaviour>() != null)
            {
                return Ps1PersoAccessorFactory.FromPersoGameObject(persoGameObject);
            } else
            {
                throw new InvalidOperationException("This gameobject has neither normal, rom nor ps1 perso behaviour component!");
            }
        }
    }
}
