using System.Collections.Generic;
using ModelExport.MathDescription;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using OpenSpace.Object.Properties;
using OpenSpace.Visual;
using UnityEngine;

namespace ModelExport.R3.Morphs
{
    /// <summary>
    /// The vertex morph targets an exported R3 mesh can blend towards, as offsets per vertex of the Unity mesh (the
    /// same vertex order and space as the exported mesh geometry). R3 morphs a channel's PO towards other POs of the
    /// Perso's object list: a full mesh (GeometricObject) or a patch adding offsets to some vertices
    /// (PatchGeometricObject). The offsets are taken through Raymap's own GeometricObjectElementTriangles.
    /// UpdateMeshVertices, so they follow its vertex mapping exactly; the mesh is reset to its base afterwards.
    /// </summary>
    public class R3MorphTargetsExtractor
    {
        private const float MinimalOffset = 1e-7f;

        public class Result
        {
            public int sourceObjectIndex = -1;
            public Dictionary<string, Dictionary<int, Vector3d>> targets = new Dictionary<string, Dictionary<int, Vector3d>>();
        }

        public Result Extract(ExportableModel exportableModel)
        {
            var result = new Result();
            PersoBehaviour persoBehaviour = exportableModel.GetComponentInParent<PersoBehaviour>();
            if (persoBehaviour == null || persoBehaviour.perso == null || persoBehaviour.perso.p3dData == null) return result;
            ObjectList objectList = persoBehaviour.perso.p3dData.objectList;
            if (objectList == null) return result;

            int visualSetIndex;
            GeometricObjectElementTriangles element = FindSceneElement(persoBehaviour, exportableModel, out visualSetIndex);
            if (element == null) return result;
            result.sourceObjectIndex = FindObjectListIndex(objectList, element.name, visualSetIndex);
            if (result.sourceObjectIndex < 0) return result;

            Mesh mesh = MeshOf(exportableModel);
            Vector3[] baseGeometryVertices = element.geo.vertices;
            element.UpdateMeshVertices(baseGeometryVertices);
            Vector3[] baseMeshVertices = mesh.vertices;
            try
            {
                foreach (int targetIndex in CollectTargetObjectIndices(persoBehaviour, result.sourceObjectIndex))
                {
                    Vector3[] targetGeometryVertices = TargetGeometryVertices(objectList, targetIndex, visualSetIndex, baseGeometryVertices);
                    if (targetGeometryVertices == null) continue;
                    element.UpdateMeshVertices(targetGeometryVertices);
                    Vector3[] targetMeshVertices = mesh.vertices;
                    var offsets = new Dictionary<int, Vector3d>();
                    for (int i = 0; i < baseMeshVertices.Length && i < targetMeshVertices.Length; i++)
                    {
                        Vector3 offset = targetMeshVertices[i] - baseMeshVertices[i];
                        if (offset.sqrMagnitude > MinimalOffset * MinimalOffset) offsets[i] = new Vector3d(offset.x, offset.y, offset.z);
                    }
                    if (offsets.Count > 0) result.targets[R3MorphWeightsCalculator.ObjectKey(targetIndex)] = offsets;
                }
            }
            finally
            {
                element.UpdateMeshVertices(baseGeometryVertices);
            }
            return result;
        }

        private static Mesh MeshOf(ExportableModel exportableModel)
        {
            var skinned = exportableModel.GetComponent<SkinnedMeshRenderer>();
            if (skinned != null) return skinned.sharedMesh;
            var filter = exportableModel.GetComponent<MeshFilter>();
            return filter != null ? filter.sharedMesh : null;
        }

        private static GeometricObjectElementTriangles FindSceneElement(
            PersoBehaviour persoBehaviour, ExportableModel exportableModel, out int visualSetIndex)
        {
            visualSetIndex = -1;
            if (persoBehaviour.subObjects == null) return null;
            foreach (PhysicalObject[] channelObjects in persoBehaviour.subObjects)
            {
                if (channelObjects == null) continue;
                foreach (PhysicalObject po in channelObjects)
                {
                    if (po == null || po.visualSet == null) continue;
                    for (int v = 0; v < po.visualSet.Length; v++)
                    {
                        var geometricObject = po.visualSet[v].obj as GeometricObject;
                        if (geometricObject == null || geometricObject.elements == null) continue;
                        foreach (IGeometricObjectElement candidate in geometricObject.elements)
                        {
                            var element = candidate as GeometricObjectElementTriangles;
                            if (element == null || element.name != exportableModel.gameObject.name) continue;
                            Transform elementTransform = element.Gao.transform;
                            if (exportableModel.transform == elementTransform || exportableModel.transform.IsChildOf(elementTransform))
                            {
                                visualSetIndex = v;
                                return element;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private static int FindObjectListIndex(ObjectList objectList, string elementName, int visualSetIndex)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                PhysicalObject po = objectList[i].po;
                if (po == null || po.visualSet == null || visualSetIndex >= po.visualSet.Length) continue;
                var geometricObject = po.visualSet[visualSetIndex].obj as GeometricObject;
                if (geometricObject == null || geometricObject.elements == null) continue;
                foreach (IGeometricObjectElement candidate in geometricObject.elements)
                {
                    var element = candidate as GeometricObjectElementTriangles;
                    if (element != null && element.name == elementName) return i;
                }
            }
            return -1;
        }

        private static IEnumerable<int> CollectTargetObjectIndices(PersoBehaviour persoBehaviour, int sourceObjectIndex)
        {
            var found = new SortedSet<int>();
            var family = persoBehaviour.perso.p3dData.family;
            var loader = OpenSpace.MapLoader.Loader;
            if (family == null || loader.animationBanks == null || family.animBank >= loader.animationBanks.Length) return found;
            var bank = loader.animationBanks[family.animBank];
            if (bank == null || bank.animations == null) return found;
            foreach (var state in family.states)
            {
                if (state == null || state.anim_ref == null || state.anim_ref.anim_index >= bank.animations.Length) continue;
                AnimA3DGeneral a3d = bank.animations[state.anim_ref.anim_index];
                if (a3d == null || a3d.num_morphData == 0 || a3d.morphData == null) continue;
                var calculator = new R3MorphWeightsCalculator(a3d, persoBehaviour.perso.p3dData.objectList);
                for (int i = 0; i < a3d.num_morphData; i++)
                {
                    AnimMorphData m = a3d.morphData[a3d.start_morphData + i];
                    if (m == null || m.frame >= a3d.num_onlyFrames) continue;
                    if (calculator.SourceObjectIndexOfChannelAtFrame(m.channel, m.frame) != sourceObjectIndex) continue;
                    int count = System.Math.Max(1, (int)m.numMorphs);
                    for (int k = 0; k < count; k++) found.Add(m.objectIndexToArray != null ? m.objectIndexToArray[k] : m.objectIndexTo);
                }
            }
            return found;
        }

        private static Vector3[] TargetGeometryVertices(ObjectList objectList, int targetIndex, int visualSetIndex, Vector3[] baseVertices)
        {
            if (targetIndex < 0 || targetIndex >= objectList.Count) return null;
            PhysicalObject po = objectList[targetIndex].po;
            if (po == null || po.visualSet == null || visualSetIndex >= po.visualSet.Length) return null;
            switch (po.visualSet[visualSetIndex].obj)
            {
                case GeometricObject full:
                    if (full.vertices == null || full.vertices.Length != baseVertices.Length) return null;
                    return full.vertices;
                case PatchGeometricObject patch:
                    var result = (Vector3[])baseVertices.Clone();
                    for (int i = 0; i < patch.num_properties; i++)
                    {
                        int vertexIndex = patch.properties[i].ind_vertex;
                        if (vertexIndex < result.Length) result[vertexIndex] += patch.properties[i].pos;
                    }
                    return result;
                default:
                    return null;
            }
        }
    }
}
