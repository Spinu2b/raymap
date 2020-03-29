using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class GeometricObjectElementToSubmeshGeometricObjectElementConverter
    {
        public SubmeshGeometricObjectElement Convert(GeometricObjectElementWrapper geometricObjectElement, int channelId, int geometricObjectElementIndex)
        {
            var result = new SubmeshGeometricObjectElement();
            result.id = GetSubmeshGeometricObjectElementId(geometricObjectElement, channelId, geometricObjectElementIndex);
            result.vertices = GetVertices(geometricObjectElement);
            result.normals = GetNormals(geometricObjectElement);
            result.triangles = GetTriangles(geometricObjectElement);
            result.uvMaps = GetUvMaps(geometricObjectElement);
            result.materials = GetMaterials(geometricObjectElement);

            result.bindChannelPoses = GetBindChannelPoses(geometricObjectElement, channelId);
            result.channelWeights = GetChannelWeights(geometricObjectElement, channelId);
            return result;
        }

        private Dictionary<int, Dictionary<int, float>> GetChannelWeights(GeometricObjectElementWrapper geometricObjectElement, int channelId)
        {
            return geometricObjectElement.GetChannelWeights();
        }

        private Dictionary<int, ChannelBindPose> GetBindChannelPoses(GeometricObjectElementWrapper geometricObjectElement, int channelId)
        {
            return geometricObjectElement.GetBindChannelPoses();
        }

        private List<string> GetMaterials(GeometricObjectElementWrapper geometricObjectElement)
        {
            return geometricObjectElement.GetMaterials();
        }

        private List<List<Vector2d>> GetUvMaps(GeometricObjectElementWrapper geometricObjectElement)
        {
            return geometricObjectElement.GetUvMaps();
        }

        private List<int> GetTriangles(GeometricObjectElementWrapper geometricObjectElement)
        {
            return geometricObjectElement.GetTriangles();
        }

        private List<Vector3d> GetNormals(GeometricObjectElementWrapper geometricObjectElement)
        {
            return geometricObjectElement.GetNormals();
        }

        private List<Vector3d> GetVertices(GeometricObjectElementWrapper geometricObjectElement)
        {
            return geometricObjectElement.GetVertices();
        }

        private int GetSubmeshGeometricObjectElementId(GeometricObjectElementWrapper geometricObjectElement, int channelId, int geometricObjectElementIndex)
        {
            return geometricObjectElementIndex;
        }
    }
}
