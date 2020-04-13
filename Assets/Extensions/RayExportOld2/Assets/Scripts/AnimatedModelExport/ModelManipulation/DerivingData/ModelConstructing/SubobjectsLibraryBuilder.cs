using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class SubobjectsLibraryBuilder
    {
        SubobjectsLibraryModel result = new SubobjectsLibraryModel();

        public void Consolidate(Dictionary<int, SubobjectModel> subobjects, VisualData visualData)
        {
            var visualDatasToConsolidate = new List<VisualData>();
            visualDatasToConsolidate.Add(result.visualData);
            visualDatasToConsolidate.Add(visualData);
            result.visualData = VisualDataUnifier.Unify(visualDatasToConsolidate);
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result.subobjects, subobjects);
        }

        public SubobjectsLibraryModel Build()
        {
            return result;
        }
    }
}
