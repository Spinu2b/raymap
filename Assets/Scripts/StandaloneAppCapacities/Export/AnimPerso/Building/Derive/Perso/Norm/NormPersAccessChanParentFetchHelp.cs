using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Wrappers.Normal;
using OpenSpace;
using OpenSpace.Animation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.Perso.Norm
{
    public class NormalPersoAccessorChannelsParentingFetchingHelper : NormalPersoAccessorAnimationDataFetchingHelper
    {
        public NormalPersoAccessorChannelsParentingFetchingHelper(NormalPersoAccessor normalPersoAccessor) : base(normalPersoAccessor)
        {
        }

        public Dictionary<int, int> GetPersoBehaviourChannelsParentingForFrame(int frameNumber)
        {
            UpdateAnimation(frameNumber);
            if (IsNormalAnimation())
            {
                return GetChannelsParentingForNormalAnimation();
            }
            else if (IsMontrealAnimation())
            {
                return GetChannelsParentingForMontrealAnimation();
            }
            else if (IsLargoAnimation())
            {
                return GetChannelsParentingForLargoAnimation();
            }
            else
            {
                throw new InvalidOperationException("This perso behaviour does not have neither normal, montreal nor largo animation frames in this state!");
            }
        }

        private Dictionary<int, int> GetChannelsParentingForLargoAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, int> GetChannelsParentingForMontrealAnimation()
        {
            throw new NotImplementedException();
        }

        private Dictionary<int, int> GetChannelsParentingForNormalAnimation()
        {
            var result = new Dictionary<int, int>();

            AnimOnlyFrame of = normalPersoAccessor.a3d.onlyFrames[normalPersoAccessor.a3d.start_onlyFrames + normalPersoAccessor.currentFrame];
            // Create hierarchy for this frame
            for (int i = of.start_hierarchies_for_frame;
                i < of.start_hierarchies_for_frame + of.num_hierarchies_for_frame; i++)
            {
                AnimHierarchy h = normalPersoAccessor.a3d.hierarchies[i];

                if (Settings.s.engineVersion <= Settings.EngineVersion.TT)
                {
                    result.Add(h.childChannelID, h.parentChannelID);
                }
                else
                {
                    Dictionary<short, List<int>> channelIDDictionary = normalPersoAccessor.channelIDDictionary;

                    if (!channelIDDictionary.ContainsKey(h.childChannelID) || !channelIDDictionary.ContainsKey(h.parentChannelID))
                    {
                        continue;
                    }

                    List<int> ch_child_list = normalPersoAccessor.GetChannelByID(h.childChannelID);
                    List<int> ch_parent_list = normalPersoAccessor.GetChannelByID(h.parentChannelID);
                    result.Add(h.childChannelID, h.parentChannelID);
                }
            }
            return result;
        }
    }
}
