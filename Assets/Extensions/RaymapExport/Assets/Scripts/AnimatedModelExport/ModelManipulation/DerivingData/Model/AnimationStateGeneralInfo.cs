using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.AnimationClipsModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model
{
    public class AnimationStateGeneralInfo
    {
        public int animationClipId;
        private PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper;

        private AnimationClipModel animationClipModel;
        private Dictionary<int, SubobjectModel> submeshesDescriptionSet;
        private ArmatureHierarchyModel armatureHierarchyParentingInfo;

        private Dictionary<string, Material> materials;
        private Dictionary<string, Texture> textures;
        private Dictionary<string, Image> images;


        public AnimationStateGeneralInfo(PersoBehaviourAnimationStatesHelper persoBehaviourAnimationStatesHelper)
        {
            this.persoBehaviourAnimationStatesHelper = persoBehaviourAnimationStatesHelper;
        }

        public void BuildData()
        {
            animationClipModel = new AnimationClipModelFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            animationClipId = animationClipModel.id;

            submeshesDescriptionSet = new SubmeshesDescriptionSetFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            armatureHierarchyParentingInfo = new ArmatureHierarchyModelFactory().DeriveFor(persoBehaviourAnimationStatesHelper);

            var materialsTexturesImages = new MaterialsTexturesImagesFactory().DeriveFor(persoBehaviourAnimationStatesHelper);
            materials = materialsTexturesImages.Item1;
            textures = materialsTexturesImages.Item2;
            images = materialsTexturesImages.Item3;
        }

        public Dictionary<string, Image> GetImages()
        {
            return images;
        }

        public Dictionary<string, Texture> GetTextures()
        {
            return textures;
        }

        public Dictionary<string, Material> GetMaterials()
        {
            return materials;
        }

        public AnimationClipModel GetAnimationClipObj()
        {
            return animationClipModel;
        }

        public Dictionary<int, SubobjectModel> GetSubmeshesDescriptionSet()
        {
            return submeshesDescriptionSet;
        }

        public ArmatureHierarchyModel GetArmatureHierarchyParentingInfo()
        {
            return armatureHierarchyParentingInfo;
        }
    }
}
