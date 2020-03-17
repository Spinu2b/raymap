using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model;
using OpenSpace;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.OpenSpaceInterfaces
{
    public class AnimA3DGeneralSubmeshesDataManipulatorInterface
    {
        private AnimA3DGeneral animA3DGeneral;
        private Perso perso;
        private PhysicalObject[][] subObjects;
        private GameObject[] channelObjects;
        private int[] currentActivePO;

        public AnimA3DGeneralSubmeshesDataManipulatorInterface(AnimA3DGeneral animA3DGeneral, Perso perso)
        {
            this.animA3DGeneral = animA3DGeneral;
            this.perso = perso;
        }

        private void InitSubobjectsCollectionForManipulation()
        {
            subObjects = new PhysicalObject[animA3DGeneral.num_channels][];
            channelObjects = new GameObject[animA3DGeneral.num_channels];
            currentActivePO = new int[animA3DGeneral.num_channels];
            for (int i = 0; i < animA3DGeneral.num_channels; i++)
            {
                short id = animA3DGeneral.channels[animA3DGeneral.start_channels + i].id;
                channelObjects[i] = new GameObject("RaymapExport Channel " + id);
                channelObjects[i].transform.SetParent(perso.Gao.transform);

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
                                c.Gao.SetActive(false);
                            }
                        }
                    }
                }
            }
        }

        private void DeinitSubobjectsCollectionForManipulation()
        {
            DeleteGameObjectsParentedToPersoAssociatedWithRaymapExport();
            subObjects = null;
            channelObjects = null;
            currentActivePO = null;
        }

        private void DeleteGameObjectsParentedToPersoAssociatedWithRaymapExport()
        {
            foreach (var physicalObjectArray in subObjects)
            {
                foreach (var physicalObject in physicalObjectArray)
                {
                    UnityEngine.Object.Destroy(physicalObject.Gao);
                }
            }
            foreach (var channelObject in channelObjects)
            {
                UnityEngine.Object.Destroy(channelObject);
            }
        }

        public IEnumerable<PhysicalObjectWithChannelParentingInfo> IteratePhysicalObjectsWithChannelParentingInfosForGivenFrame(int animationFrameNumber)
        {
            InitSubobjectsCollectionForManipulation();
            for (int i = 0; i < animA3DGeneral.num_channels; i++)
            {
                AnimOnlyFrame onlyFrame = animA3DGeneral.onlyFrames[animA3DGeneral.start_onlyFrames + animationFrameNumber];
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
                        yield return new PhysicalObjectWithChannelParentingInfo(physicalObject);
                    }
                }
            }
            DeinitSubobjectsCollectionForManipulation();
        }
    }
}
