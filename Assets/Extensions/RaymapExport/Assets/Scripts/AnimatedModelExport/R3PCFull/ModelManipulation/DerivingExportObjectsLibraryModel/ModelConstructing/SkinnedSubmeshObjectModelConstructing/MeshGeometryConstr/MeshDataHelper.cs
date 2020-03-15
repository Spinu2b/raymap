using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.MeshGeometryConstr
{
    public class MeshDataHelper
    {
        public static List<Tuple<int, int, int>> GetTrianglesList(int[] triangles)
        {
            var result = new List<Tuple<int, int, int>>();
            for (int i = 0; i < triangles.Length / 3; i++)
            {
                result.Add(
                    new Tuple<int, int, int>(triangles[i * 3], triangles[i * 3 + 1], triangles[i * 3 + 2])
                    );
            }
            return result;
        }

        public static List<Vector3d> GetNormals(Vector3[] normals)
        {
            throw new NotImplementedException();
        }

        public static List<List<Vector2d>> GetUvMaps(Mesh mesh)
        {
            throw new NotImplementedException();
        }
    }
}
