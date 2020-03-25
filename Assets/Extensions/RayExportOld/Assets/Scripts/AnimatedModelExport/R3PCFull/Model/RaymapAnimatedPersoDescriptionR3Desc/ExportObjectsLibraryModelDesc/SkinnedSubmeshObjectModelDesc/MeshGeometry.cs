using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.MathDescription;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc
{
    public class MeshGeometry
    {
        public List<Vector3d> vertices;
        public List<Vector3d> normals;
        public List<Tuple<int, int, int>> triangles;
        public Dictionary<string, Dictionary<int, float>> bonesWeights;

        public List<List<Vector2d>> uvMaps;

        public bool CompliantTo(MeshGeometry otherMeshGeometry)
        {
            return CompliantWithVertices(otherMeshGeometry.vertices) &&
                CompliantWithNormals(otherMeshGeometry.normals) &&
                CompliantWithTriangles(otherMeshGeometry.triangles) &&
                CompliantWithBonesWeights(otherMeshGeometry.bonesWeights);
        }

        private bool CompliantWithBonesWeights(Dictionary<string, Dictionary<int, float>> otherBonesWeights)
        {
            throw new NotImplementedException();
        }

        private bool CompliantWithTriangles(List<Tuple<int, int, int>> otherTriangles)
        {
            throw new NotImplementedException();
        }

        private bool CompliantWithNormals(List<Vector3d> otherNormals)
        {
            throw new NotImplementedException();
        }

        private bool CompliantWithVertices(List<Vector3d> otherVertices)
        {
            throw new NotImplementedException();
        }
    }
}
