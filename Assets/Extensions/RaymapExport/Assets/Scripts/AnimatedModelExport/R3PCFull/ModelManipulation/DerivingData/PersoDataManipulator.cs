using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSpace.Object.Properties;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingData
{
    public abstract class PersoDataManipulator
    {
        protected Family GetFamilyForPerso(GameObject persoR3GameObject)
        {
            return persoR3GameObject.GetComponent<PersoBehaviour>().perso.p3dData.family;
        }
    }
}
