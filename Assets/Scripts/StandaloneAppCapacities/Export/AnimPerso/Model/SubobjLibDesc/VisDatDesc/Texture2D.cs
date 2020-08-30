using Assets.Scripts.Unity.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc
{
    public class Texture2D : IExportModel, IComparableModel<Texture2D>
    {
        public string textureDescriptionHash;
        public string image;

        public bool EqualsToAnother(Texture2D other)
        {
            throw new NotImplementedException();
        }
    }
}
