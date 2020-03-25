using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.MathDescription;
using UnityEngine;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.ModelConstructing.SkinnedSubmeshObjectModelConstructing.MeshGeometryConstr
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
            return normals.Select(x => new Vector3d(x.x, x.y, x.z)).ToList();
        }

        public static List<List<Vector2d>> GetUvMaps(Mesh mesh)
        {
            var result = new List<List<Vector2d>>();
            result.Add(mesh.uv.Select(x => new Vector2d(x.x, x.y)).ToList());
            result.Add(mesh.uv2.Select(x => new Vector2d(x.x, x.y)).ToList());
            result.Add(mesh.uv3.Select(x => new Vector2d(x.x, x.y)).ToList());
            result.Add(mesh.uv4.Select(x => new Vector2d(x.x, x.y)).ToList());
            result.Add(mesh.uv5.Select(x => new Vector2d(x.x, x.y)).ToList());
            result.Add(mesh.uv6.Select(x => new Vector2d(x.x, x.y)).ToList());
            result.Add(mesh.uv7.Select(x => new Vector2d(x.x, x.y)).ToList());
            result.Add(mesh.uv8.Select(x => new Vector2d(x.x, x.y)).ToList());
            return result;
        }
    }
}
