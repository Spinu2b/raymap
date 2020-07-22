﻿using Assets.Scripts.Unity.Export.Perso.Model.SubobjLibDesc.VisDatDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.Perso.Model.SubobjLibDesc
{
    public class VisualData
    {
        public Dictionary<string, Material> materials = new Dictionary<string, Material>();
        public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public Dictionary<string, Image> images = new Dictionary<string, Image>();
    }
}
