using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Visual.Deform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual
{
    public static class DeformVertexWeightsExtensions
    {
        public static DeformVertexWeights ForExportClone(this DeformVertexWeights deformVertexWeights)
        {
            DeformVertexWeights w = (DeformVertexWeights)ObjectHelper.MemberwiseClone(deformVertexWeights);
            w.Reset();
            return w;
        }
    }
}
