using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc
{
    public class VisualData : IExportModel
    {
        public Dictionary<string, Material> materials = new Dictionary<string, Material>();
        public Dictionary<string, VisDatDesc.Texture2D> textures = new Dictionary<string, VisDatDesc.Texture2D>();
        public Dictionary<string, Image> images = new Dictionary<string, Image>();

        public static VisualData FromResourcesModelTexture2D(ResourcesModel.Visuals.Texture2D textureModel)
        {
            throw new NotImplementedException();
        }
    }
}
