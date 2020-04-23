using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Visual;
using OpenSpace.Visual.Deform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual
{
    public static class DeformSetCloner
    {
        public static IGeometricObjectElement ForExportClone(
            DeformSet geometricObjectElement, GeometricObject geometricObject)
        {
            DeformSet d = (DeformSet)ObjectHelper.MemberwiseClone(geometricObjectElement);
            d.Reset();
            d.mesh = geometricObject;
            d.r3bones = new DeformBone[geometricObjectElement.r3bones.Length];
            for (int i = 0; i < geometricObjectElement.r3bones.Length; i++)
            {
                d.r3bones[i] = geometricObjectElement.r3bones[i].ForExportClone();
            }
            d.r3weights = new DeformVertexWeights[geometricObjectElement.r3weights.Length];
            for (int i = 0; i < geometricObjectElement.r3weights.Length; i++)
            {
                d.r3weights[i] = geometricObjectElement.r3weights[i].ForExportClone();
            }
            return d;
        }
    }

    public static class GeometricObjectElementSpritesCloner
    {
        public static IGeometricObjectElement ForExportClone(
            GeometricObjectElementSprites geometricObjectElement, GeometricObject geometricObject)
        {
            GeometricObjectElementSprites sm = (GeometricObjectElementSprites)ObjectHelper.MemberwiseClone(geometricObjectElement);
            sm.geo = geometricObject;
            sm.Reset();
            return sm;
        }
    }

    public static class GeometricObjectElementTrianglesCloner
    {
        public static IGeometricObjectElement ForExportClone(
            GeometricObjectElementTriangles geometricObjectElement, GeometricObject geometricObject)
        {
            GeometricObjectElementTriangles sm = (GeometricObjectElementTriangles)ObjectHelper.MemberwiseClone(geometricObjectElement);
            sm.geo = geometricObject;
            sm.Reset();
            return sm;
        }
    }

    public static class IGeometricObjectElementExtensions
    {
        public static IGeometricObjectElement ForExportClone(this IGeometricObjectElement geometricObjectElement, 
            GeometricObject geometricObject)
        {
            if (geometricObjectElement is DeformSet)
            {
                return DeformSetCloner.ForExportClone((DeformSet)geometricObjectElement, geometricObject);
            }
            else if (geometricObjectElement is GeometricObjectElementSprites)
            {
                return GeometricObjectElementSpritesCloner.ForExportClone(
                    (GeometricObjectElementSprites)geometricObjectElement, geometricObject);
            }
            else if (geometricObjectElement is GeometricObjectElementTriangles)
            {
                return GeometricObjectElementTrianglesCloner.ForExportClone(
                    (GeometricObjectElementTriangles)geometricObjectElement, geometricObject);
            }
            else
            {
                throw new NotImplementedException("IGeometricObjectElement implementation unsupported for export cloning!");
            }
        }
    }
}
