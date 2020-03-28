using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc.SubmeshObjectModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc.SubmeshObjectModelDesc.MaterialDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc
{
    public class SubmeshesLibraryModel
    {
        public Dictionary<string, Material> materials;
        public Dictionary<string, Texture> textures;
        public Dictionary<string, Image> images;
        public Dictionary<string, SubmeshObjectModel> submeshes;
    }
}
