using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc
{
    public class Texture : IComparableModel<Texture>
    {
        public string name;
        public string image;

        public bool EqualsToAnother(Texture other)
        {
            throw new NotImplementedException();
        }
    }
}
