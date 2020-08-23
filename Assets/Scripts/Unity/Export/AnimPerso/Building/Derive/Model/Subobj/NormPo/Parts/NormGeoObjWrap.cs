using Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts.IWrap;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts
{
    public class NormalGeometricObjectWrapper
    {
        private GeometricObject geometricObject;

        public NormalGeometricObjectWrapper(GeometricObject geometricObject)
        {
            this.geometricObject = geometricObject;
        }

        public IEnumerable<Tuple<int, IGeometricObjectElementWrapper>> IterateIGeometricObjectElements()
        {
            int index = 0;
            foreach (var geometricObjectElement in geometricObject.elements)
            {
                if (geometricObjectElement != null)
                {
                    yield return new Tuple<int, IGeometricObjectElementWrapper>(index, new IGeometricObjectElementWrapper(geometricObjectElement));
                }
                index++;
            }
        }
    }
}
