using Assets.Scripts.Unity.Export.AnimPerso.Building;
using Assets.Scripts.Unity.Export.AnimPerso.Model;
using Assets.Scripts.Unity.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Unity.Export.AnimPerso
{
    public class AnimPersoExportComponent : MonoBehaviour
    {
        public AnimatedPersoDescription ExportAnimatedPerso()
        {
            var exporter = new AnimatedPersoExporter();
            PersoAccessor persoAccessor = GetPersoAccessor(gameObject);

            AnimatedPersoDescription result = exporter.Export(persoAccessor);
            return result;
        }

        private PersoAccessor GetPersoAccessor(GameObject persoGameObject)
        {
            return PersoAccessorFactory.FromPersoGameObject(persoGameObject);
        }
    }
}
