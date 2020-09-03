using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using OpenSpace;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch.NormGeoObjElTri
{
    public static class NormalGeometricObjectElementTrianglesNormalsFetcher
    {
        public static List<Vector3d> DeriveFor(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            var result = new List<Vector3d>();
            uint triangle_size = 3 * (uint)(geometricObjectElementTriangles.backfaceCulling ? 1 : 2);
            if (geometricObjectElementTriangles.sdc != null)
            {
                result = GetNormalsFromSDC(geometricObjectElementTriangles);
                return result;
            }

            // Create mesh from unoptimized data
            if ((geometricObjectElementTriangles.sdc == null) && geometricObjectElementTriangles.num_triangles > 0)
            {
                Vector3d[] new_normals = new Vector3d[geometricObjectElementTriangles.num_triangles * 3];
                uint triangles_index = 0;
                for (int j = 0; j < geometricObjectElementTriangles.num_triangles; j++, triangles_index += triangle_size)
                {
                    int i0 = geometricObjectElementTriangles.triangles[(j * 3) + 0], m0 = (j * 3) + 0; // Old index, mapped index
                    int i1 = geometricObjectElementTriangles.triangles[(j * 3) + 1], m1 = (j * 3) + 1;
                    int i2 = geometricObjectElementTriangles.triangles[(j * 3) + 2], m2 = (j * 3) + 2;

                    if (geometricObjectElementTriangles.geo.normals != null)
                    {
                        new_normals[m0] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.normals[i0]);
                        new_normals[m1] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.normals[i1]);
                        new_normals[m2] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.normals[i2]);
                    }
                    if (MapLoader.Loader.blockyMode && geometricObjectElementTriangles.normals != null)
                    {
                        new_normals[m0] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.normals[j]);
                        new_normals[m1] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.normals[j]);
                        new_normals[m2] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.normals[j]);
                    }
                }
                result = new_normals.ToList();
                return result;
            }

            // Create mesh from optimized data
            long OPT_num_triangles_total = ((geometricObjectElementTriangles.OPT_num_triangleStrip > 2 ? 
                geometricObjectElementTriangles.OPT_num_triangleStrip - 2 : 0) + 
                geometricObjectElementTriangles.OPT_num_disconnectedTriangles) * (
                geometricObjectElementTriangles.backfaceCulling ? 1 : 2);
            if (geometricObjectElementTriangles.sdc == null && OPT_num_triangles_total > 0 &&
                geometricObjectElementTriangles.num_triangles <= 0)
            {
                Vector3d[] new_normals = new Vector3d[(geometricObjectElementTriangles.OPT_num_mapping_entries];
                for (int j = 0; j < geometricObjectElementTriangles.OPT_num_mapping_entries; j++)
                {
                    if (geometricObjectElementTriangles.geo.normals != null) new_normals[j] = 
                            Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.normals[geometricObjectElementTriangles.OPT_mapping_vertices[j]]);
                }
                if (geometricObjectElementTriangles.geo.normals != null) { 
                    result = new_normals.ToList();
                    return result;
                } else
                {
                    throw new InvalidOperationException("Could not fetch normals from this Visual GeometricObjectElementTriangles!");
                }
            }
            throw new InvalidOperationException("Did not succeed in fetching any normals from this Visual GeometricObjectElementTriangles!");
        }

        private static List<Vector3d> GetNormalsFromSDC(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            bool backfaceCulling = false;
            int triangle_size = 3 * (int)(backfaceCulling ? 1 : 2);
            if (geometricObjectElementTriangles.sdc.geo.Type == 4 ||
                geometricObjectElementTriangles.sdc.geo.Type == 5 ||
                geometricObjectElementTriangles.sdc.geo.Type == 6)
            {
                List<Vector3d> normals = null;

                if (geometricObjectElementTriangles.sdc.geo.Type != 6)
                {

                }
                else
                {
                    Vector3d[] calculatedNormals = null;
                    if (geometricObjectElementTriangles.sdc.normals == null && geometricObjectElementTriangles.geo.normals == null)
                    {
                        calculatedNormals = new Vector3d[geometricObjectElementTriangles.geo.num_vertices];
                        //MapLoader.Loader.print("sdc_el:" + sdc.offset + " - sdc_geo:" + sdc.geo.Offset + " - geo:" + geo.offset + " - el:" + offset);

                        // Calculate normals here
                        int triangles_index = 0;
                        for (int j = 0; j < geometricObjectElementTriangles.num_triangles; j++, triangles_index += 3)
                        {
                            int i0 = geometricObjectElementTriangles.triangles[(j * 3) + 0]; // Old index
                            int i1 = geometricObjectElementTriangles.triangles[(j * 3) + 1];
                            int i2 = geometricObjectElementTriangles.triangles[(j * 3) + 2];
                            Vector3 v0 = geometricObjectElementTriangles.geo.vertices[i0];
                            Vector3 v1 = geometricObjectElementTriangles.geo.vertices[i1];
                            Vector3 v2 = geometricObjectElementTriangles.geo.vertices[i2];
                            Vector3d calcNormal = Vector3d.FromUnityVector3(geometricObjectElementTriangles.ComputeNormalWeightedBySurf(v0, v1, v2));

                            calculatedNormals[i0] += calcNormal;
                            calculatedNormals[i1] += calcNormal;
                            calculatedNormals[i2] += calcNormal;
                        }

                    }
                    if (sdc.normals == null) normals = new Vector3[vertices.Length];
                }
            }
        }
    }
}
