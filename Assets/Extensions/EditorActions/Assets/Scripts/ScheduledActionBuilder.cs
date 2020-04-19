using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.EditorActions.Assets.Scripts
{
    public class ScheduledActionBuilder
    {
        private string actionName;
        private Dictionary<string, string> actionArguments = new Dictionary<string, string>();

        public void SetActionName(string actionName)
        {
            this.actionName = actionName;
        }

        public void AddActionArgument(string argumentName, string argumentValue)
        {
            actionArguments.Add(argumentName, argumentValue);
        }

        public ScheduledAction BuildIfPresentOrReturnNull()
        {
            if (actionName != null)
            {
                return new ScheduledAction(actionName, actionArguments);
            } else
            {
                return null;
            }
        }
    }
}
