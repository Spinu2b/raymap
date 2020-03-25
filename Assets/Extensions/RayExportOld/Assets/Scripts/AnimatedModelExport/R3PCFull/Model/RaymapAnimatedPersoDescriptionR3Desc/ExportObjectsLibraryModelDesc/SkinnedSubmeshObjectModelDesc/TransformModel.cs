using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.MathDescription;

namespace Assets.Extensions.RaymapExportOld.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc.SkinnedSubmeshObjectModelDesc
{
    public class TransformModel
    {
        public Vector3d position = new Vector3d(0.0f, 0.0f, 0.0f);
        public Quaternion rotation = new Quaternion(1.0f, 0.0f, 0.0f, 0.0f);
        public Vector3d scale = new Vector3d(1.0f, 1.0f, 1.0f);
        public Vector3d localPosition = new Vector3d(0.0f, 0.0f, 0.0f);
        public Quaternion localRotation = new Quaternion(1.0f, 0.0f, 0.0f, 0.0f);
        public Vector3d localScale = new Vector3d(1.0f, 1.0f, 1.0f);
    }
}
