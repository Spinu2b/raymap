using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc
{
    public class MeshGeometry
    {
        public List<Vector3d> vertices;
        public List<Vector3d> normals;
        public List<Tuple<int, int, int>> triangles;
        public Dictionary<string, Dictionary<int, float>> bonesWeights;

        public List<List<Vector2d>> uvMaps;
    }
}
