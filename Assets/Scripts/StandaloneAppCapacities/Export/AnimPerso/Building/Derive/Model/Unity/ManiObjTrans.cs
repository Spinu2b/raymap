using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Unity
{
    public class ManifestableObjectTransform
    {
        public Vector3d localPosition = new Vector3d(0.0f, 0.0f, 0.0f);

        public ManifestableObjectTransform parent
        {
            get
            {
                return new ManifestableObjectTransform();
            }

            set
            {

            }
        }

        public void SetParent(ManifestableObjectTransform transform)
        {
            throw new NotImplementedException();
        }
    }
}
