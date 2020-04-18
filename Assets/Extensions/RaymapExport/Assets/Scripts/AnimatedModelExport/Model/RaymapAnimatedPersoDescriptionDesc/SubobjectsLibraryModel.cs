using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc
{
    public class SubobjectsLibraryModel : IExportModel
    {
        public VisualData visualData = new VisualData();
        public Dictionary<int, SubobjectModel> subobjects = new Dictionary<int, SubobjectModel>();
    }
}
