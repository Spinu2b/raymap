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

        public GeometricObjectWrapper(IGeometricObject geometricObject)
        {
            this.geometricObject = geometricObject;
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
                        yield return new Tuple<int, GeometricObjectElementWrapper>(index, new GeometricObjectElementWrapper(element));
                    }                    
                    index++;
                }
            } 
            else
            {
                throw new InvalidOperationException("IGeometricObject is not actual GeometricObject!");
            }
        }
    }
}
