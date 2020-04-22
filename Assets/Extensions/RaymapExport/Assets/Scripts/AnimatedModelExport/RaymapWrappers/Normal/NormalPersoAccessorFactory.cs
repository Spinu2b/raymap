using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal
{
    public class NormalPersoAccessorFactory
    {
        public static NormalPersoAccessor FromPersoGameObject(GameObject persoGameObject)
        {
            var result = new NormalPersoAccessor();
            result.name = persoGameObject.name;
            return result;
        }
    }
}
