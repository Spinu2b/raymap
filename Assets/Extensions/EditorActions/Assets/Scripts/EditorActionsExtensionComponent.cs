using Assets.Extensions.Api;
using Assets.Extensions.EditorActions.Assets.Scripts.BuiltinActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.EditorActions.Assets.Scripts
{
    public class EditorActionsExtensionComponent : RaymapExtensionComponent
    {
        private Dictionary<string, IEditorActionListenerComponent> actionListeners = new Dictionary<string, IEditorActionListenerComponent>();

        public void SetActionListener(string actionName, IEditorActionListenerComponent actionListener)
        {
            throw new NotImplementedException();
        }

        public void SetActionCompleted(string actionName)
        {
            throw new NotImplementedException();
        }

        protected override void OnMapLoaded()
        {
            throw new NotImplementedException();
        }
    }
}
