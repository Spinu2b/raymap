﻿using Assets.Scripts.Unity.ModelDataExporting.R3.PersoStatesArmatureAnimationsExporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Unity.ModelDataExporting.R3.PersoStatesArmatureAnimationsExporting
{
    public class AnimationsModelConstructor
    {
        AnimationsModel animationsModel = new AnimationsModel();

        private bool isChannelObj(GameObject obj)
        {
            return obj.name.StartsWith("Channel");
        }

        private AnimationFrameModel traverseRecursivelyChildrenChannels(GameObject obj, AnimationFrameModel animationFrameModel)
        {
            if (obj == null)
            {
                return animationFrameModel;
            }

            foreach (Transform child in obj.transform)
            {
                if (child == null || !isChannelObj(child.gameObject))
                    continue;

                GameObject channelBone = getChannelBone(child.gameObject);

                animationFrameModel.addNode(isChannelObj(obj) ? obj.name : null, child.gameObject.name,
                child.gameObject.transform.position.x,
                child.gameObject.transform.position.y,
                child.gameObject.transform.position.z,
                child.gameObject.transform.localPosition.x,
                child.gameObject.transform.localPosition.y,
                child.gameObject.transform.localPosition.z,
                child.gameObject.transform.rotation.w,
                child.gameObject.transform.rotation.x,
                child.gameObject.transform.rotation.y,
                child.gameObject.transform.rotation.z,
                child.gameObject.transform.localRotation.w,
                child.gameObject.transform.localRotation.x,
                child.gameObject.transform.localRotation.y,
                child.gameObject.transform.localRotation.z,
                child.gameObject.transform.lossyScale.x,
                child.gameObject.transform.lossyScale.y,
                child.gameObject.transform.lossyScale.z,
                child.gameObject.transform.localScale.x,
                child.gameObject.transform.localScale.y,
                child.gameObject.transform.localScale.z,
                channelBone != null);
                traverseRecursivelyChildrenChannels(child.gameObject, animationFrameModel);
            }
            return animationFrameModel;
        }

        private GameObject getChannelBone(GameObject obj)
        {
            foreach (Transform child in obj.transform)
            {
                if (child == null || isChannelObj(child.gameObject))
                {
                    continue;
                }
                if (child.gameObject.name.StartsWith("Bone"))
                {
                    return child.gameObject;
                }
                else if (!child.gameObject.name.Contains("Invisible PO"))
                {
                    return getChannelBone(child.gameObject);
                }
            }
            return null;
        }

        public AnimationsModel getAnimationsModel()
        {
            return animationsModel;
        }
    }
}