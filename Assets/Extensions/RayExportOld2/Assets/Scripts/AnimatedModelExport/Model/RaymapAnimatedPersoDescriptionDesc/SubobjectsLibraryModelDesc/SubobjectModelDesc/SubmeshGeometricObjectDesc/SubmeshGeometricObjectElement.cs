using Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.MathDescription;
using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils;
using Assets.Extensions.RayExportOld2.Assets.Scripts.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.AnimatedModelExport.Model.RaymapAnimatedPersoDescriptionDesc.SubobjectsLibraryModelDesc.SubobjectModelDesc.SubmeshGeometricObjectDesc
{
    public class SubmeshGeometricObjectElementDescription : ISerializableToBytes, IHashableModel
    {
        public List<Vector3d> vertices = new List<Vector3d>();
        public List<Vector3d> normals = new List<Vector3d>();
        public List<int> triangles = new List<int>();
        public List<List<Vector2d>> uvMaps = new List<List<Vector2d>>();
        public List<string> materials = new List<string>();

        public Dictionary<int, ChannelBindPose> bindChannelPoses = new Dictionary<int, ChannelBindPose>();
        public Dictionary<int, Dictionary<int, float>> channelWeights = new Dictionary<int, Dictionary<int, float>>();

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
                .Concat(bindChannelPoses.Keys.OrderBy(x => x).SelectMany(x => BitConverter.GetBytes(x).Concat(bindChannelPoses[x].SerializeToBytes())))
                .Concat(channelWeights.Keys
                    .OrderBy(x => x)
                    .SelectMany(x => channelWeights[x].Keys
                        .OrderBy(y => y)
                        .SelectMany(y => BitConverter.GetBytes(x).Concat(BitConverter.GetBytes(y)).Concat(BitConverter.GetBytes(channelWeights[x][y])))))
                .ToArray();
        }
    }

    public class SubmeshGeometricObjectElement : IComparableModel<SubmeshGeometricObjectElement>
    {
        public int id;
        public string elementDescriptionHash;
        public SubmeshGeometricObjectElementDescription elementDescription = new SubmeshGeometricObjectElementDescription();

        public bool EqualsToAnother(SubmeshGeometricObjectElement other)
        {
            return (id == other.id) && elementDescriptionHash.Equals(other.elementDescriptionHash);
        }
    }
}
