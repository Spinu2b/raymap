using Assets.Scripts.StandaloneAppCapacities.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc
{
    public class Texture2D : IExportModel, IComparableModel<Texture2D>
    {
        public string textureDescriptionIdentifier;
        public string imageIdentifier;

        public bool EqualsToAnother(Texture2D other)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromResourcesModelTexture2D(ResourcesModel.Visuals.Texture2D textureModel)
        {
            throw new NotImplementedException();
        }
    }
}
