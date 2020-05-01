using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.RaymapModelFetching
{
    public static class NormalGeometricObjectElementTrianglesVisualDataFetcher
    {
        public static VisualData DeriveFor(OpenSpace.Visual.GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            if (geometricObjectElementTriangles.visualMaterial != null)
            {
                VisualMaterial.Hint materialHints = 
                    geometricObjectElementTriangles.geo.lookAtMode != 0 ? VisualMaterial.Hint.Billboard : VisualMaterial.Hint.None;

                return geometricObjectElementTriangles.visualMaterial.ForExportGetMaterial();
            } else
            {
                throw new InvalidOperationException("This geometric object element trinagles has null visual material!");
            }
        }
    }
}
