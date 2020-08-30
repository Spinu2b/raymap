using Assets.Scripts.Unity.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.Unity.Export.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.AnimPerso.Building
{
    public static class VisualDataUnifier
    {
        public static VisualData Unify(List<VisualData> parts)
        {
            var result = new VisualData();
            foreach (var mergingPart in parts)
            {
                ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result.materials, mergingPart.materials);
                ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result.textures, mergingPart.textures);
                ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result.images, mergingPart.images);
            }

            return result;
        }
    }
}
