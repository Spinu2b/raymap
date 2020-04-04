using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model
{
    public class GeometricObjectWrapper
    {
        private IGeometricObject geometricObject;

        private GeometricObjectWrapper(IGeometricObject geometricObject)
        {
            this.geometricObject = geometricObject;
        }

        public static GeometricObjectWrapper FromRaymapNormalGeometricObject(GeometricObject geo)
        {
            return new GeometricObjectWrapper(geo);
        }

        public static GeometricObjectWrapper FromRaymapNormalGeometricObjectInterface(IGeometricObject obj)
        {
            return new GeometricObjectWrapper(obj);
        }

        public IEnumerable<Vector3> vertices {
            get
            {
                if (geometricObject is GeometricObject)
                {
                    return (geometricObject as GeometricObject).vertices;
                } else
                {
                    throw new InvalidOperationException("IGeometricObject is not actual GeometricObject!");
                }
            }
        }

        public IEnumerable<Tuple<int, GeometricObjectElementWrapper>> IterateElements()
        {
            if (geometricObject is GeometricObject)
            {
                var actualGeometricObject = geometricObject as GeometricObject;
                int index = 0;
                foreach (var element in actualGeometricObject.elements)
                {
                    if (element is GeometricObjectElementTriangles)
                    {
                        yield return new Tuple<int, GeometricObjectElementWrapper>(
                            index, GeometricObjectElementWrapper.FromRaymapNormalGeometricObjectInterface(element));
                    }                    
                    index++;
                }
            } 
            else
            {
                throw new InvalidOperationException("IGeometricObject is not actual GeometricObject!");
            }
        }

        public Tuple<Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material>,
            Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>, Dictionary<string, Image>>
            GetMaterialsTexturesImages()
        {
            var resultList = new List<Tuple<Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material>,
            Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>, Dictionary<string, Image>>>();
            foreach (Tuple<int, GeometricObjectElementWrapper> elementInfo in IterateElements())
            {
                resultList.Add(elementInfo.Item2.GetMaterialsTexturesImages());
            }
            return MaterialsTexturesImagesModelUnifier.Unify(
                parts: resultList, verifyIdsUniqueContract: true);
        }
    }
}
