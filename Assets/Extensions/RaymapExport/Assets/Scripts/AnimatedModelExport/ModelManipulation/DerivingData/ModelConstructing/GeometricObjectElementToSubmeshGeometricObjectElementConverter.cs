using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.OpenSpace;
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
        public SubmeshGeometricObjectElement Convert(GeometricObjectElementWrapper geometricObjectElement, int geometricObjectElementIndex)
        {
            var result = new SubmeshGeometricObjectElement();
            result.id = GetSubmeshGeometricObjectElementId(geometricObjectElement, geometricObjectElementIndex);
            result.elementDescription.vertices = GetVertices(geometricObjectElement);
            result.elementDescription.normals = GetNormals(geometricObjectElement);
            result.elementDescription.triangles = GetTriangles(geometricObjectElement);
            result.elementDescription.uvMaps = GetUvMaps(geometricObjectElement);
            result.elementDescription.materials = GetMaterials(geometricObjectElement);

            result.elementDescription.bindBonePoses = GetBindBonePoses(geometricObjectElement);
            result.elementDescription.boneWeights = GetBoneWeights(geometricObjectElement);

            // for performance reasons - dirty, need to get rid of comparison contracts, they are not needed anymore
            // once the engine's structure for subobjects is better understood
            //result.elementDescriptionHash = result.elementDescription.ComputeHash();
            return result;
        }

        private Dictionary<int, Dictionary<int, float>> GetBoneWeights(GeometricObjectElementWrapper geometricObjectElement)
        {
            return geometricObjectElement.GetBoneWeights();
        }

        private Dictionary<int, BoneBindPose> GetBindBonePoses(GeometricObjectElementWrapper geometricObjectElement)
        {
            return geometricObjectElement.GetBindBonePoses();
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

        private int GetSubmeshGeometricObjectElementId(GeometricObjectElementWrapper geometricObjectElement, int geometricObjectElementIndex)
        {
            return geometricObjectElementIndex;
        }
    }
}
