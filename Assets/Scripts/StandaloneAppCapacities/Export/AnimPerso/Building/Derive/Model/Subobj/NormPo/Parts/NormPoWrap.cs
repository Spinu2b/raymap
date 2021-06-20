﻿using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts.IWrap;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts
{
    public class NormalPhysicalObjectWrapper
    {
        PhysicalObject physicalObject;

        public NormalPhysicalObjectWrapper(PhysicalObject physicalObject)
        {
            this.physicalObject = physicalObject;
        }

        public IEnumerable<Tuple<int, IGeometricObjectWrapper>> IterateIGeometricObjects()
        {
            int index = 0;
            foreach (var visualSetLOD in physicalObject.visualSet)
            {
                if (visualSetLOD.obj != null)
                {
                    yield return new Tuple<int, IGeometricObjectWrapper>(
                        index, new IGeometricObjectWrapper(visualSetLOD.obj));
                }
            }
        }

        public IEnumerable<Tuple<int, NormalGeometricObjectElementTrianglesWrapper>> IterateNormalGeometricObjectElementTriangles()
        {
            foreach (Tuple<int, IGeometricObjectWrapper> interfaceGeometricObject in IterateIGeometricObjects())
            {
                if (interfaceGeometricObject.Item2.IsNormalGeometricObject())
                {
                    NormalGeometricObjectWrapper geometricObject = interfaceGeometricObject.Item2.GetNormalGeometricObject();
                    foreach (Tuple<int, IGeometricObjectElementWrapper> interfaceGeometricObjectElement in
                        geometricObject.IterateIGeometricObjectElements())
                    {
                        if (interfaceGeometricObjectElement.Item2.IsNormalGeometricObjectElementTriangles())
                        {
                            NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTriangles =
                                interfaceGeometricObjectElement.Item2.GetNormalGeometricObjectElementTriangles();
                            yield return new Tuple<int, NormalGeometricObjectElementTrianglesWrapper>(interfaceGeometricObjectElement.Item1, 
                                geometricObjectElementTriangles);
                        }
                    }
                }
            }
        }

        public void RunWholeProperInitializationProcessWithMockedUnityApiInvocations()
        {
            physicalObject.RunWholeProperInitializationProcessForAnimationExportPurposesWithMockedUnityApiInvocations();
        }
    }
}