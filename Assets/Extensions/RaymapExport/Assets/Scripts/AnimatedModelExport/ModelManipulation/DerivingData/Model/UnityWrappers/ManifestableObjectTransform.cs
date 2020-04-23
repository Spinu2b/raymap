using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers
{
    public class ManifestableObjectTransform
    {
        public Vector3d localPosition = new Vector3d(0.0f, 0.0f, 0.0f);

        public ManifestableObjectTransform parent {
            get
            {
                return new ManifestableObjectTransform();
            }

            set
            {

            }
        }

        internal void SetParent(ManifestableObjectTransform transform)
        {
            throw new NotImplementedException();
        }
    }
}
