using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model
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

        private GameObject gameObject { 
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

        private Mesh GetMesh()
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

        public Dictionary<int, Dictionary<int, float>> GetChannelWeights()
        {
            if (gameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return GetChannelWeightsForActualUnityBoneWeights(gameObject.GetComponent<SkinnedMeshRenderer>().bones, GetMesh().boneWeights);
            }  
            else
            {
                return GetChannelFullVerticesWeightsForOnlyParentChannel();
            }
        }

        private Dictionary<int, Dictionary<int, float>> GetChannelFullVerticesWeightsForOnlyParentChannel()
        {
            var parentChannelId = ChannelHelper.GetChannelId(GetCorrespondingChannelGameObjectForGameObjectInHierarchy(gameObject).name);
            var result = new Dictionary<int, Dictionary<int, float>>();
            result[parentChannelId] = new Dictionary<int, float>();
            int verticesLength = GetVertices().Count;
            for (int i = 0; i < verticesLength; i++)
            {
                result[parentChannelId][i] = 1.0f;
            }
            return result;
        }

        private Dictionary<int, Dictionary<int, float>> GetChannelWeightsForActualUnityBoneWeights(Transform[] bones, BoneWeight[] boneWeights)
        {
            List<int> channelIds = bones.Select(x => ChannelHelper.GetChannelId(GetCorrespondingChannelGameObjectForGameObjectInHierarchy(x.gameObject).name)).ToList();
            var result = new Dictionary<int, Dictionary<int, float>>();

            int boneIndex = 0;
            foreach (var channelId in channelIds)
            {
                result.Add(channelId, new Dictionary<int, float>());
                int vertexIndex = 0;
                foreach (var boneWeight in boneWeights)
                {
                    if (boneWeight.boneIndex0 == boneIndex)
                    {
                        result[channelId].Add(vertexIndex, boneWeight.weight0);
                    }
                    else if (boneWeight.boneIndex1 == boneIndex)
                    {
                        result[channelId].Add(vertexIndex, boneWeight.weight1);
                    }
                    else if (boneWeight.boneIndex2 == boneIndex)
                    {
                        result[channelId].Add(vertexIndex, boneWeight.weight2);
                    }
                    else if (boneWeight.boneIndex3 == boneIndex)
                    {
                        result[channelId].Add(vertexIndex, boneWeight.weight3);
                    }
                    vertexIndex++;
                }
                boneIndex++;
            }            

            return result;
        }

        private Dictionary<int, ChannelBindPose> GetChannelBindPoseForParentChannel()
        {
            var parentChannelId = ChannelHelper.GetChannelId(GetCorrespondingChannelGameObjectForGameObjectInHierarchy(gameObject).name);
            var result = new Dictionary<int, ChannelBindPose>();
            result[parentChannelId] = ChannelBindPose.HomeTransform();
            return result;
        }

        private ChannelBindPose GetChannelBindPoseFromBindposeMatrix(Matrix4x4 bindpose)
        {
            GameObject boneWorkingDuplicate = new GameObject();
            boneWorkingDuplicate.transform.SetParent(null);

            Matrix4x4 localMatrix = bindpose.inverse;
            boneWorkingDuplicate.transform.localPosition = localMatrix.MultiplyPoint(Vector3.zero);
            boneWorkingDuplicate.transform.localRotation = UnityEngine.Quaternion.LookRotation(localMatrix.GetColumn(2), localMatrix.GetColumn(1));
            boneWorkingDuplicate.transform.localScale =
                new Vector3(localMatrix.GetColumn(0).magnitude, localMatrix.GetColumn(1).magnitude, localMatrix.GetColumn(2).magnitude);

            var result = ChannelBindPose.FromUnityAbsoluteTransform(boneWorkingDuplicate.transform);
            UnityEngine.Object.Destroy(boneWorkingDuplicate);
            return result;
        }

        private Dictionary<int, ChannelBindPose> GetChannelBindPosesForActualUnityBindposes(Transform[] bones, Matrix4x4[] bindposes)
        {
            List<int> channelIds = bones.Select(x => ChannelHelper.GetChannelId(GetCorrespondingChannelGameObjectForGameObjectInHierarchy(x.gameObject).name)).ToList();
            var result = new Dictionary<int, ChannelBindPose>();
            int boneIndex = 0;
            foreach (var channelId in channelIds)
            {
                result[channelId] = GetChannelBindPoseFromBindposeMatrix(bindposes[boneIndex]);
                boneIndex++;
            }
            return result;
        }

        public Dictionary<int, ChannelBindPose> GetBindChannelPoses()
        {
            if (gameObject.GetComponent<SkinnedMeshRenderer>() != null)
            {
                return GetChannelBindPosesForActualUnityBindposes(gameObject.GetComponent<SkinnedMeshRenderer>().bones, GetMesh().bindposes);
            } 
            else
            {
                return GetChannelBindPoseForParentChannel();
            }
        }

        public List<Vector3d> GetVertices()
        {
            return geometricObject.vertices.Select(x => Vector3d.FromUnityVector3(x)).ToList();
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
            return gameObject.GetComponent<Renderer>().materials.Select(x => x.name).ToList();
        }

        private GameObject GetCorrespondingChannelGameObjectForGameObjectInHierarchy(GameObject gameObject)
        {
            var candidate = gameObject;
            while (candidate != null && !candidate.name.Contains("Channel"))
            {
                candidate = candidate.transform.parent?.gameObject;
            }
            if (candidate == null)
            {
                throw new InvalidOperationException("Could not find corresponding channel game object in hierarchy!");
            } else
            {
                return candidate;
            }
        }

        public Tuple<Dictionary<string,
            AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material>,
            Dictionary<string, AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Texture>,
            Dictionary<string, Image>> GetMaterialsTexturesImages()
        {
            var materialsTexturesImages = UnityMaterialsToMaterialsTexturesImagesModelConverter.
                Convert(GetMaterialsWithTextureNamesData());
            return materialsTexturesImages;
        }

        private List<Tuple<UnityEngine.Material, HashSet<string>>> GetMaterialsWithTextureNamesData()
        {
            return SubmeshGameObjectMaterialsDataFetchingHelper.
                GetGouraudShaderedMaterialData(gameObject);
        }
    }
}
