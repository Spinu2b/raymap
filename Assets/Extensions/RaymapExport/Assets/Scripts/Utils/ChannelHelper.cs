using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils
{
    public static class ChannelHelper
    {
        private static Regex numberRegex = new Regex(@"\d+");

        public static int GetChannelId(string channelName)
        {
            return int.Parse(numberRegex.Match(channelName).Value);
        }
    }
}
