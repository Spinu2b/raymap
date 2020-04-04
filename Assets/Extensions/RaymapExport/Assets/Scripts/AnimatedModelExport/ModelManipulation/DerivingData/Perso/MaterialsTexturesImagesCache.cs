using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.Perso
{
    public class MaterialsTexturesImagesCache
    {
        private Dictionary<string, Material> materialsCache = new Dictionary<string, Material>();
        private Dictionary<string, Texture> texturesCache = new Dictionary<string, Texture>();
        private Dictionary<string, Image> imagesCache = new Dictionary<string, Image>();

        private Dictionary<int, Dictionary<int, Dictionary<int, List<string>>>> materialsSubobjectNumberAnimationFramesPersoStatesAssociationsCache
             = new Dictionary<int, Dictionary<int, Dictionary<int, List<string>>>>();
        private Dictionary<int, Dictionary<int, Dictionary<int, List<string>>>> texturesSubobjectNumberAnimationFramesPersoStatesAssociationsCache
             = new Dictionary<int, Dictionary<int, Dictionary<int, List<string>>>>();
        private Dictionary<int, Dictionary<int, Dictionary<int, List<string>>>> imagesSubobjectNumberAnimationFramesPersoStatesAssociationsCache
             = new Dictionary<int, Dictionary<int, Dictionary<int, List<string>>>>();

        private Dictionary<int, List<string>> subobjectNumberMaterialAssociationsCache = new Dictionary<int, List<string>>();
        private Dictionary<int, List<string>> subobjectNumberTextureAssociationsCache = new Dictionary<int, List<string>>();
        private Dictionary<int, List<string>> subobjectNumberImagesAssociationsCache = new Dictionary<int, List<string>>();

        public void ConsiderPhysicalObject(PhysicalObjectWrapper physicalObject,
            int stateIndex, int animationFrame, int channelId, int physicalObjectNumber)
        {
            var materialsTexturesImages = physicalObject.GetMaterialsTexturesImages();

            ConsiderMaterials(materialsTexturesImages.Item1, stateIndex, animationFrame, physicalObjectNumber);
            ConsiderTextures(materialsTexturesImages.Item2, stateIndex, animationFrame, physicalObjectNumber);
            ConsiderImages(materialsTexturesImages.Item3, stateIndex, animationFrame, physicalObjectNumber);
        }

        private void ConsiderImages(Dictionary<string, Image> images, int stateIndex, int animationFrame, int physicalObjectNumber)
        {
            throw new NotImplementedException();
        }

        private void ConsiderTextures(Dictionary<string, Texture> textures, int stateIndex, int animationFrame, int physicalObjectNumber)
        {
            throw new NotImplementedException();
        }

        private void ConsiderMaterials(Dictionary<string, Material> materials, int stateIndex, int animationFrame, int physicalObjectNumber)
        {
            throw new NotImplementedException();
        }

        public Tuple<Dictionary<string, Material>, Dictionary<string, Texture>, Dictionary<string, Image>>
            GetMaterialsTexturesImagesCachedModelFor(int physicalObjectNumber)
        {
            throw new NotImplementedException();
        }
    }
}
