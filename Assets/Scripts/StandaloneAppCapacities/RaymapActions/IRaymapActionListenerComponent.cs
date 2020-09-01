using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.RaymapActions
{
    public interface IRaymapActionListenerComponent
    {
        void OnRaymapAction(RaymapActionsModuleComponent raymapActionsModuleComponent,
            string actionName, Dictionary<string, string> actionArguments);
        void RegisterForActions(RaymapActionsModuleComponent raymapActionsModuleComponent);
    }
}
