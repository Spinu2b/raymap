﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Wrappers.Normal
{
    public partial class NormalPersoAccessor
    {
        public List<int> GetChannelByID(short id)
        {
            if (channelIDDictionary.ContainsKey(id))
            {
                return channelIDDictionary[id];
            }
            else return new List<int>();
        }
    }
}
