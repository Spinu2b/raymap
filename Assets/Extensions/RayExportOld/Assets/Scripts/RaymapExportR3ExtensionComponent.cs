using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts
{
    public class RaymapExportR3ExtensionComponent : RaymapExportExtensionComponent
    {
        protected override void OnPersoInject(GameObject persoGameObject)
        {
            persoGameObject.AddComponent<RaymapExportR3PersoModelExport>();
        }
    }
}
