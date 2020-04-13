using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing
{
    public class VisualDataFactory
    {
        public VisualData DeriveFor(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            var resultList = new List<VisualData>();
            foreach (var visualDataInFrameInfo in persoBehaviourAnimationStatesHelper.IterateVisualDataForThisAnimationState())
            {
                resultList.Add(visualDataInFrameInfo.Item2);
            }
            return VisualDataUnifier.Unify(resultList);
        }
    }
}
