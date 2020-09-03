using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Model.Subobj.NormPo.Parts;
using Assets.Scripts.StandaloneAppCapacities.Export.Math;
using OpenSpace;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.RaymapModelFetch.NormGeoObjElTri
{
    public static class NormalGeometricObjectElementTrianglesGeometricDataFetcher
    {
        public static NormalGeometricObjectElementTrianglesGeometricData
            DeriveFor(GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            var result = new NormalGeometricObjectElementTrianglesGeometricData();
            uint triangle_size = 3 * (uint)(geometricObjectElementTriangles.backfaceCulling ? 1 : 2);
            if (geometricObjectElementTriangles.sdc != null)
            {
                result = GetGeometricDataFromSDC(geometricObjectElementTriangles);
                return result;
            }

            // Create mesh from unoptimized data
            if ((geometricObjectElementTriangles.sdc == null) && geometricObjectElementTriangles.num_triangles > 0)
            {
                Vector3d[] new_vertices = new Vector3d[geometricObjectElementTriangles.num_triangles * 3];
                Vector3d[] new_normals = new Vector3d[geometricObjectElementTriangles.num_triangles * 3];
                int[] unityTriangles = new int[geometricObjectElementTriangles.num_triangles * triangle_size];
                uint triangles_index = 0;
                for (int j = 0; j < geometricObjectElementTriangles.num_triangles; j++, triangles_index += triangle_size)
                {
                    int i0 = geometricObjectElementTriangles.triangles[(j * 3) + 0], m0 = (j * 3) + 0; // Old index, mapped index
                    int i1 = geometricObjectElementTriangles.triangles[(j * 3) + 1], m1 = (j * 3) + 1;
                    int i2 = geometricObjectElementTriangles.triangles[(j * 3) + 2], m2 = (j * 3) + 2;
                    new_vertices[m0] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.vertices[i0]);
                    new_vertices[m1] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.vertices[i1]);
                    new_vertices[m2] = Vector3d.FromUnityVector3(geometricObjectElementTriangles.geo.vertices[i2]);

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
                    unityTriangles[triangles_index + 0] = m0;
                    unityTriangles[triangles_index + 1] = m2;
                    unityTriangles[triangles_index + 2] = m1;
                    if (!geometricObjectElementTriangles.backfaceCulling)
                    {
                        unityTriangles[triangles_index + 3] = unityTriangles[triangles_index + 0];
                        unityTriangles[triangles_index + 4] = unityTriangles[triangles_index + 2];
                        unityTriangles[triangles_index + 5] = unityTriangles[triangles_index + 1];
                    }
                }
                result.vertices = new_vertices.ToList();
                result.normals = new_normals.ToList();
                result.triangles = unityTriangles.ToList();
                return result;
            }

            throw new InvalidOperationException("Did not manage to fetch geometric data properly for this Visual GeometricObjectElementTriangles!");
        }

        private static NormalGeometricObjectElementTrianglesGeometricData GetGeometricDataFromSDC(
            GeometricObjectElementTriangles geometricObjectElementTriangles)
        {
            var result = new NormalGeometricObjectElementTrianglesGeometricData();

            bool backfaceCulling = false;
            int triangle_size = 3 * (int)(backfaceCulling ? 1 : 2);
            if (geometricObjectElementTriangles.sdc.geo.Type == 4 ||
                geometricObjectElementTriangles.sdc.geo.Type == 5 ||
                geometricObjectElementTriangles.sdc.geo.Type == 6)
            {
                int[] triangles = new int[triangle_size * geometricObjectElementTriangles.sdc.geo.num_triangles[geometricObjectElementTriangles.sdc.index]];
                Vector3d[] vertices = new Vector3d[geometricObjectElementTriangles.sdc.num_vertices_actual];
                for (int i = 0; i < vertices.Length && i < geometricObjectElementTriangles.sdc.vertices.Length; i++)
                {
                    vertices[i] = new Vector3d(geometricObjectElementTriangles.sdc.vertices[i].x, geometricObjectElementTriangles.sdc.vertices[i].z,
                        geometricObjectElementTriangles.sdc.vertices[i].y);
                }
                Array.Resize(ref vertices, (int)geometricObjectElementTriangles.sdc.num_vertices_actual);
                result.vertices = vertices.ToList();
                Vector3d[] normals = null;
                int currentTriInStrip = 0;
                int triangleIndex = 0;
                for (int v = 2; (v < geometricObjectElementTriangles.sdc.num_vertices_actual && triangleIndex < triangles.Length); v++)
                {
                    if (geometricObjectElementTriangles.sdc.vertices[v].w == 1f)
                    {
                        if ((currentTriInStrip) % 2 == 0)
                        {
                            triangles[triangleIndex + 0] = v - 2;
                            triangles[triangleIndex + 1] = v - 1;
                            triangles[triangleIndex + 2] = v - 0;
                            if (!backfaceCulling)
                            {
                                triangles[triangleIndex + 3] = v - 1;
                                triangles[triangleIndex + 4] = v - 2;
                                triangles[triangleIndex + 5] = v - 0;
                            }
                        }
                        else
                        {
                            triangles[triangleIndex + 0] = v - 1;
                            triangles[triangleIndex + 1] = v - 2;
                            triangles[triangleIndex + 2] = v - 0;
                            if (!backfaceCulling)
                            {
                                triangles[triangleIndex + 3] = v - 2;
                                triangles[triangleIndex + 4] = v - 1;
                                triangles[triangleIndex + 5] = v - 0;
                            }
                        }
                        triangleIndex += triangle_size;
                        currentTriInStrip++;
                    }
                    else
                    {
                        currentTriInStrip = 0;
                    }
                }

                if (geometricObjectElementTriangles.sdc.geo.Type != 6)
                {
                    
                } else
                {

                }
            }

            throw new InvalidOperationException("Did not manage to fetch geometric data properly from SDC for this Visual GeometricObjectElementTriangles!");
        }
    }
}
