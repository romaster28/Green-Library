using System;
using UnityEngine;

namespace GreenLibrary.UnityModel
{
    public interface IReadOnlyTransform
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        Vector3 Scale { get; }
        Vector3 Forward { get; }

        Vector3 Back { get; }
        Vector3 Left { get; }
        Vector3 Right { get; }
        Vector3 Up { get; }
        Vector3 Down { get; }

        Vector3 TranslateDirection(Vector3 direction);

        event Action<Vector3> PositionUpdated;
        event Action<Quaternion> RotationUpdated;
        event Action<Vector3> ScaleUpdated;
    }
}