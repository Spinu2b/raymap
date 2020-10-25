using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso
{
    public class AnimPersoExportComponent : MonoBehaviour
    {
        public AnimatedPersoDescription ExportAnimatedPerso()
        {
            var exporter = new AnimatedPersoExporter();
            PersoAccessor persoAccessor = GetPersoAccessor(gameObject);

            AnimatedPersoDescription result = exporter.Export(persoAccessor);
            if (result.subobjectsLibrary.subobjects.Values.Where(x => x.geometricObject.bindBonePoses.Count != 0).Count() == 0)
            {
                throw new InvalidOperationException("None of the subobjects has bone bind poses model!");
            }
            return result;
        }

        private PersoAccessor GetPersoAccessor(GameObject persoGameObject)
        {
            return PersoAccessorFactory.FromPersoGameObject(persoGameObject);
        }
    }
}
