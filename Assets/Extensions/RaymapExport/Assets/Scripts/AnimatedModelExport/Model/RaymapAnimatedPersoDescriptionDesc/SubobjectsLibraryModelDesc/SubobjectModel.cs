using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc
{
    public class SubobjectModel
    {
        public int objectNumber;
        public Dictionary<int, SubmeshGeometricObject> geometricObjects = new Dictionary<int, SubmeshGeometricObject>();

        public bool EqualsToAnother(SubobjectModel other)
        {
            if (objectNumber != other.objectNumber)
            {
                return false;
            }

            if (geometricObjects.Count != other.geometricObjects.Count)
            {
                return false;
            }

            foreach (var geometricObjectId in geometricObjects.Keys)
            {
                if (!other.geometricObjects.ContainsKey(geometricObjectId))
                {
                    return false;
                }
                if (!geometricObjects[geometricObjectId].EqualsToAnother(other.geometricObjects[geometricObjectId]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
