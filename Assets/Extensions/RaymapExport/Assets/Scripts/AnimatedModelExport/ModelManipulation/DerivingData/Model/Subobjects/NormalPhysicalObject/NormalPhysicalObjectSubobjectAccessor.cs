using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject.PartsWrappers.InterfaceWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.Converters;
using OpenSpace.Object;
using OpenSpace.ROM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.Subobjects.NormalPhysicalObject
{

    public class NormalPhysicalObjectSubobjectAccessor : SubobjectAccessor
    {
        private NormalPhysicalObjectWrapper physicalObject;
        private int objectNumber;

        public NormalPhysicalObjectSubobjectAccessor(int objectNumber, OpenSpace.Object.PhysicalObject physicalObject)
        {
            this.physicalObject = new NormalPhysicalObjectWrapper(physicalObject);
            this.objectNumber = objectNumber;
        }

        public override SubobjectModel GetSubobjectModel()
        {
            foreach (Tuple<int, IGeometricObjectWrapper> interfaceGeometricObject in physicalObject.IterateIGeometricObjects())
            {
                if (interfaceGeometricObject.Item2.IsGeometricObject())
                {
                    GeometricObjectWrapper geometricObject = interfaceGeometricObject.Item2.GetGeometricObject();
                    foreach (Tuple<int, IGeometricObjectElementWrapper> interfaceGeometricObjectElement
                        in geometricObject.IterateIGeometricObjectElements())
                    {
                        if (interfaceGeometricObjectElement.Item2.IsGeometricObjectElementTriangles())
                        {
                            GeometricObjectElementTrianglesWrapper geometricObjectElementTriangles =
                                interfaceGeometricObjectElement.Item2.GetGeometricObjectElementTriangles();
                            if (!geometricObjectElementTriangles.IsAlphaTransparencyObject())
                            {
                                return GetSubobjectModel(geometricObjectElementTriangles);
                            }
                        }
                    }
                }
            }
            throw new InvalidOperationException("This physical object does not contain " +
                "any legitimate data that can be turned into subobject model for export!");
        }

        private SubobjectModel GetSubobjectModel(GeometricObjectElementTrianglesWrapper geometricObjectElementTriangles)
        {
            return GeometricObjectElementTrianglesToSubobjectModelConverter.Convert(objectNumber, geometricObjectElementTriangles);
        }

        public override VisualData GetVisualData()
        {
            throw new NotImplementedException();
        }
    }
}
