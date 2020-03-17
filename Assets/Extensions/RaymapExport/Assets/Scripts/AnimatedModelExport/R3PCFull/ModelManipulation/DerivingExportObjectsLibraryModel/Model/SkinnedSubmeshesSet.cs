using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.Model.RaymapAnimatedPersoDescriptionR3Desc.ExportObjectsLibraryModelDesc;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.R3PCFull.ModelManipulation.DerivingExportObjectsLibraryModel.Model
{
    public class SkinnedSubmeshComparator
    {
        public static bool NameCompliant(SkinnedSubmeshObjectModel submeshA, SkinnedSubmeshObjectModel submeshB)
        {
            return submeshA.name.Equals(submeshB.name);
        }

        public static bool MeshGeometryAndBindPosesCompliant(SkinnedSubmeshObjectModel submeshA, SkinnedSubmeshObjectModel submeshB)
        {
            return submeshA.CompliantToWithMeshGeometryAndBindPoses(submeshB);
        }

        public static bool MaterialsCompliant(SkinnedSubmeshObjectModel submeshA, SkinnedSubmeshObjectModel submeshB)
        {
            return submeshA.materials.GetHashCode().Equals(submeshB.materials.GetHashCode());
        }
    }

    public class SkinnedSubmeshesSet
    {
        private HashSet<SkinnedSubmeshObjectModel> submeshesSet = new HashSet<SkinnedSubmeshObjectModel>();
        private HashSet<string> bonesSoFarUsedInSkinning = new HashSet<string>();

        public IEnumerable<SkinnedSubmeshObjectModel> IterateSubmeshes()
        {
            foreach (var submesh in submeshesSet)
            {
                yield return submesh;
            }
        }

        public void Consolidate(SkinnedSubmeshesSet other)
        {
            foreach (var submeshToConsider in other.IterateSubmeshes())
            {
                if (!FoundCompliantSubmesh(submeshToConsider))
                {
                    Add(submeshToConsider);
                }
            }
        }

        private bool FoundCompliantSubmesh(SkinnedSubmeshObjectModel submeshToConsider)
        {
            foreach (var submesh in submeshesSet)
            {
                bool nameCompliant = SkinnedSubmeshComparator.NameCompliant(submesh, submeshToConsider);
                bool meshGeometryAndBindPosesCompliant = SkinnedSubmeshComparator.MeshGeometryAndBindPosesCompliant(submesh, submeshToConsider);
                bool materialsCompliant = SkinnedSubmeshComparator.MaterialsCompliant(submesh, submeshToConsider);

                // don't care about materials, it is effectively matter of changing texture in this case, overall appearance, not that important
                // as geometry itself
                if (!nameCompliant && meshGeometryAndBindPosesCompliant)
                {
                    throw new InvalidOperationException("Submeshes have effectively same geometry and skinning info, yet they have different names!");
                } 
                else if (nameCompliant && !meshGeometryAndBindPosesCompliant)
                {
                    throw new InvalidOperationException("Submeshes have the same name yet they are not the same in terms of general geometry model description!");
                }
                else if (nameCompliant && meshGeometryAndBindPosesCompliant)
                {
                    return true;
                }

                var submeshSkinningBonesSet = submesh.GetBonesNamesUsedForSkinningSet();
                var submeshToConsiderSkinningBonesSet = submesh.GetBonesNamesUsedForSkinningSet();

                submeshSkinningBonesSet.IntersectWith(submeshToConsiderSkinningBonesSet);

                if (submeshSkinningBonesSet.Count != 0)
                {
                    // Let's try actually supporting this since it seems inevitable
                    // There will be needed some tweaks related to positioning submeshes later when importing to Blender
                    // due to the matters related to miscellaneous bind poses of same bones for different submeshes
                    // Skinning, vertex groups itd should not matter, because its just matter of mapping weights to vertices of respective submesh and thats it
                    //throw new InvalidOperationException("Submeshes aren't fully compliant in geometry-description terms," +
                    //    " but they share some common skinning bones which is not supported now!");
                }                
            }
            return false;
        }

        public void Add(SkinnedSubmeshObjectModel skinnedSubmeshObject)
        {
            submeshesSet.Add(skinnedSubmeshObject);
            bonesSoFarUsedInSkinning.UnionWith(skinnedSubmeshObject.GetBonesNamesUsedForSkinningSet());
        }
    }
}
