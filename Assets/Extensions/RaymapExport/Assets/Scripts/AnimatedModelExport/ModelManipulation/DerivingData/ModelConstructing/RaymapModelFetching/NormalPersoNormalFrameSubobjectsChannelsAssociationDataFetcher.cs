using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using OpenSpace;
using OpenSpace.Animation.Component;
using OpenSpace.Object;
using OpenSpace.Visual.Deform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.RaymapModelFetching
{
    public class NormalPersoNormalFrameSubobjectsChannelsAssociationDataFetcher
    {
        public static SubobjectsChannelsAssociation DeriveFor(PersoBehaviour persoBehaviour)
        {
            var result = new SubobjectsChannelsAssociation();
            result.subobjectsChannelsAssociationDescription.channelsForSubobjectsParenting = DeriveChannelsForSubobjectsParenting(persoBehaviour);
            result.subobjectsChannelsAssociationDescription.channelsForSubobjectsBonesParenting = DeriveChannelsForSubobjectsBonesParenting(persoBehaviour);
            result.subobjectsChannelsAssociationDescriptionHash = result.subobjectsChannelsAssociationDescription.ComputeHash();
            return result;
        }

        private static Dictionary<int, List<int>> DeriveChannelsForSubobjectsParenting(PersoBehaviour persoBehaviour)
        {
            var result = new Dictionary<int, List<int>>();
            for (int i = 0; i < persoBehaviour.a3d.num_channels; i++)
            {
                short channelId = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i].id;
                AnimChannel ch = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i];
                List<ushort> listOfNTTOforChannel = new List<ushort>();

                AnimOnlyFrame of = persoBehaviour.a3d.onlyFrames[persoBehaviour.a3d.start_onlyFrames + persoBehaviour.currentFrame];
                AnimNumOfNTTO numOfNTTO = persoBehaviour.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
                if (!listOfNTTOforChannel.Contains(numOfNTTO.numOfNTTO))
                {
                    listOfNTTOforChannel.Add(numOfNTTO.numOfNTTO);
                }

                //for (int j = 0; j < persoBehaviour.a3d.num_onlyFrames; j++)
                //{
                //    AnimOnlyFrame of = persoBehaviour.a3d.onlyFrames[persoBehaviour.a3d.start_onlyFrames + j];
                //    AnimNumOfNTTO numOfNTTO = persoBehaviour.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
                //    if (!listOfNTTOforChannel.Contains(numOfNTTO.numOfNTTO))
                //    {
                //        listOfNTTOforChannel.Add(numOfNTTO.numOfNTTO);
                //    }
                //}
                for (int k = 0; k < listOfNTTOforChannel.Count; k++)
                {
                    int j = listOfNTTOforChannel[k] - persoBehaviour.a3d.start_NTTO;
                    AnimNTTO ntto = persoBehaviour.a3d.ntto[persoBehaviour.a3d.start_NTTO + j];
                    if (!ntto.IsInvisibleNTTO)
                    {
                        if (persoBehaviour.perso.p3dData.objectList != null && persoBehaviour.perso.p3dData.objectList.Count > ntto.object_index)
                        {
                            PhysicalObject o = persoBehaviour.perso.p3dData.objectList[ntto.object_index].po;
                            if (!result.ContainsKey(channelId))
                            {
                                result[channelId] = new List<int>();
                            }
                            result[channelId].AddWithUniqueCheck(ntto.object_index);
                        }
                    }
                }
            }
            return result;
        }

        private static bool DetermineIfHasBones(PersoBehaviour persoBehaviour)
        {
            return (bool)typeof(PersoBehaviour).GetField(
                            "hasBones", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(persoBehaviour);
        }

        private static Dictionary<int, Dictionary<int, List<int>>> DeriveChannelsForSubobjectsBonesParenting(PersoBehaviour persoBehaviour)
        {
            if (DetermineIfHasBones(persoBehaviour))
            {
                var result = new Dictionary<int, Dictionary<int, List<int>>>();
                AnimOnlyFrame of = persoBehaviour.a3d.onlyFrames[persoBehaviour.a3d.start_onlyFrames + persoBehaviour.currentFrame];
                for (int i = 0; i < persoBehaviour.a3d.num_channels; i++)
                {
                    AnimChannel ch = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + i];
                    int id = ch.id;
                    AnimNumOfNTTO numOfNTTO = persoBehaviour.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
                    PhysicalObject physicalObject = persoBehaviour.subObjects[i][numOfNTTO.numOfNTTO - persoBehaviour.a3d.start_NTTO];
                    if (physicalObject == null) continue;
                    DeformSet bones = physicalObject.Bones;
                    if (bones != null)
                    {
                        for (int j = 0; j < persoBehaviour.a3d.num_deformations; j++)
                        {
                            AnimDeformation d = persoBehaviour.a3d.deformations[persoBehaviour.a3d.start_deformations + j];
                            if (d.channel < ch.id) continue;
                            if (d.channel > ch.id) break;

                            Dictionary<short, List<int>> channelIDDictionary =
                        (Dictionary<short, List<int>>)typeof(PersoBehaviour).GetField(
                            "channelIDDictionary", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(persoBehaviour);

                            var getChannelByIDMethod = typeof(PersoBehaviour).GetMethod("GetChannelByID", BindingFlags.NonPublic | BindingFlags.Instance);

                            if (!channelIDDictionary.ContainsKey(d.linkChannel)) continue;
                            List<int> ind_linkChannel_list = (List<int>)getChannelByIDMethod.Invoke(persoBehaviour, new object[] { d.linkChannel });
                            foreach (int ind_linkChannel in ind_linkChannel_list)
                            {
                                AnimChannel ch_link = persoBehaviour.a3d.channels[persoBehaviour.a3d.start_channels + ind_linkChannel];
                                AnimNumOfNTTO numOfNTTO_link = persoBehaviour.a3d.numOfNTTO[ch_link.numOfNTTO + of.numOfNTTO];
                                PhysicalObject physicalObject_link = persoBehaviour.subObjects[ind_linkChannel][numOfNTTO_link.numOfNTTO - persoBehaviour.a3d.start_NTTO];
                                AnimNTTO ntto_link = persoBehaviour.a3d.ntto[numOfNTTO_link.numOfNTTO];
                                if (physicalObject_link == null) continue;
                                if (bones == null || bones.bones.Length <= d.bone + 1) continue;
                                DeformBone bone = bones.r3bones[d.bone + 1];
                                if (bone != null)
                                {
                                    if (!result.ContainsKey(ch_link.id))
                                    {
                                        result[ch_link.id] = new Dictionary<int, List<int>>();
                                    }
                                    if (!result[ch_link.id].ContainsKey(ntto_link.object_index))
                                    {
                                        result[ch_link.id][ntto_link.object_index] = new List<int>();
                                    }
                                    result[ch_link.id][ntto_link.object_index].AddWithUniqueCheck(d.bone + 1);
                                }
                            }                               
                        }                            
                    }
                }
                return result;
            } else
            {
                return new Dictionary<int, Dictionary<int, List<int>>>();
            }
        }
    }
}
