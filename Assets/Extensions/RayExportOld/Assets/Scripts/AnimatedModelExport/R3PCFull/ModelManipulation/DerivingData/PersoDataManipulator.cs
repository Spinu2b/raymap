using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.Common;
using OpenSpace.Object;
using OpenSpace.Object.Properties;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData
{
    public abstract class PersoDataManipulator
    {
        protected PersoBehaviourInterface GetPersoBehaviourFor(GameObject persoR3GameObject)
        {
            if (persoR3GameObject.GetComponent<PersoBehaviour>() != null)
            {
                return new PersoBehaviourInterface(persoR3GameObject.GetComponent<PersoBehaviour>());
            } 
            else if (persoR3GameObject.GetComponent<ROMPersoBehaviour>() != null)
            {
                return new PersoBehaviourInterface(persoR3GameObject.GetComponent<ROMPersoBehaviour>());
            } 
            else
            {
                throw new InvalidOperationException("This game object does not have any Perso Behaviour component!");
            }
        }
    }
}
