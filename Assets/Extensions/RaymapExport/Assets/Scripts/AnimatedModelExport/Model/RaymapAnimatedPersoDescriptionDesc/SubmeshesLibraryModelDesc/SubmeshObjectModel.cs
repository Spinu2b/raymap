using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc.SubmeshObjectModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubmeshesLibraryModelDesc
{
    public abstract class SubmeshObjectModel
    {
        public SubmeshObjectType submeshObjectType;
        public string name;
        public Dictionary<string, SubmeshGeometricObject> geometricObjects;
    }
}
