using UnityEngine;

namespace OpenSpace.Collide {
    /// <summary>
    /// Elements of a geometric object
    /// </summary>
    public interface IGeometricObjectElementCollide {
        GameObject Gao { get; }
        IGeometricObjectElementCollide Clone(GeometricObjectCollide mesh);
        IGeometricObjectElementCollide CloneWithMockedUnityApi(GeometricObjectCollide mesh);
        GameMaterial GetMaterial(int? index);
    }
}
