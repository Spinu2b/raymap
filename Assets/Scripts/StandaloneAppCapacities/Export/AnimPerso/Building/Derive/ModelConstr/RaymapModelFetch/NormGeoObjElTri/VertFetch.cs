using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch.NormGeoObjElTri
{
    public static class NormalGeometricObjectElementTrianglesVerticesFetcher
    {
        public static List<Vector3d> DeriveFor(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            var result = new List<Vector3d>();
            uint triangle_size = 3 * (uint)(geometricObjectElementTriangles.backfaceCulling ? 1 : 2);
            if (geometricObjectElementTriangles.sdc != null)
            {
                result = GetVerticesFromSDC(geometricObjectElementTriangles);
                return result;
            }
            // Create mesh from unoptimized data
            if ((geometricObjectElementTriangles.sdc == null) && geometricObjectElementTriangles.num_triangles > 0)
            {
                Vector3d[] new_vertices = new Vector3d[geometricObjectElementTriangles.num_triangles * 3];

                uint triangles_index = 0;
                for (int j = 0; j < geometricObjectElementTriangles.num_triangles; j++, triangles_index += triangle_size)
                {
                    int i0 = geometricObjectElementTriangles.triangles[(j * 3) + 0], m0 = (j * 3) + 0; // Old index, mapped index
                    int i1 = geometricObjectElementTriangles.triangles[(j * 3) + 1], m1 = (j * 3) + 1;
                    int i2 = geometricObjectElementTriangles.triangles[(j * 3) + 2], m2 = (j * 3) + 2;
                    new_vertices[m0] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.vertices[i0]);
                    new_vertices[m1] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.vertices[i1]);
                    new_vertices[m2] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.vertices[i2]);
                }
                result = new_vertices.ToList();
                return result;
            }
            // Create mesh from optimized data
            long OPT_num_triangles_total = 
                ((geometricObjectElementTriangles.OPT_num_triangleStrip > 2 ?
                geometricObjectElementTriangles.OPT_num_triangleStrip - 2 : 0) + 
                geometricObjectElementTriangles.OPT_num_disconnectedTriangles) * (geometricObjectElementTriangles.backfaceCulling ? 1 : 2);

            if (geometricObjectElementTriangles.sdc == null && OPT_num_triangles_total > 0 && geometricObjectElementTriangles.num_triangles <= 0)
            {
                Vector3d[] new_vertices = new Vector3d[geometricObjectElementTriangles.OPT_num_mapping_entries];
                for (int j = 0; j < geometricObjectElementTriangles.OPT_num_mapping_entries; j++)
                {
                    new_vertices[j] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.vertices[geometricObjectElementTriangles.OPT_mapping_vertices[j]]);
                }
                result = new_vertices.ToList();
                return result;
            }

            throw new InvalidOperationException("Did not succeed in fetching any vertices for this Visual GeometricObjectElementTriangles!");
        }

        private static List<Vector3d> GetVerticesFromSDC(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            var result = new List<Vector3d>();
            if (geometricObjectElementTriangles.sdc.geo.Type == 4 ||
                geometricObjectElementTriangles.sdc.geo.Type == 5 ||
                geometricObjectElementTriangles.sdc.geo.Type == 6)
            {
                Vector3d[] vertices = new Vector3d[geometricObjectElementTriangles.sdc.num_vertices_actual];
                for (int i = 0; i < vertices.Length && i < geometricObjectElementTriangles.sdc.vertices.Length; i++)
                {
                    vertices[i] = new Vector3d(geometricObjectElementTriangles.sdc.vertices[i].x,
                        geometricObjectElementTriangles.sdc.vertices[i].z,
                        geometricObjectElementTriangles.sdc.vertices[i].y);
                }
                Array.Resize(ref vertices, (int)geometricObjectElementTriangles.sdc.num_vertices_actual);
                result = vertices.ToList();
                return result;
            }

            throw new InvalidOperationException("Did not succeed in fetching any vertices from SDC for this Visual GeometricObjectElementTriangles!");
        }
    }
}
