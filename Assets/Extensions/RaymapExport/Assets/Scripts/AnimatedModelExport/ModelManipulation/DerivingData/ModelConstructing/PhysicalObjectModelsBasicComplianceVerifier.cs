using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class GeometricObjectElementModelsBasicComplianceVerifier
    {
        private static void VerifyMeshData(SubmeshGeometricObjectElement exportElement, Mesh unityMesh)
        {
            if (exportElement.elementDescription.vertices.Count != unityMesh.vertexCount)
            {
                throw new InvalidOperationException("Vertices counts in geometric object elements do not match!");
            }
            if (exportElement.elementDescription.normals.Count != unityMesh.normals.Count())
            {
                throw new InvalidOperationException("Normals counts in geometric object elements do not match!");
            }
            if (exportElement.elementDescription.triangles.Count != unityMesh.triangles.Count())
            {
                throw new InvalidOperationException("Triangles vertices indices counts in geometric object elements do not match!");
            }
        }

        private static void VerifyMaterialsData(SubmeshGeometricObjectElement exportElement, GeometricObjectElementWrapper raymapElement)
        {
            if (exportElement.elementDescription.materials.Count != raymapElement.gameObject.GetComponent<Renderer>().materials.Count())
            {
                throw new InvalidOperationException("Materials counts for geometric object elements do not match!");
            }
        }

        private static void VerifySkinningData(SubmeshGeometricObjectElement exportElement, GeometricObjectElementWrapper raymapElement)
        {
            var modelExportBindBones = exportElement.elementDescription.bindBonePoses;
            var raymapBindBones = raymapElement.GetBindBonePoses();
            if (!ComparableModelDictionariesComparator.AreDictionariesCompliant(modelExportBindBones, raymapBindBones))
            {
                throw new InvalidOperationException("Bone bind poses in geometric object elements do not match!");
            }
            // could do some channel weights sanity verification as well, to consider
        }

        public static void VerifyFor(SubmeshGeometricObjectElement exportElement, GeometricObjectElementWrapper raymapElement)
        {
            VerifyMeshData(exportElement, raymapElement.GetMesh());
            VerifyMaterialsData(exportElement, raymapElement);
            VerifySkinningData(exportElement, raymapElement);
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
                foreach (var subobjectModelGeometricObject in subobjectModelGeometricObjects.OrderBy(x => x.Key))
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
            Func<List<KeyValuePair<int, SubmeshGeometricObjectElement>>, int, int> GetIndexOnListForGeometricObjectOriginalIndex = 
                (elementsList, originalIndex) => {
                    for (int i = 0; i < elementsList.Count; i++)
                    {
                        if (elementsList[i].Key == originalIndex) return i;
                    }
                    throw new InvalidOperationException("Could not find list index mapping for original index of geometric object element!");
            };

            if (currentIndex != subobjectModelGeometricObject.Key || currentIndex != saidCompliantPhysicalObjectGeometricObject.Item1)
            {
                throw new InvalidOperationException("Geometric objects indexes do not match!");
            }

            var saidCompliantPhysicalObjectGeometricObjectElementsList = saidCompliantPhysicalObjectGeometricObject.Item2.IterateElements().ToList();
            var elementModelsList = subobjectModelGeometricObject.Value.elements.OrderBy(x => x.Key).ToList();

            foreach (var subobjectGeometricObjectModelElement in elementModelsList)
            {
                int index = GetIndexOnListForGeometricObjectOriginalIndex(
                    elementModelsList, subobjectGeometricObjectModelElement.Key);
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
