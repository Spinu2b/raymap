using Assets.Scripts.ResourcesModel.Geometric;
using Assets.Scripts.ResourcesModel.Math;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.SubobjLibDesc.GeoObjDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.Build.Geometric.Trans
{
    public static class MiscellaneousGeometricDataToPersoDescriptionModelTransformer
    {
        public static Dictionary<int, Dictionary<int, float>> 
            TransformResourcesModelBonesWeightsToAnimatedPersoBoneWeightsExportModel(BoneWeight[] boneWeights)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<int, BoneBindPose> TransformResourcesModelBindPosesToAnimatedPersoBindBonePosesExportModel(Matrix4x4[] bindposes)
        {
            throw new NotImplementedException();
        }
    }
}
