using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class SubmeshesDescriptionSetFactory
    {
        public Dictionary<int, SubobjectModel> DeriveFor(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var result = new Dictionary<int, SubobjectModel>();
            foreach (var subobjectModelInfo in persoBehaviourAnimationStatesHelper.IterateSubobjectsUsedForThisAnimationState())
            {
                foreach (var subobjectModel in subobjectModelInfo.Item2)
                {
                    if (!result.ContainsKey(subobjectModel.objectNumber))
                    {
                        result.Add(subobjectModel.objectNumber, subobjectModel);
                    }
                }
            }
            return result;
        }
    }
}
