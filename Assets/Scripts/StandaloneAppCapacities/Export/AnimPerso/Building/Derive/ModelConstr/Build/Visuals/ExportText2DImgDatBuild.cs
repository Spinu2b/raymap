using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Visuals.Trans;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.VisDatDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Visuals
{
    public class ExportTexture2DImageDataBuilder
    {
        VisualData result = new VisualData();

        public ExportTexture2DImageDataBuilder SetImage(Image textureImage)
        {
            result = MiscellaneousVisualModelToVisualDataTransformer.TransformImageToVisualData(textureImage);
            return this;
        }

        public VisualData Build()
        {
            return result;
        }
    }
}
