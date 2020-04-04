using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model
{
    public enum PhysicalObjectWrappingType
    {
        RAYMAP_NORMAL_PHYSICAL_OBJECT
    }

    public class PhysicalObjectWrapper
    {
        private PhysicalObject physicalObject;
        private PhysicalObjectWrappingType wrappingType;

        private PhysicalObjectWrapper(PhysicalObject physicalObject, PhysicalObjectWrappingType wrappingType)
        {
            this.physicalObject = physicalObject;
            this.wrappingType = wrappingType;
        }

        public static PhysicalObjectWrapper FromRaymapNormalPhysicalObject(PhysicalObject physicalObject)
        {
            return new PhysicalObjectWrapper(physicalObject, PhysicalObjectWrappingType.RAYMAP_NORMAL_PHYSICAL_OBJECT);
        }

        public IEnumerable<Tuple<int, GeometricObjectWrapper>> IterateGeometricObjects()
        {
            if (physicalObject != null)
            {
                int index = 0;
                foreach (var visualSetLOD in physicalObject.visualSet)
                {
                    yield return new Tuple<int, GeometricObjectWrapper>(index,
                        GeometricObjectWrapper.FromRaymapNormalGeometricObjectInterface(visualSetLOD.obj));
                    index++;
                }
            } else
            {
                throw new NotImplementedException("Not implemented handling of other physical objects!");
            }
        }

        public Tuple<Dictionary<string, Material>,
            Dictionary<string, Texture>, Dictionary<string, Image>>
            GetMaterialsTexturesImages()
        {
            var resultList = new List<Tuple<Dictionary<string, Material>,
            Dictionary<string, Texture>, Dictionary<string, Image>>>();
            foreach (Tuple<int, GeometricObjectWrapper> geometricObjectInfo in IterateGeometricObjects())
            {
                resultList.Add(geometricObjectInfo.Item2.GetMaterialsTexturesImages());
            }
            return MaterialsTexturesImagesModelUnifier.Unify(
                parts: resultList, verifyIdsUniqueContract: true);
        }
    }
}
