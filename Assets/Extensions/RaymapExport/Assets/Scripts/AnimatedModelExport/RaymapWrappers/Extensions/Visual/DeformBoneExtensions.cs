using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Visual.Deform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Extensions.Visual
{
    public static class DeformBoneExtensions
    {
        public static DeformBone ForExportClone(this DeformBone deformBone)
        {
            DeformBone b = (DeformBone)ObjectHelper.MemberwiseClone(deformBone);
            b.Reset();
            return b;
        }
    }
}
