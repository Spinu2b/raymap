using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building
{
    public class SubobjectsChannelsAssociationsInfoBuilder
    {
        SubobjectsChannelsAssociations result = new SubobjectsChannelsAssociations();

        public SubobjectsChannelsAssociations Build()
        {
            return result;
        }

        public void Consolidate(SubobjectsChannelsAssociations subobjectsChannelsAssociations)
        {
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(
                result.subobjectsChannelsAssociations, subobjectsChannelsAssociations.subobjectsChannelsAssociations);
        }
    }
}
