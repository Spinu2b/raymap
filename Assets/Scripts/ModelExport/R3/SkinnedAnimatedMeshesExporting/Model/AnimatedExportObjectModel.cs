using ModelExport.MathDescription;
using ModelExport.R3.SkinnedAnimatedMeshesExporting.Model.AnimatedExportObjectModelDescription;
using ModelExport.R3.SkinnedAnimatedMeshesExporting.Model.AnimatedExportObjectModelDescription.MaterialsDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExport.R3.SkinnedAnimatedMeshesExporting.Model
{
    public class AnimatedExportObjectModel
    {
        public string Name;
        public TransformModel transform;
        public MeshGeometry meshGeometry;
        public Dictionary<string, BoneBindPose> bindBonePoses;
        public List<Material> materials;
        // Vertex morphs (R3): the object list index of the PO this mesh belongs to (the key of its weights in the
        // animation frames' morphWeights, "PO<index>"), and per target PO ("PO<index>") the offset of every moved
        // vertex, in the same space and vertex order as meshGeometry.vertices. Null when the mesh has no morphs.
        public int morphSourceObjectIndex = -1;
        public Dictionary<string, Dictionary<int, Vector3d>> morphTargets;
    }
}
