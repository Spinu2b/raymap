using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils;
using OpenSpace;
using OpenSpace.Animation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal
{
    public class NormalPersoBehaviourChannelsParentingFetchingHelper : NormalPersoBehaviourAnimationDataFetchingHelper
    {
        public NormalPersoBehaviourChannelsParentingFetchingHelper(PersoBehaviour persoBehaviour) : base(persoBehaviour) {}

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

            AnimOnlyFrame of = persoBehaviour.a3d.onlyFrames[persoBehaviour.a3d.start_onlyFrames + persoBehaviour.currentFrame];
            // Create hierarchy for this frame
            for (int i = of.start_hierarchies_for_frame;
                i < of.start_hierarchies_for_frame + of.num_hierarchies_for_frame; i++)
            {
                AnimHierarchy h = persoBehaviour.a3d.hierarchies[i];

                if (Settings.s.engineVersion <= Settings.EngineVersion.TT)
                {
                    result.Add(h.childChannelID, h.parentChannelID);
                }
                else
                {
                    Dictionary<short, List<int>> channelIDDictionary = 
                        (Dictionary<short, List<int>>) typeof(PersoBehaviour).GetField(
                            "channelIDDictionary", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(persoBehaviour);

                    if (!channelIDDictionary.ContainsKey(h.childChannelID) || !channelIDDictionary.ContainsKey(h.parentChannelID))
                    {
                        continue;
                    }

                    var getChannelByIDMethod = typeof(PersoBehaviour).GetMethod("GetChannelByID", BindingFlags.NonPublic | BindingFlags.Instance);

                    List<int> ch_child_list = (List<int>) getChannelByIDMethod.Invoke(persoBehaviour, new object[] { h.childChannelID });
                    List<int> ch_parent_list = (List<int>)getChannelByIDMethod.Invoke(persoBehaviour, new object[] { h.parentChannelID });
                    result.Add(h.childChannelID, h.parentChannelID);
                }
            }
            return result;
        }
    }
}
