﻿using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.ModelManipulation.DerivingData.ModelConstructing.MaterialsData
{
    public static class MaterialModelFactory
    {
        public static AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material
            GetMaterialModel(UnityEngine.Material unityMaterial, List<string> materialTextureNames, List<string> textureHashes = null)
        {
            var result = new AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.Material();
            if (textureHashes != null && textureHashes.Count > 0)
            {
                result.textures = textureHashes.ToList();
            }
            else
            {
                result.textures = SubmeshGameObjectMaterialsDataFetchingHelper.
                    IterateTextures2DOfMaterial(unityMaterial, materialTextureNames).Select(x => TextureModelFactory.GetTextureModel(x).name).ToList();
            }
            result.name = ComputeMaterialHash(result.textures);
            return result;
        }

        private static string ComputeMaterialHash(List<string> textureHashes)
        {
            byte[] textureHashesBytes = textureHashes.Select(x => Encoding.ASCII.GetBytes(x)).SelectMany(x => x).ToArray();
            return BytesHashHelper.GetHashHexStringFor(textureHashesBytes);
        }
    }
}
