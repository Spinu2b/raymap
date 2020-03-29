using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc
{
    public class SubobjectsLibraryModel
    {
        public Dictionary<string, Material> materials;
        public Dictionary<string, Texture> textures;
        public Dictionary<string, Image> images;
        public Dictionary<int, SubobjectModel> subobjects;
    }
}
