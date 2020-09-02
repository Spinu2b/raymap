using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building
{
    public static class VisualDataHelper
    {
        public static Material GetOnlyPredictedObjectMaterial(VisualData visualData)
        {
            return visualData.materials.First().Value;
        }

        public static Texture2D GetOnlyPredictedObjectTexture(VisualData texture2DData)
        {
            return texture2DData.textures.First().Value;
        }
    }
}
