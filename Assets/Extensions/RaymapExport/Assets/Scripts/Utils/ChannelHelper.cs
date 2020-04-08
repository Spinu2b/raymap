using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils
{
    public static class ChannelHelper
    {
        private static Regex numberRegex = new Regex(@"\d+");

        public static int GetChannelId(string channelName)
        {
            return int.Parse(numberRegex.Match(channelName).Value);
        }

        public static Transform GetParentChannelTransformFor(Transform baseTransform)
        {
            var parentCandidate = baseTransform.parent;
            while (parentCandidate != null && !parentCandidate.gameObject.name.Contains("Channel"))
            {
                parentCandidate = parentCandidate.parent;
            }
            return parentCandidate;
        }
    }
}
