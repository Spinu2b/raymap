﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc
{
    public struct ChannelBindPose : ISerializableToBytes, IComparableModel<ChannelBindPose>
    {
        public Vector3d position;
        public MathDescription.Quaternion rotation;
        public Vector3d scale;

        public static ChannelBindPose HomeTransform()
        {
            var result = new ChannelBindPose();
            result.position = new Vector3d(0.0f, 0.0f, 0.0f);
            result.rotation = new MathDescription.Quaternion(1.0f, 0.0f, 0.0f, 0.0f);
            result.scale = new Vector3d(1.0f, 1.0f, 1.0f);
            return result;
        }

        public static ChannelBindPose FromUnityAbsoluteTransform(Transform transform)
        {
            var result = new ChannelBindPose();
            result.position = Vector3d.FromUnityVector3(transform.position);
            result.rotation = MathDescription.Quaternion.FromUnityQuaternion(transform.rotation);
            result.scale = Vector3d.FromUnityVector3(transform.lossyScale);
            return result;
        }

        public bool RoundEquals(ChannelBindPose other)
        {
            return position.RoundEquals(other.position) && rotation.RoundEquals(other.rotation) && scale.RoundEquals(other.scale);
        }

        public byte[] SerializeToBytes()
        {
            return position.SerializeToBytes().Concat(rotation.SerializeToBytes()).Concat(scale.SerializeToBytes()).ToArray();
        }

        public bool EqualsToAnother(ChannelBindPose other)
        {
            return position.RoundEquals(other.position) && rotation.RoundEquals(other.rotation) && scale.RoundEquals(other.scale);
        }
    }
}
