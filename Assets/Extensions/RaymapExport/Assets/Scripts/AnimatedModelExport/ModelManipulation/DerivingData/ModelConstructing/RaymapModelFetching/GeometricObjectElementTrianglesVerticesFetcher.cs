using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.RaymapModelFetching
{
    public class GeometricObjectElementTrianglesVerticesFetcher
    {
        public static List<Vector3d> GetVerticesList(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            if ((geometricObjectElementTriangles.sdc == null) && geometricObjectElementTriangles.num_triangles > 0)
            {
                return GetVerticesFromUnoptimizedData(geometricObjectElementTriangles);
            }
            long OPT_num_triangles_total = ((
                geometricObjectElementTriangles.OPT_num_triangleStrip > 2 ? 
                geometricObjectElementTriangles.OPT_num_triangleStrip - 2 : 0) +
                geometricObjectElementTriangles.OPT_num_disconnectedTriangles) * 
                (geometricObjectElementTriangles.backfaceCulling ? 1 : 2);
            if (geometricObjectElementTriangles.sdc == null && OPT_num_triangles_total > 0 && geometricObjectElementTriangles.num_triangles <= 0)
            {
                return GetVerticesFromOptimizedData(geometricObjectElementTriangles);
            } else
            {
                throw new InvalidOperationException("Unable to fetch vertices data from normal GeometricObjectElementTriangles!");
            }
        }

        private static List<Vector3d> GetVerticesFromUnoptimizedData(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            Vector3[] new_vertices = new Vector3[geometricObjectElementTriangles.num_triangles * 3];
            uint triangles_index = 0;
            uint triangle_size = 3 * (uint)(geometricObjectElementTriangles.backfaceCulling ? 1 : 2);
            for (int j = 0; j < geometricObjectElementTriangles.num_triangles; j++, triangles_index += triangle_size)
            {
                int i0 = geometricObjectElementTriangles.triangles[(j * 3) + 0], m0 = (j * 3) + 0; // Old index, mapped index
                int i1 = geometricObjectElementTriangles.triangles[(j * 3) + 1], m1 = (j * 3) + 1;
                int i2 = geometricObjectElementTriangles.triangles[(j * 3) + 2], m2 = (j * 3) + 2;
                new_vertices[m0] = geometricObjectElementTriangles.geo.vertices[i0];
                new_vertices[m1] = geometricObjectElementTriangles.geo.vertices[i1];
                new_vertices[m2] = geometricObjectElementTriangles.geo.vertices[i2];
            }
            return new_vertices.Select(x => Vector3d.FromUnityVector3(x)).ToList();
        }

        private static List<Vector3d> GetVerticesFromOptimizedData(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            Vector3[] new_vertices = new Vector3[geometricObjectElementTriangles.OPT_num_mapping_entries];

            for (int j = 0; j < geometricObjectElementTriangles.OPT_num_mapping_entries; j++)
            {
                new_vertices[j] = geometricObjectElementTriangles.geo.vertices[geometricObjectElementTriangles.OPT_mapping_vertices[j]];
            }
            return new_vertices.Select(x => Vector3d.FromUnityVector3(x)).ToList();
        }
    }
}
