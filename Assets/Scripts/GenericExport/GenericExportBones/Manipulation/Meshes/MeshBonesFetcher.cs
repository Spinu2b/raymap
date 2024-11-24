using Assets.Scripts.GenericExport.GenericExportBones.Model.DataBlocks;
using Assets.Scripts.GenericExport.Model.DataBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static PlasticGui.LaunchDiffParameters;

namespace Assets.Scripts.GenericExport.GenericExportBones.Manipulation.Meshes
{
    public static class MeshBonesFetcher
    {
        public static ExportBones GetBonesInfo(Transform node)
        {
            Mesh mesh = node.GetComponent<SkinnedMeshRenderer>() != null ?
               node.GetComponent<SkinnedMeshRenderer>().sharedMesh : node.GetComponent<MeshFilter>().mesh;
            SkinnedMeshRenderer skinnedMeshRenderer = node.GetComponent<SkinnedMeshRenderer>();

            List<Transform> bonesUsed = skinnedMeshRenderer != null ? skinnedMeshRenderer.bones.ToList() : new List<Transform>();

            var result = new ExportBones();

            result.bindposes = mesh.bindposes.Select(x => ObjectTransform.FromUnityMatrix4x4(x)).ToList();
            result.boneWeights = mesh.boneWeights.Select(x => ExportBoneWeight.FromUnityBoneWeight(x)).ToList();
            result.boneTransforms = bonesUsed.Select(x => ObjectTransform.FromUnityTransform(x)).ToList();

            return result;
        }
    }
}
