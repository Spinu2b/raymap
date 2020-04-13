using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using OpenSpace.Object;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class PhysicalObjectToSubobjectModelConverter
    {
        private GeometricObjectToSubmeshGeometricObjectModelConverter geometricObjectToSubmeshGeometricObjectModelConverter 
            = new GeometricObjectToSubmeshGeometricObjectModelConverter();

        public SubobjectModel Convert(PhysicalObjectWrapper physicalObject, int physicalObjectNumber, int channelId)
        {
            var result = new SubobjectModel();
            result.objectNumber = GetObjectNumber(physicalObject, physicalObjectNumber);
            result.geometricObjects = GetGeometricObjects(physicalObject, channelId);
            return result;
        }

        private Dictionary<int, SubmeshGeometricObject> GetGeometricObjects(PhysicalObjectWrapper physicalObject, int channelId)
        {
            var result = new Dictionary<int, SubmeshGeometricObject>();
            foreach (Tuple<int, GeometricObjectWrapper> geometricObjectInfo in physicalObject.IterateGeometricObjects())
            {
                int geometricObjectIndex = geometricObjectInfo.Item1;
                var geometricObject = geometricObjectInfo.Item2;
                SubmeshGeometricObject submeshGeometricObject = GetSubmeshGeometricObject(geometricObject, channelId, geometricObjectIndex);
                result.Add(submeshGeometricObject.id, submeshGeometricObject);
            }
            return result;
        }

        private SubmeshGeometricObject GetSubmeshGeometricObject(GeometricObjectWrapper geometricObject, int channelId, int geometricObjectIndex)
        {
            return geometricObjectToSubmeshGeometricObjectModelConverter.Convert(geometricObject, channelId, geometricObjectIndex);
        }

        private int GetObjectNumber(PhysicalObjectWrapper physicalObject, int physicalObjectNumber)
        {
            return physicalObjectNumber;
        }
    }
}
