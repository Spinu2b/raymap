using Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model.Subobj
{
    public class NormalPhysicalObjectSubobjectAccessor : SubobjectAccessor
    {
        private NormalPhysicalObjectWrapper physicalObject;
        private int objectNumber;

        public NormalPhysicalObjectSubobjectAccessor(int objectNumber, PhysicalObjectComponent physicalObject)
        {
            this.physicalObject = new NormalPhysicalObjectWrapper(physicalObject);
            this.objectNumber = objectNumber;
        }

        public override Subobject GetSubobjectModel()
        {
            foreach (Tuple<int, IGeometricObjectWrapper> interfaceGeometricObject in physicalObject.IterateIGeometricObjects())
            {
                if (interfaceGeometricObject.Item2.IsNormalGeometricObject())
                {
                    NormalGeometricObjectWrapper geometricObject = interfaceGeometricObject.Item2.GetNormalGeometricObject();
                    foreach (Tuple<int, IGeometricObjectElementWrapper> interfaceGeometricObjectElement in 
                        geometricObject.IterateIGeometricObjectElements())
                    {
                        if (interfaceGeometricObjectElement.Item2.IsNormalGeometricObjectElementTriangles())
                        {
                            NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTrianglesWrapper =
                                interfaceGeometricObjectElement.Item2.GetNormalGeometricObjectElementTriangles();
                            if (!geometricObjectElementTrianglesWrapper.IsAlphaTransparencyObject())
                            {
                                return GetSubobjectModel(geometricObjectElementTriangles);
                            }
                        }
                    }
                }
            }
        }

        public override VisualData GetVisualData()
        {
            throw new NotImplementedException();
        }
    }
}
