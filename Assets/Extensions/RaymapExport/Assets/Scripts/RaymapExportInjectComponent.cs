﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.Api;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts
{
    public abstract class RaymapExportInjectComponent : ExtensionInjectComponent
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

        protected abstract void OnPersoInject(GameObject persoGameObject);
    }
}