using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc
{
    public class SubmeshGeometricObject : IComparableModel<SubmeshGeometricObject>
    {
        public int id;
        public Dictionary<int, SubmeshGeometricObjectElement> elements = new Dictionary<int, SubmeshGeometricObjectElement>();

        public bool EqualsToAnother(SubmeshGeometricObject other)
        {
            if (id != other.id)
            {
                return false;
            }

            if (elements.Count != other.elements.Count)
            {
                return false;
            }

            foreach (var geometricObjectElementId in elements.Keys)
            {
                if (!other.elements.ContainsKey(geometricObjectElementId))
                {
                    return false;
                }
                if (!elements[geometricObjectElementId].EqualsToAnother(other.elements[geometricObjectElementId]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
