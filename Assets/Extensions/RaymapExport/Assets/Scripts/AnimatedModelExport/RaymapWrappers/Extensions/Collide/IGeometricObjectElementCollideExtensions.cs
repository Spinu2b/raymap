using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.UnityWrappers;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Collide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Collide
{
    public static class GeometricObjectElementCollideAlignedBoxesCloner
    {
        public static IGeometricObjectElementCollide ForExportClone(
            GeometricObjectElementCollideAlignedBoxes geometricObjectElementCollide,
            GeometricObjectCollide geometricObjectCollide)
        {
            GeometricObjectElementCollideAlignedBoxes sm = (GeometricObjectElementCollideAlignedBoxes)ObjectHelper.MemberwiseClone(geometricObjectElementCollide);
            sm.geo = geometricObjectCollide;
            sm.Reset();
            return sm;
        }
    }

    public static class GeometricObjectElementCollideSpheresCloner
    {
        public static IGeometricObjectElementCollide ForExportClone(
            GeometricObjectElementCollideSpheres geometricObjectElementCollide,
            GeometricObjectCollide geometricObjectCollide)
        {
            GeometricObjectElementCollideSpheres sm = (GeometricObjectElementCollideSpheres)ObjectHelper.MemberwiseClone(geometricObjectElementCollide);
            sm.geo = geometricObjectCollide;
            sm.Reset();
            return sm;
        }
    }

    public static class GeometricObjectElementCollideTrianglesCloner
    {
        public static IGeometricObjectElementCollide ForExportClone(
            GeometricObjectElementCollideTriangles geometricObjectElementCollide,
            GeometricObjectCollide geometricObjectCollide)
        {
            GeometricObjectElementCollideTriangles sm = (GeometricObjectElementCollideTriangles)ObjectHelper.MemberwiseClone(geometricObjectElementCollide);
            sm.geo = geometricObjectCollide;
            sm.Reset();
            return sm;
        }
    }

    public static class IGeometricObjectElementCollideExtensions
    {
        public static IGeometricObjectElementCollide ForExportClone(
            this IGeometricObjectElementCollide geometricObjectElementCollide, GeometricObjectCollide geometricObjectCollide)
        {
            if (geometricObjectElementCollide is GeometricObjectElementCollideAlignedBoxes)
            {
                return GeometricObjectElementCollideAlignedBoxesCloner.ForExportClone(
                    (GeometricObjectElementCollideAlignedBoxes)geometricObjectElementCollide, geometricObjectCollide);
            }
            else if (geometricObjectElementCollide is GeometricObjectElementCollideSpheres)
            {
                return GeometricObjectElementCollideSpheresCloner.ForExportClone(
                    (GeometricObjectElementCollideSpheres)geometricObjectElementCollide, geometricObjectCollide);
            }
            else if (geometricObjectElementCollide is GeometricObjectElementCollideTriangles)
            {
                return GeometricObjectElementCollideTrianglesCloner.ForExportClone(
                    (GeometricObjectElementCollideTriangles)geometricObjectElementCollide, geometricObjectCollide);
            }
            else
            {
                throw new NotImplementedException("IGeometricObjectElementCollide implementation unsupported for export cloning!");
            }
        }

        public static ActualManifestableUnityGameObject GetRaymapExportGao(this IGeometricObjectElementCollide geometricObjectElementCollide)
        {
            return new ActualManifestableUnityGameObject();
        }
    }
}
