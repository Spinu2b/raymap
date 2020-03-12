using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.Api
{
    public abstract class ExtensionInjectComponent : MonoBehaviour
    {
        private bool IsInjected = false;
        private bool MapFinallyLoaded = false;
        private bool IsMapLoaded()
        {
            throw new NotImplementedException();
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

        protected abstract void OnMapLoaded();
    }
}
