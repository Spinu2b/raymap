using Assets.Scripts.GenericExport.Manipulation.Meshes;
using Assets.Scripts.GenericExport.GenericExportBones.Manipulation.Meshes;
using Assets.Scripts.GenericExport.Model.DataBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GenericExport.GenericExportBones.Model.DataBlocks
{
    public class ConcreteWholePotentiallySkinnedSubmeshInPoseDataBlock : BonesDataBlock
    {
        public ObjectTransform transform;
        public List<ExportVector3> vertices = new List<ExportVector3>();
        public List<ExportVector3> normals = new List<ExportVector3>();
        public List<int> triangles = new List<int>();
        public ExportUVMap uvMap = new ExportUVMap();
        public ExportTexture texture = new ExportTexture();
        public ExportBones bones = new ExportBones();

        public ConcreteWholePotentiallySkinnedSubmeshInPoseDataBlock(
            ObjectTransform transform,
            List<ExportVector3> vertices,
            List<int> triangles,
            List<ExportVector3> normals,
            ExportUVMap uvMap,
            ExportTexture texture,
            ExportBones bones)
        {
            this.transform = transform;
            this.vertices = vertices;
            this.triangles = triangles;
            this.uvMap = uvMap;
            this.texture = texture;
            this.normals = normals;
            this.bones = bones;
        }

        public static ConcreteWholePotentiallySkinnedSubmeshInPoseDataBlock FromSubmesh(Transform child)
        {
            Mesh mesh = child.GetComponent<SkinnedMeshRenderer>() != null ?
                child.GetComponent<SkinnedMeshRenderer>().sharedMesh : child.GetComponent<MeshFilter>().mesh;
            ExportTexture texture = MeshTextureFetcher.GetTexture(child);
            ExportUVMap uvMap = MeshUVMapFetcher.GetUVMap(mesh);
            ExportBones bones = MeshBonesFetcher.GetBonesInfo(child);

            return new ConcreteWholePotentiallySkinnedSubmeshInPoseDataBlock(
                transform: new ObjectTransform(
                    position: ExportVector3.FromVector3(child.position),
                    rotation: ExportQuaternion.FromQuaternion(child.rotation),
                    scale: ExportVector3.FromVector3(child.lossyScale)
                    ),
                vertices: mesh.vertices.Select(x => new ExportVector3(x.x, x.y, x.z)).ToList(),
                triangles: mesh.triangles.ToList(),
                normals: mesh.normals.Select(x => new ExportVector3(x.x, x.y, x.z)).ToList(),
                uvMap: uvMap,
                texture: texture,
                bones: bones
            );
        }
    }
}
