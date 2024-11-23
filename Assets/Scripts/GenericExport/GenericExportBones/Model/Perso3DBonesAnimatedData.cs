using Assets.Scripts.GenericExport.GenericExportBones.Model.DataBlocks;
using Assets.Scripts.GenericExport.Model.DataBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GenericExport.GenericExportBones.Model
{
    public class Perso3DBonesAnimatedData
    {
        public Dictionary<int, Dictionary<int, FrameBonesDataBlock>> states = new Dictionary<int, Dictionary<int, FrameBonesDataBlock>>();
    }
}
