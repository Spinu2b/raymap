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
    public class GeometricObjectToSubmeshGeometricObjectModelConverter
    {
        public SubmeshGeometricObject Convert(GeometricObjectWrapper geometricObject, int channelId)
        {
            var result = new SubmeshGeometricObject();
            result.id = GetGeometricObjectId(geometricObject, channelId);
            foreach (GeometricObjectElementWrapper geometricObjectElement in geometricObject.IterateElements())
            {
                SubmeshGeometricObjectElement submeshGeometricObjectElement = GetSubmeshGeometricObjectElement(geometricObjectElement, channelId);
                result.elements.Add(submeshGeometricObjectElement.id, submeshGeometricObjectElement);
            }
            return result;
        }

        private SubmeshGeometricObjectElement GetSubmeshGeometricObjectElement(GeometricObjectElementWrapper geometricObjectElement, int channelId)
        {
            throw new NotImplementedException();
        }

        private int GetGeometricObjectId(GeometricObjectWrapper geometricObject, int channelId)
        {
            throw new NotImplementedException();
        }
    }
}
