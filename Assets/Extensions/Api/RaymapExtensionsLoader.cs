using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.Api
{
    public class RaymapExtensionsLoader : MonoBehaviour
    {
        public RaymapExtensionComponent[] extensionsList;

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
                foreach (var raymapExtension in extensionsList)
                {
                    raymapExtension.OnMapLoaded();
                }
                MapFinallyLoaded = true;
            }
        }
    }
}
