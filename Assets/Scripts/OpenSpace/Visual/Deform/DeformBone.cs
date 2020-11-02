using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OpenSpace.Visual.Deform {
    public class DeformBone {
        public Matrix mat;
        public Matrix invertedMat;
        public float unknown1;
        public ushort invert;
        public byte index;

        private Transform unityBone = null;
        private Assets.Scripts.ResourcesModel.Geometric.Transform unityBoneModel = null;
        public Transform UnityBone {
            get {
                if (unityBone == null) {
                    GameObject gao = new GameObject("Bone " + index + " - " + unknown1 + " - " + invert);
                    unityBone = gao.transform;
                    unityBone.localPosition = DefaultPosition;
                    unityBone.localRotation = DefaultRotation;
                    unityBone.localScale = DefaultScale;

                    // Visualization
                    /*MeshRenderer mr = gao.AddComponent<MeshRenderer>();
                    MeshFilter mf = gao.AddComponent<MeshFilter>();
                    Mesh mesh = Util.CreateBox(0.1f);
                    mf.mesh = mesh;
                    mr.material = MapLoader.Loader.baseMaterial;*/
                }
                return unityBone;
            }
        }

        public Assets.Scripts.ResourcesModel.Geometric.Transform UnityBoneModel
        {
            get
            {
                if (unityBoneModel == null)
                {
                    //GameObject gao = new GameObject("Bone " + index + " - " + unknown1 + " - " + invert);
                    //unityBone = gao.transform;

                    //unityBoneModel.localPosition = Assets.Scripts.ResourcesModel.Math.Vector3.FromUnityVector3(DefaultPosition);
                    //unityBoneModel.localRotation = Assets.Scripts.ResourcesModel.Math.Quaternion.FromUnityQuaternion(DefaultRotation);
                    //unityBoneModel.localScale = Assets.Scripts.ResourcesModel.Math.Vector3.FromUnityVector3(DefaultScale);

                    // Since this bone's transform appears to be in this case exact the same as the one in global world space,
                    // we can safely assign regular transforms (position, rotation, lossyScale instead of localPosition, localRotation and 
                    // localScale). That will save us implementing some additional math behind the scenes for translating between
                    // global and local world spaces (we will need to do that anyway eventually down the line in the Blender, but if
                    // we can avoid it here, we should ;)

                    // The assumption that this bone's global transform and local transform are compliant 
                    // relies on the fact that logic creating GameObject associated with that particular bone has no parent
                    // attached initially to that, therefore it resides in pure global world space

                    unityBoneModel = new Assets.Scripts.ResourcesModel.Geometric.Transform();
                    unityBoneModel.position = Assets.Scripts.ResourcesModel.Math.Vector3.FromUnityVector3(DefaultPosition);
                    unityBoneModel.rotation = Assets.Scripts.ResourcesModel.Math.Quaternion.FromUnityQuaternion(DefaultRotation);
                    unityBoneModel.lossyScale = Assets.Scripts.ResourcesModel.Math.Vector3.FromUnityVector3(DefaultScale);

                    // Visualization
                    /*MeshRenderer mr = gao.AddComponent<MeshRenderer>();
                    MeshFilter mf = gao.AddComponent<MeshFilter>();
                    Mesh mesh = Util.CreateBox(0.1f);
                    mf.mesh = mesh;
                    mr.material = MapLoader.Loader.baseMaterial;*/
                }
                return unityBoneModel;
            }
        }

        public Matrix TransformedMatrix {
            get {
                if (invertedMat == null) invertedMat = Matrix.Invert(mat);
                return invertedMat;
            }
        }
        public Vector3 DefaultPosition {
            get { return TransformedMatrix.GetPosition(convertAxes: true); }
        }
        public Quaternion DefaultRotation {
            get { return TransformedMatrix.GetRotation(convertAxes: true); }
        }
        public Vector3 DefaultScale {
            get { return TransformedMatrix.GetScale(convertAxes: true); }
        }

        // Call after clone
        public void Reset() {
            unityBone = null;
        }

        public DeformBone Clone() {
            return ActualClone(mockUnityApi: false);
        }

        public DeformBone CloneWithMockedUnityApi()
        {
            return ActualClone(mockUnityApi: true);
        }

        private DeformBone ActualClone(bool mockUnityApi)
        {
            DeformBone b = (DeformBone)MemberwiseClone();
            b.Reset();
            return b;
        }
    }
}
