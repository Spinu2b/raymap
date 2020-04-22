using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.OpenSpace;
using OpenSpace.Object;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class PhysicalObjectToSubobjectModelConverter
    {
        private GeometricObjectToSubmeshGeometricObjectModelConverter geometricObjectToSubmeshGeometricObjectModelConverter 
            = new GeometricObjectToSubmeshGeometricObjectModelConverter();

        public SubobjectModel Convert(PhysicalObjectWrapper physicalObject, int physicalObjectNumber)
        {
            var result = new SubobjectModel();
            result.objectNumber = GetObjectNumber(physicalObject, physicalObjectNumber);
            result.geometricObjects = GetGeometricObjects(physicalObject);
            return result;
        }

        private Dictionary<int, SubmeshGeometricObject> GetGeometricObjects(PhysicalObjectWrapper physicalObject)
        {
            var result = new Dictionary<int, SubmeshGeometricObject>();
            foreach (Tuple<int, GeometricObjectWrapper> geometricObjectInfo in physicalObject.IterateGeometricObjects())
            {
                int geometricObjectIndex = geometricObjectInfo.Item1;
                var geometricObject = geometricObjectInfo.Item2;
                SubmeshGeometricObject submeshGeometricObject = GetSubmeshGeometricObject(geometricObject, geometricObjectIndex);
                result.Add(submeshGeometricObject.id, submeshGeometricObject);
            }
            return result;
        }

        private SubmeshGeometricObject GetSubmeshGeometricObject(GeometricObjectWrapper geometricObject, int geometricObjectIndex)
        {
            return geometricObjectToSubmeshGeometricObjectModelConverter.Convert(geometricObject, geometricObjectIndex);
        }

        private int GetObjectNumber(PhysicalObjectWrapper physicalObject, int physicalObjectNumber)
        {
            return physicalObjectNumber;
        }
    }
}
