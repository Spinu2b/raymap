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
        public List<Vector3d> vertices = new List<Vector3d>();
        public List<Vector3d> normals = new List<Vector3d>();
        public List<int> triangles = new List<int>();
        public List<List<Vector2d>> uvMaps = new List<List<Vector2d>>();
        public List<string> materials = new List<string>();

        public Dictionary<int, ChannelBindPose> bindChannelPoses = new Dictionary<int, ChannelBindPose>();
        public Dictionary<int, Dictionary<int, float>> channelWeights = new Dictionary<int, Dictionary<int, float>>();
    }
}
