using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.EditorActions.Assets.Scripts
{
    public interface IEditorActionListenerComponent
    {
        void OnEditorAction(string actionName, Dictionary<string, string> actionArguments);
        void RegisterForActions(EditorActionsExtensionComponent editorActionsExtensionComponent);
    }
}
