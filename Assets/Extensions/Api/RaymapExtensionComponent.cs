﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.Api
{
    public abstract class RaymapExtensionComponent : MonoBehaviour
    {
        protected abstract void OnMapLoaded();

        private Controller raymapController;

        private bool MapFinallyLoaded = false;
        private bool IsMapLoaded()
        {
            return raymapController.LoadState == Controller.State.Finished;
        }

        private void Awake()
        {
            raymapController = (Controller)FindObjectOfType(typeof(Controller));
        }

        private void Update()
        {
            if (!IsMapLoaded())
            {
                return;
            }
            else if (!MapFinallyLoaded)
            {
                OnMapLoaded();
                MapFinallyLoaded = true;
            }
        }
    }
}
