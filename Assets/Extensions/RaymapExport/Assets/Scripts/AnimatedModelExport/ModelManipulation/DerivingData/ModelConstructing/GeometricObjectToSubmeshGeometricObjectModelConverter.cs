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
        private GeometricObjectElementToSubmeshGeometricObjectElementConverter geometricObjectElementToSubmeshGeometricObjectElementConverter
            = new GeometricObjectElementToSubmeshGeometricObjectElementConverter();

        public SubmeshGeometricObject Convert(GeometricObjectWrapper geometricObject, int channelId, int geometricObjectIndex)
        {
            var result = new SubmeshGeometricObject();
            result.id = GetGeometricObjectId(geometricObject, channelId, geometricObjectIndex);
            foreach (Tuple<int, GeometricObjectElementWrapper> geometricObjectElementInfo in geometricObject.IterateElements())
            {
                int geometricObjectElementIndex = geometricObjectElementInfo.Item1;
                var geometricObjectElement = geometricObjectElementInfo.Item2;
                SubmeshGeometricObjectElement submeshGeometricObjectElement = GetSubmeshGeometricObjectElement(geometricObjectElement, channelId, geometricObjectElementIndex);
                result.elements.Add(submeshGeometricObjectElement.id, submeshGeometricObjectElement);
            }
            return result;
        }

        private SubmeshGeometricObjectElement GetSubmeshGeometricObjectElement(GeometricObjectElementWrapper geometricObjectElement, int channelId, int geometricObjectElementIndex)
        {
            return geometricObjectElementToSubmeshGeometricObjectElementConverter.Convert(geometricObjectElement, channelId, geometricObjectElementIndex);
        }

        private int GetGeometricObjectId(GeometricObjectWrapper geometricObject, int channelId, int geometricObjectIndex)
        {
            return geometricObjectIndex;
        }
    }
}
