using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.RaymapWrappers.Normal;
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
    public static class NormalPersoNormalFrameSubobjectsChannelsAssociationDataFetcher
    {
        public static SubobjectsChannelsAssociation DeriveFor(NormalPersoAccessor normalPersoAccessor)
        {
            var result = new SubobjectsChannelsAssociation();
            result.subobjectsChannelsAssociationDescription.channelsForSubobjectsParenting = DeriveChannelsForSubobjectsParenting(normalPersoAccessor);
            result.subobjectsChannelsAssociationDescription.channelsForSubobjectsBonesParenting = DeriveChannelsForSubobjectsBonesParenting(normalPersoAccessor);
            result.subobjectsChannelsAssociationDescriptionHash = result.subobjectsChannelsAssociationDescription.ComputeHash();
            return result;
        }

        private static Dictionary<int, List<int>> DeriveChannelsForSubobjectsParenting(NormalPersoAccessor normalPersoAccessor)
        {
            var result = new Dictionary<int, List<int>>();
            for (int i = 0; i < normalPersoAccessor.a3d.num_channels; i++)
            {
                short channelId = normalPersoAccessor.a3d.channels[normalPersoAccessor.a3d.start_channels + i].id;
                AnimChannel ch = normalPersoAccessor.a3d.channels[normalPersoAccessor.a3d.start_channels + i];
                List<ushort> listOfNTTOforChannel = new List<ushort>();

                AnimOnlyFrame of = normalPersoAccessor.a3d.onlyFrames[normalPersoAccessor.a3d.start_onlyFrames + normalPersoAccessor.currentFrame];
                AnimNumOfNTTO numOfNTTO = normalPersoAccessor.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];
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
                    int j = listOfNTTOforChannel[k] - normalPersoAccessor.a3d.start_NTTO;
                    AnimNTTO ntto = normalPersoAccessor.a3d.ntto[normalPersoAccessor.a3d.start_NTTO + j];
                    if (!ntto.IsInvisibleNTTO)
                    {
                        if (normalPersoAccessor.perso.p3dData.objectList != null && normalPersoAccessor.perso.p3dData.objectList.Count > ntto.object_index)
                        {
                            PhysicalObject o = normalPersoAccessor.perso.p3dData.objectList[ntto.object_index].po;
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

        private static bool DetermineIfHasBones(NormalPersoAccessor normalPersoAccessor)
        {
            return normalPersoAccessor.hasBones;
        }

        private static Dictionary<int, Dictionary<int, List<int>>> DeriveChannelsForSubobjectsBonesParenting(NormalPersoAccessor normalPersoAccessor)
        {
            if (DetermineIfHasBones(normalPersoAccessor))
            {
                var result = new Dictionary<int, Dictionary<int, List<int>>>();
                AnimOnlyFrame of = normalPersoAccessor.a3d.onlyFrames[normalPersoAccessor.a3d.start_onlyFrames + normalPersoAccessor.currentFrame];
                for (int i = 0; i < normalPersoAccessor.a3d.num_channels; i++)
                {
                    AnimChannel ch = normalPersoAccessor.a3d.channels[normalPersoAccessor.a3d.start_channels + i];
                    int id = ch.id;
                    AnimNumOfNTTO numOfNTTO = normalPersoAccessor.a3d.numOfNTTO[ch.numOfNTTO + of.numOfNTTO];

                    PhysicalObject physicalObject = normalPersoAccessor.subObjects[i][numOfNTTO.numOfNTTO - normalPersoAccessor.a3d.start_NTTO];
                    
                    if (physicalObject == null) continue;
                    DeformSet bones = physicalObject.Bones;
                    if (bones != null)
                    {
                        for (int j = 0; j < normalPersoAccessor.a3d.num_deformations; j++)
                        {
                            AnimDeformation d = normalPersoAccessor.a3d.deformations[normalPersoAccessor.a3d.start_deformations + j];
                            if (d.channel < ch.id) continue;
                            if (d.channel > ch.id) break;

                            Dictionary<short, List<int>> channelIDDictionary = normalPersoAccessor.channelIDDictionary;

                            if (!channelIDDictionary.ContainsKey(d.linkChannel)) continue;
                            List<int> ind_linkChannel_list = normalPersoAccessor.GetChannelByID(d.linkChannel);
                            foreach (int ind_linkChannel in ind_linkChannel_list)
                            {
                                AnimChannel ch_link = normalPersoAccessor.a3d.channels[normalPersoAccessor.a3d.start_channels + ind_linkChannel];
                                AnimNumOfNTTO numOfNTTO_link = normalPersoAccessor.a3d.numOfNTTO[ch_link.numOfNTTO + of.numOfNTTO];
                                PhysicalObject physicalObject_link = normalPersoAccessor.subObjects[ind_linkChannel][numOfNTTO_link.numOfNTTO - normalPersoAccessor.a3d.start_NTTO];
                                AnimNTTO ntto_link = normalPersoAccessor.a3d.ntto[numOfNTTO_link.numOfNTTO];
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
