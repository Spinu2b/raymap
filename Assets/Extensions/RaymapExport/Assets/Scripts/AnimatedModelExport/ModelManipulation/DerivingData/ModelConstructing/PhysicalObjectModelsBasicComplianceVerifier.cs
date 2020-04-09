using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class GeometricObjectElementModelsBasicComplianceVerifier
    {
        public static void VerifyFor(SubmeshGeometricObjectElement exportElement, GeometricObjectElementWrapper raymapElement)
        {
            if (exportElement.elementDescription.vertices.Count != raymapElement.GetVertices().Count())
            {
                throw new InvalidOperationException("Vertices counts in geometric object elements do not match!");
            }
            throw new NotImplementedException();
        }
    }

    public class PhysicalObjectModelsBasicComplianceVerifier
    {
        public static void VerifyBasicCompliance(SubobjectModel subobject, PhysicalObjectWrapper physicalObject)
        {
            VerifyGeometricObjects(subobject, physicalObject);
        }

        private static void VerifyGeometricObjects(SubobjectModel subobject, PhysicalObjectWrapper physicalObject)
        {
            var subobjectModelGeometricObjects = subobject.geometricObjects;
            var physicalObjectGeometricObjects = physicalObject.IterateGeometricObjects().ToList();

            if (subobjectModelGeometricObjects.Count != physicalObjectGeometricObjects.Count)
            {
                throw new InvalidOperationException(
                    "Counts of respective geometric objects lists that should be compliant to each other are different!");
            } else
            {
                int currentIndex = 0;
                foreach (var subobjectModelGeometricObject in subobjectModelGeometricObjects)
                {
                    var saidCompliantPhysicalObjectGeometricObject = physicalObjectGeometricObjects[currentIndex];
                    VerifyGeometricObject(currentIndex, subobjectModelGeometricObject, saidCompliantPhysicalObjectGeometricObject);
                    currentIndex++;
                }
            }
        }

        private static void VerifyGeometricObject(int currentIndex
            , KeyValuePair<int, SubmeshGeometricObject> subobjectModelGeometricObject,
            Tuple<int, GeometricObjectWrapper> saidCompliantPhysicalObjectGeometricObject)
        {
            if (currentIndex != subobjectModelGeometricObject.Key || currentIndex != saidCompliantPhysicalObjectGeometricObject.Item1)
            {
                throw new InvalidOperationException("Geometric objects indexes do not match!");
            }

            var saidCompliantPhysicalObjectGeometricObjectElementsList = saidCompliantPhysicalObjectGeometricObject.Item2.IterateElements().ToList();

            foreach (var subobjectGeometricObjectModelElement in subobjectModelGeometricObject.Value.elements.OrderBy(x => x.Key))
            {
                int index = subobjectGeometricObjectModelElement.Key;
                var saidCompliantPhysicalObjectGeometricObjectElement = saidCompliantPhysicalObjectGeometricObjectElementsList[index];

                VerifyGeometricObjectElement(subobjectGeometricObjectModelElement, saidCompliantPhysicalObjectGeometricObjectElement);
            }
        }

        private static void VerifyGeometricObjectElement(
            KeyValuePair<int, SubmeshGeometricObjectElement> subobjectGeometricObjectModelElement,
            Tuple<int, GeometricObjectElementWrapper> saidCompliantPhysicalObjectGeometricObjectElement)
        {
            if (subobjectGeometricObjectModelElement.Key != saidCompliantPhysicalObjectGeometricObjectElement.Item1) {
                throw new InvalidOperationException("Geometric object elements indexes do not match!");
            }

            GeometricObjectElementModelsBasicComplianceVerifier.VerifyFor(
                subobjectGeometricObjectModelElement.Value, saidCompliantPhysicalObjectGeometricObjectElement.Item2);
        }
    }
}
