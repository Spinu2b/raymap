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
        public Dictionary<string, Material> materials = new Dictionary<string, Material>();
        public Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        public Dictionary<string, Image> images = new Dictionary<string, Image>();
        public Dictionary<int, SubobjectModel> subobjects = new Dictionary<int, SubobjectModel>();
    }
}
