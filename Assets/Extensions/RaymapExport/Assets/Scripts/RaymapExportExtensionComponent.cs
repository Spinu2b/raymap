using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.Api;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts
{
    public class RaymapExportExtensionComponent : RaymapExtensionComponent
    {
        protected override void OnMapLoaded()
        {
            InjectIntoPersos();
        }

        private void InjectIntoPersos()
        {
            foreach (var persoGameObject in RaymapSceneHelper.IteratePersoGameObjects())
            {
                OnPersoInject(persoGameObject);
            }
        }

        protected void OnPersoInject(GameObject persoGameObject)
        {
            persoGameObject.AddComponent<RaymapExportPersoComponent>();
        }
    }
}
