using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Modules.RaymapPlayApi
{
    public abstract class RaymapPlayComponent : MonoBehaviour
    {
        protected abstract void OnMapLoaded();
        private Controller raymapController;

        private bool FinallyLoaded = false;
        private bool IsMapLoaded()
        {
            return raymapController.LoadState == Controller.State.Finished;
        }

        protected void Awake()
        {
            raymapController = (Controller)FindObjectOfType(typeof(Controller));
        }

        private void Update()
        {
            if (!IsMapLoaded())
            {
                return;
            } else if (!FinallyLoaded)
            {
                OnMapLoaded();
                FinallyLoaded = true;
            }
        }

    }
}
