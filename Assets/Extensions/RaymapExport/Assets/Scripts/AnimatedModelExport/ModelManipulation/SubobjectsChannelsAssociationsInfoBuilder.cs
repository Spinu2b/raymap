﻿using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation
{
    public class SubobjectsChannelsAssociationsInfoBuilder
    {
        private Dictionary<string, SubobjectsChannelsAssociation> result = new Dictionary<string, SubobjectsChannelsAssociation>();

        public void Consolidate(Dictionary<string, SubobjectsChannelsAssociation> subobjectsChannelsAssociations)
        {
            ComparableModelDictionariesMerger.MergeDictionariesToFirstDict(result, subobjectsChannelsAssociations);
        }

        public Dictionary<string, SubobjectsChannelsAssociation> Build()
        {
            return result;
        }
    }
}