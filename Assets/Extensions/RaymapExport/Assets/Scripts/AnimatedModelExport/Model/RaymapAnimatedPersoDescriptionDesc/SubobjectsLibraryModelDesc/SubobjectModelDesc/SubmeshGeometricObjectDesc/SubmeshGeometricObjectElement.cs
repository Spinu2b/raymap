using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc
{
    public class SubmeshGeometricObjectElement
    {
        public int id;
        public List<Vector3d> vertices = new List<Vector3d>();
        public List<Vector3d> normals = new List<Vector3d>();
        public List<int> triangles = new List<int>();
        public List<List<Vector2d>> uvMaps = new List<List<Vector2d>>();
        public List<string> materials = new List<string>();

        public Dictionary<int, ChannelBindPose> bindChannelPoses = new Dictionary<int, ChannelBindPose>();
        public Dictionary<int, Dictionary<int, float>> channelWeights = new Dictionary<int, Dictionary<int, float>>();

        public bool EqualsToAnother(SubmeshGeometricObjectElement other)
        {
            Func<SubmeshGeometricObjectElement, bool> CompareVertices = (otherObj) =>
            {
                if (otherObj.vertices.Count != vertices.Count) { return false; }
                for (int i = 0; i < otherObj.vertices.Count; i++) {
                    var vertexA = vertices[i];
                    var vertexB = otherObj.vertices[i];
                    if (!vertexA.RoundEquals(vertexB))
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<SubmeshGeometricObjectElement, bool> CompareNormals = (otherObj) =>
            {
                if (otherObj.normals.Count != normals.Count) { return false; }
                for (int i = 0; i < otherObj.normals.Count; i++)
                {
                    var normalA = normals[i];
                    var normalB = otherObj.normals[i];
                    if (!normalA.RoundEquals(normalB))
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<SubmeshGeometricObjectElement, bool> CompareTriangles = (otherObj) =>
            {
                if (otherObj.triangles.Count != triangles.Count) { return false; }
                for (int i = 0; i < otherObj.triangles.Count; i++)
                {
                    var triangleVertexA = triangles[i];
                    var triangleVertexB = otherObj.triangles[i];
                    if (triangleVertexA != triangleVertexB)
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<SubmeshGeometricObjectElement, bool> CompareUvMaps = (otherObj) =>
            {
                if (otherObj.uvMaps.Count != uvMaps.Count) { return false; }
                for (int i = 0; i < otherObj.uvMaps.Count; i++)
                {
                    var uvMapA = uvMaps[i];
                    var uvMapB = otherObj.uvMaps[i];
                    if (uvMapA.Count != uvMapB.Count)
                    {
                        return false;
                    }

                    for (int j = 0; j < uvMapA.Count; j++)
                    {
                        var uvMapPointA = uvMapA[j];
                        var uvMapPointB = uvMapB[j];
                        if (!uvMapPointA.RoundEquals(uvMapPointB))
                        {
                            return false;
                        }
                    }
                }
                return true;
            };

            Func<SubmeshGeometricObjectElement, bool> CompareMaterials = (otherObj) =>
            {
                if (otherObj.materials.Count != materials.Count) { return false; }
                for (int i = 0; i < otherObj.materials.Count; i++)
                {
                    var materialA = materials[i];
                    var materialB = otherObj.materials[i];
                    if (!materialA.Equals(materialB))
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<SubmeshGeometricObjectElement, bool> CompareBindChannelPoses = (otherObj) =>
            {
                if (otherObj.bindChannelPoses.Count != bindChannelPoses.Count) { return false; }
                foreach (var bindPoseInfo in bindChannelPoses)
                {
                    var boneChannelNumber = bindPoseInfo.Key;
                    if (!otherObj.bindChannelPoses.ContainsKey(boneChannelNumber))
                    {
                        return false;
                    }
                    if (!bindChannelPoses[boneChannelNumber].RoundEquals(otherObj.bindChannelPoses[boneChannelNumber]))
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<SubmeshGeometricObjectElement, bool> CompareChannelWeights = (otherObj) =>
            {
                if (otherObj.channelWeights.Count != channelWeights.Count) { return false; }
                foreach (var channelWeightsInfo in channelWeights)
                {
                    var boneChannelNumber = channelWeightsInfo.Key;
                    if (!otherObj.channelWeights.ContainsKey(boneChannelNumber))
                    {
                        return false;
                    }
                    
                    var channelWeightsA = channelWeights[boneChannelNumber];
                    var channelWeightsB = otherObj.channelWeights[boneChannelNumber];

                    if (channelWeightsA.Count != channelWeightsB.Count)
                    {
                        return false;
                    }

                    foreach (var vertexWeightInfo in channelWeightsA)
                    {
                        var vertexNumber = vertexWeightInfo.Key;
                        if (!channelWeightsB.ContainsKey(vertexNumber))
                        {
                            return false;
                        }
                        if (!NumberUtils.RoundEquals(vertexWeightInfo.Value, channelWeightsB[vertexNumber]))
                        {
                            return false;
                        }
                    }
                }
                return true;
            };

            return (id == other.id) && CompareVertices(other) && CompareNormals(other) && CompareTriangles(other) && CompareUvMaps(other) && CompareMaterials(other) &&
                CompareBindChannelPoses(other) && CompareChannelWeights(other);
        }
    }
}
