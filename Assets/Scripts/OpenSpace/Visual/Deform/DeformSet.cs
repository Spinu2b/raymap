using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OpenSpace.Visual.Deform {
    public class DeformSet : IGeometricObjectElement {
        [JsonIgnore] public GeometricObject mesh;
        public Pointer offset;
		
        public Pointer off_weights;
        public Pointer off_bones;
        public ushort num_weights;
        public byte num_bones;
        
        public DeformVertexWeights[] r3weights;
        public DeformBone[] r3bones;

        public BoneWeight[] weights;
        public Assets.Scripts.ResourcesModel.Geometric.BoneWeight[] weightsModel;
        public Transform[] bones;
        public Assets.Scripts.ResourcesModel.Geometric.Transform[] bonesModel;
        public Matrix4x4[] bindPoses;
        public Assets.Scripts.ResourcesModel.Math.Matrix4x4[] bindPosesModel;

        private GameObject gao = null;
        public GameObject Gao {
            get {
                if (gao == null) {
                    gao = new GameObject("Deform Set");
                    InitUnityBones();
                }
                return gao;
            }
        }

        private bool initUnityBonesCompliantLogicRunIndicatorFlag = false;

        public void RunWholeProperInitializationProcessForAnimationExportPurposesWithMockedUnityApiInvocations()
        {
            if (!initUnityBonesCompliantLogicRunIndicatorFlag)
            {
                InitUnityBonesCompliantLogicWithoutUnityApiUsageForAnimationExportPurposes();
            }
        }

        public DeformSet(Pointer offset, GeometricObject mesh) {
            this.mesh = mesh;
            this.offset = offset;
        }

        public void InitUnityBones()
        {
            ActualInitUnityBones(mockUnityApi: false);
        }

        private void InitUnityBonesCompliantLogicWithoutUnityApiUsageForAnimationExportPurposes()
        {
            ActualInitUnityBones(mockUnityApi: true);
            initUnityBonesCompliantLogicRunIndicatorFlag = true;
        }

        private void ActualInitUnityBones(bool mockUnityApi) {
            if (!mockUnityApi)
            {
                weights = new BoneWeight[mesh.num_vertices];
            } else
            {
                weightsModel = new Assets.Scripts.ResourcesModel.Geometric.BoneWeight[mesh.num_vertices];
            }            
            for (int i = 0; i < mesh.num_vertices; i++) {
                if (!mockUnityApi)
                {
                    weights[i] = new BoneWeight();
                    weights[i].boneIndex0 = 0;
                    weights[i].boneIndex1 = 0;
                    weights[i].boneIndex2 = 0;
                    weights[i].boneIndex3 = 0;
                    weights[i].weight0 = 1f;
                    weights[i].weight1 = 0;
                    weights[i].weight2 = 0;
                    weights[i].weight3 = 0;
                } else
                {
                    weightsModel[i] = new Assets.Scripts.ResourcesModel.Geometric.BoneWeight();
                    weightsModel[i].boneIndex0 = 0;
                    weightsModel[i].boneIndex1 = 0;
                    weightsModel[i].boneIndex2 = 0;
                    weightsModel[i].boneIndex3 = 0;
                    weightsModel[i].weight0 = 1f;
                    weightsModel[i].weight1 = 0;
                    weightsModel[i].weight2 = 0;
                    weightsModel[i].weight3 = 0;
                }                
            }
            for (int i = 0; i < num_weights; i++) {
                if (!mockUnityApi)
                {
                    weights[r3weights[i].vertexIndex] = r3weights[i].UnityWeight;
                } else
                {
                    weightsModel[r3weights[i].vertexIndex] = r3weights[i].UnityWeightModel;
                }                
            }
            if (!mockUnityApi)
            {
                bones = new Transform[num_bones];
            } else
            {
                bonesModel = new Assets.Scripts.ResourcesModel.Geometric.Transform[num_bones];
            }
            
            for (int i = 0; i < num_bones; i++) {
                if (!mockUnityApi)
                {
                    bones[i] = r3bones[i].UnityBone;
                } else
                {
                    bonesModel[i] = r3bones[i].UnityBoneModel;
                }                
            }
            if (!mockUnityApi)
            {
                bindPoses = new Matrix4x4[num_bones];
            } else
            {
                bindPosesModel = new Assets.Scripts.ResourcesModel.Math.Matrix4x4[num_bones];
            }            
            for (int i = 0; i < num_bones; i++) {
                // somewhat dirty - since we run initilization for animation export purposes in yet same thread as main Unity processing
                // loop, we can still utilize Unity's API methods here for translating transforms between spaces models - world and local
                // and then translate from Unity's API Transform object to our resources model Transform object
                if (!mockUnityApi)
                {
                    bindPoses[i] = bones[i].worldToLocalMatrix * Gao.transform.localToWorldMatrix;
                } else
                {
                    // actually we need to translate from bones' transforms located in global world space,
                    // that is they might be moved arbitralily far away from scene origin
                    // we need somehow to bring them to local space of proper subobject that will be associated to
                    // without using the GameObject because
                    // we didn't actually initialize one in this flow control path

                    // since manipulation logic for Gao (GameObject) property and gao (GameObject) field
                    // in this class appears to not do much with them before initialization
                    // we can assume that by invoking GameObject(String name) constructor in Gao property implementation
                    // we set this gao GameObject to have its home default transform, that is 
                    // position being Vector3(x=0.0f, y=0.0f, z=0.0f) in world space,
                    // rotation being Quaternion(w=1.0f, x=0.0f, y=0.0f, z=0.0f) in world space,
                    // and finally scale being Vector3(x=1.0f, y=1.0f, z=1.0f) with no parent associated etc
                    bindPosesModel[i] = bonesModel[i].worldToLocalMatrix * 
                        Assets.Scripts.ResourcesModel.Geometric.Transform
                        .GetUnityHomeTransformedGameObjectTransformMock().localToWorldMatrix;
                }                
            }
            if (!mockUnityApi)
            {
                for (int j = 0; j < num_bones; j++)
                {
                    Transform b = bones[j];
                    b.transform.SetParent(gao.transform);
                }
            }            
        }

        public void RecalculateBindPoses() {
            bindPoses = new Matrix4x4[num_bones];
            for (int i = 0; i < num_bones; i++) {
                bindPoses[i] = bones[i].worldToLocalMatrix * Gao.transform.localToWorldMatrix;
            }
            mesh.ReinitBindposes();
        }
        

        public static DeformSet Read(Reader reader, Pointer offset, GeometricObject m) {
            MapLoader l = MapLoader.Loader;
            DeformSet d = new DeformSet(offset, m);
            d.off_weights = Pointer.Read(reader);
            d.off_bones = Pointer.Read(reader);
            d.num_weights = reader.ReadUInt16();
            d.num_bones = reader.ReadByte();
            d.num_bones += 1;
            // one more byte here, always zero? padding?

            // Create arrays
            d.r3bones = new DeformBone[d.num_bones]; // add root bone
            d.r3weights = new DeformVertexWeights[d.num_weights];

            // Read weights
            Pointer.Goto(ref reader, d.off_weights);
            for (int i = 0; i < d.num_weights; i++) {
                Pointer off_weightsForVertex = Pointer.Read(reader);
                ushort vertex_index = reader.ReadUInt16();
                byte num_weightsForVertex = reader.ReadByte();
                reader.ReadByte(); // 0, padding
                d.r3weights[i] = new DeformVertexWeights(vertex_index);
                Pointer curPos = Pointer.Goto(ref reader, off_weightsForVertex);
                for (int j = 0; j < num_weightsForVertex; j++) {
                    ushort weight = reader.ReadUInt16();
                    //float floatWeight = weight / UInt16.MaxValue;
                    byte boneIndex = reader.ReadByte();
                    reader.ReadByte(); // 0, padding
                    d.r3weights[i].boneWeights.Add(boneIndex, weight);
                }
                Pointer.Goto(ref reader, curPos);
            }

            // Read bones
            d.r3bones[0] = new DeformBone();
            d.r3bones[0].mat = new Matrix(null, 1, Matrix4x4.identity, new Vector4(1f, 1f, 1f, 1f));
            d.r3bones[0].index = 0;
            Pointer.Goto(ref reader, d.off_bones);
            for (int i = 1; i < d.num_bones; i++) {
                d.r3bones[i] = new DeformBone();

                // each bone is a 0x38 block
                Matrix4x4 mat = new Matrix4x4();
                float x = reader.ReadSingle();
                float y = reader.ReadSingle();
                float z = reader.ReadSingle();
                mat.SetColumn(3,new Vector4(x, y, z, 1f));
                for (int j = 0; j < 3; j++) {
                    mat.SetColumn(j, new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), 1f));
                }
                d.r3bones[i].mat = new Matrix(null, 1, mat, new Vector4(1f, 1f, 1f, 1f));
				if (Settings.s.game == Settings.Game.LargoWinch) {
					Pointer off_shorts = Pointer.Read(reader); // offset of shorts. the next ushort, invert, is actually number of shorts.
					d.r3bones[i].invert = reader.ReadUInt16();
					//l.print("Number of shorts: " + d.r3bones[i].invert);
					Pointer.DoAt(ref reader, off_shorts, () => {
						for (int j = 0; j < d.r3bones[i].invert; j++) {
							reader.ReadUInt16();
						}
					});
				} else {
					d.r3bones[i].unknown1 = reader.ReadSingle();
					d.r3bones[i].invert = reader.ReadUInt16();
				}

                d.r3bones[i].index = reader.ReadByte();
                reader.ReadByte(); // 0, padding
            }

            return d;
        }

        // Call after clone
        public void Reset() {
            gao = null;
        }

        public IGeometricObjectElement Clone(GeometricObject mesh) {
            return ActualClone(mockUnityApi: false, mesh: mesh);
        }

        public IGeometricObjectElement CloneWithMockedUnityApi(GeometricObject mesh)
        {
            return ActualClone(mockUnityApi: true, mesh: mesh);
        }

        private IGeometricObjectElement ActualClone(bool mockUnityApi, GeometricObject mesh)
        {
            DeformSet d = (DeformSet)MemberwiseClone();
            d.Reset();
            d.mesh = mesh;
            d.r3bones = new DeformBone[r3bones.Length];
            for (int i = 0; i < r3bones.Length; i++)
            {
                if (mockUnityApi)
                {
                    d.r3bones[i] = r3bones[i].CloneWithMockedUnityApi();
                } else {
                    d.r3bones[i] = r3bones[i].Clone();
                }                
            }
            d.r3weights = new DeformVertexWeights[r3weights.Length];
            for (int i = 0; i < r3weights.Length; i++)
            {
                if (mockUnityApi) {
                    d.r3weights[i] = r3weights[i].CloneWithMockedUnityApi();
                } else {
                    d.r3weights[i] = r3weights[i].Clone();
                }                
            }
            return d;
        }
    }
}
