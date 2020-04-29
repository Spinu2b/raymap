using Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils;
using Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc
{
    public class SubmeshGeometricObject : IExportModel, ISerializableToBytes, IHashableModel
    {
        public List<Vector3d> vertices = new List<Vector3d>();
        public List<Vector3d> normals = new List<Vector3d>();
        public List<int> triangles = new List<int>();
        public List<List<Vector2d>> uvMaps = new List<List<Vector2d>>();
        public List<string> materials = new List<string>();

        public Dictionary<int, BoneBindPose> bindBonePoses = new Dictionary<int, BoneBindPose>();
        public Dictionary<int, Dictionary<int, float>> boneWeights = new Dictionary<int, Dictionary<int, float>>();

        public string ComputeHash()
        {
            var bytes = SerializeToBytes();
            return BytesHashHelper.GetHashHexStringFor(bytes);
        }

        public byte[] SerializeToBytes()
        {
            return vertices.SelectMany(x => x.SerializeToBytes())
                .Concat(normals.SelectMany(x => x.SerializeToBytes()))
                .Concat(triangles.SelectMany(x => BitConverter.GetBytes(x)))
                .Concat(uvMaps.SelectMany(x => x.Select(y => y.SerializeToBytes())).SelectMany(x => x))
                .Concat(materials.SelectMany(x => Encoding.ASCII.GetBytes(x)))
                .Concat(bindBonePoses.Keys.OrderBy(x => x).SelectMany(x => BitConverter.GetBytes(x).Concat(bindBonePoses[x].SerializeToBytes())))
                .Concat(boneWeights.Keys
                    .OrderBy(x => x)
                    .SelectMany(x => boneWeights[x].Keys
                        .OrderBy(y => y)
                        .SelectMany(y => BitConverter.GetBytes(x).Concat(BitConverter.GetBytes(y)).Concat(BitConverter.GetBytes(boneWeights[x][y])))))
                .ToArray();
        }
    }
}
