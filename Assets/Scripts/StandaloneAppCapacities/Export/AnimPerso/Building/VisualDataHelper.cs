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
            if (visualData.materials.Count == 1)
            {
                return visualData.materials.First().Value;
            } else
            {
                throw new InvalidOperationException("There is other than 1 amount of expected materials for this VisualData!");
            }                
        }

        public static Texture2D GetOnlyPredictedObjectTexture(VisualData texture2DData)
        {
            if (texture2DData.textures.Count == 1)
            {
                return texture2DData.textures.First().Value;
            }
            else
            {
                throw new InvalidOperationException("There is other than 1 amount of expected textures for this VisualData!");
            }            
        }
    }
}
