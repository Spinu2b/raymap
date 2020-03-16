using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model
{
    public class SkinnedSubmeshesSet
    {
        private HashSet<SkinnedSubmeshObjectModel> submeshesSet = new HashSet<SkinnedSubmeshObjectModel>();

        public IEnumerable<SkinnedSubmeshObjectModel> IterateSubmeshes()
        {
            foreach (var submesh in submeshesSet)
            {
                yield return submesh;
            }
        }

        public void Consolidate(SkinnedSubmeshesSet other)
        {
            throw new NotImplementedException();
        }

        public void Add(SkinnedSubmeshObjectModel skinnedSubmeshObject)
        {
            submeshesSet.Add(skinnedSubmeshObject);
        }
    }
}
