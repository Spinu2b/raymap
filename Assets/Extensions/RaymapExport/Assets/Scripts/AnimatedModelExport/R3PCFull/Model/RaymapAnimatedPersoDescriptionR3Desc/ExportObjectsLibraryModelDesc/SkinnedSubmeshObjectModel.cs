using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc
{
    public class SkinnedSubmeshObjectModel
    {
        public string name;
        public TransformModel transform;
        public MeshGeometry meshGeometry;
        public Dictionary<string, BoneBindPose> bindBonePoses;
        public List<Material> materials;

        public HashSet<string> GetBonesNamesUsedForSkinningSet()
        {
            return new HashSet<string>(bindBonePoses.Select(x => x.Key).ToList());
        }

        public bool CompliantToWithMeshGeometryAndBindPoses(SkinnedSubmeshObjectModel other)
        {
            return meshGeometry.CompliantTo(other.meshGeometry) && CompliantWithBindPoses(other.bindBonePoses);
        }

        private bool CompliantWithBindPoses(Dictionary<string, BoneBindPose> otherBindBonePoses)
        {
            throw new NotImplementedException();
        }
    }
}
