using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.RaymapModelFetching;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model.OpenSpace
{
    public enum GeometricObjectElementWrappingType
    {
        RAYMAP_NORMAL_GEOMETRIC_OBJECT_ELEMENT_INTERFACE
    }

    public class GeometricObjectElementWrapper
    {
        private IGeometricObjectElement geometricObjectElement;
        private GeometricObjectElementWrappingType wrappingType;

        private GeometricObjectWrapper geometricObject
        {
            get
            {
                if (geometricObjectElement is GeometricObjectElementTriangles)
                {
                    return GeometricObjectWrapper.FromRaymapNormalGeometricObject(
                        (geometricObjectElement as GeometricObjectElementTriangles).geo);
                } 
                else
                {
                    throw new InvalidOperationException("Geometric object element does not have parent of actual type GeometricObject!");
                }
            }
        }

        public GameObject gameObject { 
            get {
                if (geometricObjectElement is GeometricObjectElementTriangles)
                {
                    return geometricObjectElement.Gao;
                } 
                else
                {
                    throw new InvalidOperationException("Geometric object element is not GeometricObjectElementTriangles!");
                }
            }
        }

        public Mesh GetMesh()
        {
            if (gameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
            } 
            else if (gameObject.GetComponent<MeshFilter>() != null)
            {
                return gameObject.GetComponent<MeshFilter>().mesh;
            } else
            {
                throw new InvalidOperationException("Geometric object element game object seems to have no Unity component to actually contain Unity mesh data!");
            }
        }

        private GeometricObjectElementWrapper(IGeometricObjectElement geometricObjectElement,
            GeometricObjectElementWrappingType wrappingType)
        {
            this.geometricObjectElement = geometricObjectElement;
            this.wrappingType = wrappingType;
        }

        public static GeometricObjectElementWrapper FromRaymapNormalGeometricObjectElementInterface(
    IGeometricObjectElement element)
        {
            return new GeometricObjectElementWrapper(element,
                GeometricObjectElementWrappingType.RAYMAP_NORMAL_GEOMETRIC_OBJECT_ELEMENT_INTERFACE);
        }

        public Dictionary<int, Dictionary<int, float>> GetBoneWeights()
        {
            if (gameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return GetBoneWeightsForActualUnityBoneWeights(gameObject.GetComponent<SkinnedMeshRenderer>().bones, GetMesh().boneWeights);
            }  
            else
            {
                return new Dictionary<int, Dictionary<int, float>>();
            }
        }

        private Dictionary<int, Dictionary<int, float>> GetBoneWeightsForActualUnityBoneWeights(Transform[] bones, BoneWeight[] boneWeights)
        {
            var result = new Dictionary<int, Dictionary<int, float>>();

            for (int boneIndex = 0; boneIndex < bones.Length; boneIndex++)
            {
                result.Add(boneIndex, new Dictionary<int, float>());
                int vertexIndex = 0;
                foreach (var boneWeight in boneWeights)
                {
                    if (boneWeight.boneIndex0 == boneIndex)
                    {
                        result[boneIndex].Add(vertexIndex, boneWeight.weight0);
                    }
                    else if (boneWeight.boneIndex1 == boneIndex)
                    {
                        result[boneIndex].Add(vertexIndex, boneWeight.weight1);
                    }
                    else if (boneWeight.boneIndex2 == boneIndex)
                    {
                        result[boneIndex].Add(vertexIndex, boneWeight.weight2);
                    }
                    else if (boneWeight.boneIndex3 == boneIndex)
                    {
                        result[boneIndex].Add(vertexIndex, boneWeight.weight3);
                    }
                    vertexIndex++;
                }
                boneIndex++;
            }            

            return result;
        }

        private BoneBindPose GetBoneBindPoseFromBindposeMatrix(Matrix4x4 bindpose)
        {
            GameObject boneWorkingDuplicate = new GameObject();
            boneWorkingDuplicate.transform.SetParent(null);

            Matrix4x4 localMatrix = bindpose.inverse;
            boneWorkingDuplicate.transform.localPosition = localMatrix.MultiplyPoint(Vector3.zero);
            boneWorkingDuplicate.transform.localRotation = UnityEngine.Quaternion.LookRotation(localMatrix.GetColumn(2), localMatrix.GetColumn(1));
            boneWorkingDuplicate.transform.localScale =
                new Vector3(localMatrix.GetColumn(0).magnitude, localMatrix.GetColumn(1).magnitude, localMatrix.GetColumn(2).magnitude);

            var result = BoneBindPose.FromUnityAbsoluteTransform(boneWorkingDuplicate.transform);
            UnityEngine.Object.Destroy(boneWorkingDuplicate);
            return result;
        }

        private Dictionary<int, BoneBindPose> GetBoneBindPosesForActualUnityBindposes(Transform[] bones, Matrix4x4[] bindposes)
        {
            var result = new Dictionary<int, BoneBindPose>();
            for (int boneIndex = 0; boneIndex < bones.Length; boneIndex++)
            {
                result[boneIndex] = GetBoneBindPoseFromBindposeMatrix(bindposes[boneIndex]);
                boneIndex++;
            }
            return result;
        }

        public Dictionary<int, BoneBindPose> GetBindBonePoses()
        {
            if (gameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return GetBoneBindPosesForActualUnityBindposes(gameObject.GetComponent<SkinnedMeshRenderer>().bones, GetMesh().bindposes);
            } 
            else
            {
                return new Dictionary<int, BoneBindPose>();
            }
        }

        public List<Vector3d> GetVertices()
        {
            if (geometricObjectElement is GeometricObjectElementTriangles)
            {
                return GeometricObjectElementTrianglesVerticesFetcher.GetVerticesList(geometricObjectElement as GeometricObjectElementTriangles);
            } else
            {
                throw new NotImplementedException("Getting vertices list not implemented for other geometric object element kinds!");
            }            
        }

        public List<Vector3d> GetNormals()
        {
            return GetMesh().normals.Select(x => Vector3d.FromUnityVector3(x)).ToList();
        }

        public List<int> GetTriangles()
        {
            return GetMesh().triangles.Select(x => x).ToList();
        }

        public List<List<Vector2d>> GetUvMaps()
        {
            var result = new List<List<Vector2d>>();
            Mesh mesh = GetMesh();
            if (mesh.uv != null)
            {
                result.Add(mesh.uv.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            if (mesh.uv2 != null)
            {
                result.Add(mesh.uv2.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            if (mesh.uv3 != null)
            {
                result.Add(mesh.uv3.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            if (mesh.uv4 != null)
            {
                result.Add(mesh.uv4.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            if (mesh.uv5 != null)
            {
                result.Add(mesh.uv5.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            if (mesh.uv6 != null)
            {
                result.Add(mesh.uv6.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            if (mesh.uv7 != null)
            {
                result.Add(mesh.uv7.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            if (mesh.uv8 != null)
            {
                result.Add(mesh.uv8.Select(x => Vector2d.FromUnityVector2(x)).ToList());
            }
            return result;
        }

        public List<string> GetMaterials()
        {
            var visualData = UnityMaterialsToVisualDataConverter.Convert(GetMaterialsWithTextureNamesData());
            return visualData.materials.Select(x => x.Key).ToList();
        }

        public VisualData GetVisualData()
        {
            var visualData = UnityMaterialsToVisualDataConverter.Convert(GetMaterialsWithTextureNamesData());
            return visualData;
        }

        private List<Tuple<UnityEngine.Material, List<string>>> GetMaterialsWithTextureNamesData()
        {
            return SubmeshGameObjectMaterialsDataFetchingHelper.
                GetGouraudShaderedMaterialData(gameObject);
        }
    }
}
