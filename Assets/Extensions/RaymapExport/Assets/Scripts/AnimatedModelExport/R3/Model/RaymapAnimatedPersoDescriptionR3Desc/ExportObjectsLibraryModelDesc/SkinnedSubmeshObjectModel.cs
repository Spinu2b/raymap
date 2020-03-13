using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc
{
    public class SkinnedSubmeshObjectModel
    {
        public string name;
        public TransformModel transform;
        public MeshGeometry meshGeometry;
        public Dictionary<string, BoneBindPose> bindBonePoses;
        public List<Material> materials;
    }
}
