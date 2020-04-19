using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.EditorActions.Assets.Scripts
{
    public class ScheduledAction
    {
        public string actionName;
        public Dictionary<string, string> actionArguments = new Dictionary<string, string>();

        public ScheduledAction(string actionName, Dictionary<string, string> actionArguments)
        {
            this.actionName = actionName;
            this.actionArguments = actionArguments;
        }
    }
}
