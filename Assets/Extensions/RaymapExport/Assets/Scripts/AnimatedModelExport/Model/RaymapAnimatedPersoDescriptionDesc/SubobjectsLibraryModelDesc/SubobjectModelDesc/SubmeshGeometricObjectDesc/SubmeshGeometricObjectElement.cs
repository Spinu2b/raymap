using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc
{
    public class SubmeshGeometricObjectElement
    {
        public int id;
        public List<Vector3d> vertices;
        public List<Vector3d> normals;
        public List<Tuple<int, int, int>> triangles;
        public List<List<Vector2d>> uvMaps;
        public List<string> materials;

        public Dictionary<int, ChannelBindPose> bindChannelPoses;
        public Dictionary<int, Dictionary<int, float>> channelWeights;
    }
}
