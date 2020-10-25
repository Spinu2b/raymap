using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts.IWrap;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Conv;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using OpenSpace.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj
{
    public static class NormalPhysicalObjectTransparencyVisibilityNatureVerifier
    {
        public static bool IsCompletelyTransparentElementsAssociated(NormalPhysicalObjectWrapper physicalObject)
        {
            return physicalObject.IterateNormalGeometricObjectElementTriangles().All(x => x.Item2.IsAlphaTransparencyObject());
        }
    }

    public class NormalPhysicalObjectSubobjectAccessor : SubobjectAccessor
    {
        public NormalPhysicalObjectWrapper physicalObject { get; private set; }
        private int objectNumber;

        public NormalPhysicalObjectSubobjectAccessor(int objectNumber, PhysicalObject physicalObject)
        {
            this.physicalObject = new NormalPhysicalObjectWrapper(physicalObject);
            this.objectNumber = objectNumber;
        }

        public override Subobject GetSubobjectModel()
        {
            return GetSubobjectModelFromElementTriangles(GetOneExpectedRepresentativeElementTrianglesAsActualGeometricDataSource());
        }

        private NormalGeometricObjectElementTrianglesWrapper GetOneExpectedRepresentativeElementTrianglesAsActualGeometricDataSource()
        {
            if (!NormalPhysicalObjectTransparencyVisibilityNatureVerifier.IsCompletelyTransparentElementsAssociated(physicalObject))
            {
                return (
                    physicalObject.IterateNormalGeometricObjectElementTriangles().First(x => !x.Item2.IsAlphaTransparencyObject()).Item2);
            }
            else
            {
                return (physicalObject.IterateNormalGeometricObjectElementTriangles().First().Item2);
            }
            throw new InvalidOperationException("This physical object does not contain any " +
                "legitimate data that can be turned into subobject model for export!");
        }

        private Subobject GetSubobjectModelFromElementTriangles(NormalGeometricObjectElementTrianglesWrapper geometricObjectElementTriangles)
        {
            return NormalGeometricObjectElementTrianglesToSubobjectModelConverter.Convert(objectNumber, geometricObjectElementTriangles);
        }

        public override VisualData GetVisualData()
        {
            return GetOneExpectedRepresentativeElementTrianglesAsActualGeometricDataSource().GetVisualData();
        }

        public void RunWholeProperInitializationProcessWithMockedUnityApiInvocations()
        {
            physicalObject.RunWholeProperInitializationProcessWithMockedUnityApiInvocations();
        }
    }
}
