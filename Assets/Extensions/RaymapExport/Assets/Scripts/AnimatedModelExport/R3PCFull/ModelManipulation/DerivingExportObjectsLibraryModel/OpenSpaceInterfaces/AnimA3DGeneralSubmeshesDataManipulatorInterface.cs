using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using OpenSpace;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using OpenSpace.Visual.Deform;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces
{
    public class AnimA3DGeneralSubmeshesDataManipulatorInterface
    {
        private AnimA3DGeneral animA3DGeneral;
        private Perso perso;
        private PhysicalObject[][] subObjects;
        private GameObject[] channelObjects;
        private bool[] channelParents;
        private int[] currentActivePO;
        private Dictionary<short, List<int>> channelIDDictionary = new Dictionary<short, List<int>>();
        private bool hasBones = false;

        public AnimA3DGeneralSubmeshesDataManipulatorInterface(AnimA3DGeneral animA3DGeneral, Perso perso)
        {
            this.animA3DGeneral = animA3DGeneral;
            this.perso = perso;
        }

        private void DeinitSubobjectsCollectionForManipulation()
        {
            DeleteGameObjectsParentedToPersoAssociatedWithRaymapExport();
            subObjects = null;
            channelObjects = null;
            currentActivePO = null;
            channelIDDictionary.Clear();
        }

        private void InitSubobjectsCollectionForManipulation()
        {
            subObjects = new PhysicalObject[animA3DGeneral.num_channels][];
            channelObjects = new GameObject[animA3DGeneral.num_channels];
            channelParents = new bool[animA3DGeneral.num_channels];
            currentActivePO = new int[animA3DGeneral.num_channels];
            for (int i = 0; i < animA3DGeneral.num_channels; i++)
            {
                short id = animA3DGeneral.channels[animA3DGeneral.start_channels + i].id;
                channelObjects[i] = new GameObject("RaymapExport Channel " + id);
                channelObjects[i].transform.SetParent(perso.Gao.transform);

                currentActivePO[i] = -1;
                AddChannelID(id, i);

                subObjects[i] = new PhysicalObject[animA3DGeneral.num_NTTO];
                AnimChannel channel = animA3DGeneral.channels[animA3DGeneral.start_channels + i];
                List<ushort> listOfNTTOforChannel = new List<ushort>();
                for (int j = 0; j < animA3DGeneral.num_onlyFrames; j++)
                {
                    AnimOnlyFrame onlyFrame = animA3DGeneral.onlyFrames[animA3DGeneral.start_onlyFrames + j];
                    AnimNumOfNTTO numOfNTTO = animA3DGeneral.numOfNTTO[channel.numOfNTTO + onlyFrame.numOfNTTO];
                    if (!listOfNTTOforChannel.Contains(numOfNTTO.numOfNTTO))
                    {
                        listOfNTTOforChannel.Add(numOfNTTO.numOfNTTO);
                    }
                }
                for (int k = 0; k < listOfNTTOforChannel.Count; k++)
                {
                    int j = listOfNTTOforChannel[k] - animA3DGeneral.start_NTTO;
                    AnimNTTO ntto = animA3DGeneral.ntto[animA3DGeneral.start_NTTO + j];
                    if (ntto.IsInvisibleNTTO)
                    {
                        subObjects[i][j] = new PhysicalObject(null);
                        subObjects[i][j].Gao.transform.parent = channelObjects[i].transform;
                        subObjects[i][j].Gao.name = "[" + j + "] RaymapExport Invisible PO";
                        subObjects[i][j].Gao.SetActive(false);
                    }
                    else
                    {
                        if (perso.p3dData.objectList != null && perso.p3dData.objectList.Count > ntto.object_index)
                        {
                            PhysicalObject o = perso.p3dData.objectList[ntto.object_index].po;
                            if (o != null)
                            {
                                PhysicalObject c = o.Clone();
                                subObjects[i][j] = c;
                                subObjects[i][j].Gao.transform.localScale =
                                    subObjects[i][j].scaleMultiplier.HasValue ? subObjects[i][j].scaleMultiplier.Value : Vector3.one;
                                c.Gao.transform.parent = channelObjects[i].transform;
                                c.Gao.name = "[" + j + "] RaymapExport " + c.Gao.name;
                                if (c.Bones != null)
                                {
                                    hasBones = true;
                                }
                                c.Gao.SetActive(false);
                            }
                        }
                    }
                }
            }
        }

        private void DeleteGameObjectsParentedToPersoAssociatedWithRaymapExport()
        {
            foreach (var physicalObjectArray in subObjects)
            {
                foreach (var physicalObject in physicalObjectArray)
                {
                    if (physicalObject != null && physicalObject.Gao != null)
                    {
                        UnityEngine.Object.Destroy(physicalObject.Gao);
                    }
                }
            }
            foreach (var channelObject in channelObjects)
            {
                UnityEngine.Object.Destroy(channelObject);
            }
        }

        private List<int> GetChannelByID(short id)
        {
            if (channelIDDictionary.ContainsKey(id))
            {
                return channelIDDictionary[id];
            }
            else return new List<int>();
        }

        void AddChannelID(short id, int index)
        {
            // Apparently there can be multiple channels with the ID -1, so this requires a list
            if (!channelIDDictionary.ContainsKey(id) || channelIDDictionary[id] == null)
            {
                channelIDDictionary[id] = new List<int>();
            }
            channelIDDictionary[id].Add(index);
        }

        public IEnumerable<PhysicalObjectWithChannelParentingInfo> IteratePhysicalObjectsWithChannelParentingInfosForGivenFrame(int animationFrameNumber)
        {
            InitSubobjectsCollectionForManipulation();

            for (int i = 0; i < channelParents.Length; i++)
            {
                channelParents[i] = false;
            }

            AnimOnlyFrame onlyFrame = animA3DGeneral.onlyFrames[animA3DGeneral.start_onlyFrames + animationFrameNumber];
            // Create hierarchy for this frame
            for (int i = onlyFrame.start_hierarchies_for_frame;
                i < onlyFrame.start_hierarchies_for_frame + onlyFrame.num_hierarchies_for_frame; i++)
            {
                AnimHierarchy animationHierarchy = animA3DGeneral.hierarchies[i];

                if (!channelIDDictionary.ContainsKey(animationHierarchy.childChannelID) || !channelIDDictionary.ContainsKey(animationHierarchy.parentChannelID))
                {
                    continue;
                }
                List<int> channelChildList = GetChannelByID(animationHierarchy.childChannelID);
                List<int> channelParentList = GetChannelByID(animationHierarchy.parentChannelID);
                foreach (int channelChild in channelChildList)
                {
                    foreach (int channelParent in channelParentList)
                    {
                        channelObjects[channelChild].transform.SetParent(channelObjects[channelParent].transform);
                        channelParents[channelChild] = true;
                    }
                }
            }

            for (int i = 0; i < animA3DGeneral.num_channels; i++)
            {
                AnimChannel animationChannel = animA3DGeneral.channels[animA3DGeneral.start_channels + i];
                AnimNumOfNTTO numberOfNTTO = animA3DGeneral.numOfNTTO[animationChannel.numOfNTTO + onlyFrame.numOfNTTO];
                int physicalObjectNumber = numberOfNTTO.numOfNTTO - animA3DGeneral.start_NTTO;
                PhysicalObject physicalObject = subObjects[i][physicalObjectNumber];

                if (physicalObjectNumber != currentActivePO[i])
                {
                    if (currentActivePO[i] >= 0 && subObjects[i][currentActivePO[i]] != null)
                    {
                        subObjects[i][currentActivePO[i]].Gao.SetActive(false);
                    }
                    currentActivePO[i] = physicalObjectNumber;
                    if (physicalObject != null)
                    {
                        physicalObject.Gao.SetActive(true);
                    }
                }
                if (!channelParents[i]) channelObjects[i].transform.SetParent(perso.Gao.transform);
            }

            if (hasBones)
            {
                for (int i = 0; i < animA3DGeneral.num_channels; i++)
                {
                    AnimChannel ch = animA3DGeneral.channels[animA3DGeneral.start_channels + i];
                    Transform baseChannelTransform = channelObjects[i].transform;
                    Vector3 invertedScale = new Vector3(1f / baseChannelTransform.localScale.x, 1f / baseChannelTransform.localScale.y, 1f / baseChannelTransform.localScale.z);
                    AnimNumOfNTTO numOfNTTO = animA3DGeneral.numOfNTTO[ch.numOfNTTO + onlyFrame.numOfNTTO];
                    AnimNTTO ntto = animA3DGeneral.ntto[numOfNTTO.numOfNTTO];
                    PhysicalObject physicalObject = subObjects[i][numOfNTTO.numOfNTTO - animA3DGeneral.start_NTTO];
                    if (physicalObject == null) continue;
                    DeformSet bones = physicalObject.Bones;
                    // Deformations
                    if (bones != null)
                    {
                        for (int j = 0; j < animA3DGeneral.num_deformations; j++)
                        {
                            AnimDeformation d = animA3DGeneral.deformations[animA3DGeneral.start_deformations + j];
                            if (d.channel < ch.id) continue;
                            if (d.channel > ch.id) break;
                            if (!channelIDDictionary.ContainsKey(d.linkChannel)) continue;
                            List<int> ind_linkChannel_list = GetChannelByID(d.linkChannel);
                            foreach (int ind_linkChannel in ind_linkChannel_list)
                            {
                                AnimChannel ch_link = animA3DGeneral.channels[animA3DGeneral.start_channels + ind_linkChannel];
                                AnimNumOfNTTO numOfNTTO_link = animA3DGeneral.numOfNTTO[ch_link.numOfNTTO + onlyFrame.numOfNTTO];
                                AnimNTTO ntto_link = animA3DGeneral.ntto[numOfNTTO_link.numOfNTTO];
                                PhysicalObject physicalObject_link = subObjects[ind_linkChannel][numOfNTTO_link.numOfNTTO - animA3DGeneral.start_NTTO];
                                if (physicalObject_link == null) continue;
                                if (bones == null || bones.bones.Length <= d.bone + 1) continue;
                                DeformBone bone = bones.r3bones[d.bone + 1];
                                if (bone != null)
                                {
                                    Transform channelTransform = channelObjects[ind_linkChannel].transform;
                                    bone.UnityBone.transform.SetParent(channelTransform);
                                    bone.UnityBone.localPosition = Vector3.zero;
                                    bone.UnityBone.localRotation = Quaternion.identity;
                                    bone.UnityBone.localScale = Vector3.one;
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < animA3DGeneral.num_channels; i++)
            {
                AnimChannel animationChannel = animA3DGeneral.channels[animA3DGeneral.start_channels + i];
                AnimNumOfNTTO numberOfNTTO = animA3DGeneral.numOfNTTO[animationChannel.numOfNTTO + onlyFrame.numOfNTTO];
                int physicalObjectNumber = numberOfNTTO.numOfNTTO - animA3DGeneral.start_NTTO;
                PhysicalObject physicalObject = subObjects[i][physicalObjectNumber];
                if (physicalObject.Gao.activeSelf)
                {
                    yield return new PhysicalObjectWithChannelParentingInfo(physicalObject);
                }
            }
            DeinitSubobjectsCollectionForManipulation();
        }
    }
}
