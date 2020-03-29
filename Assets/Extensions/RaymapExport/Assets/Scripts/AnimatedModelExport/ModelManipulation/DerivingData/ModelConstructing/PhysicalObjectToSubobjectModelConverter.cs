using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
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
            foreach (GeometricObjectWrapper geometricObject in physicalObject.IterateGeometricObjects())
            {
                SubmeshGeometricObject submeshGeometricObject = GetSubmeshGeometricObject(geometricObject, channelId);
                result.Add(submeshGeometricObject.id, submeshGeometricObject);
            }
            return result;
        }

        private SubmeshGeometricObject GetSubmeshGeometricObject(GeometricObjectWrapper geometricObject, int channelId)
        {
            return geometricObjectToSubmeshGeometricObjectModelConverter.Convert(geometricObject, channelId);
        }

        private int GetObjectNumber(PhysicalObjectWrapper physicalObject, int physicalObjectNumber)
        {
            throw new NotImplementedException();
        }
    }
}
