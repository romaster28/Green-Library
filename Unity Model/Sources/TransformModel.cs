using System;
using UnityEngine;

public class TransformModel : IReadOnlyTransform
{
    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _scale = Vector3.one;

    public TransformModel(Vector3 position)
    {
        Position = position;
    }

    public TransformModel(Vector3 position, Quaternion rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    public TransformModel(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }

    public TransformModel(Transform transform)
    {
        Position = transform.position;
        Rotation = transform.rotation;
        Scale = transform.localScale;
    }

    public Vector3 Position
    {
        get => _position;
        set
        {
            _position = value;
            PositionUpdated?.Invoke(value);
        }
    }

    public Quaternion Rotation
    {
        get => _rotation;
        set
        {
            _rotation = value;
            RotationUpdated?.Invoke(value);
        }
    }

    public Vector3 Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            ScaleUpdated?.Invoke(value);
        }
    }
    
    public Vector3 Forward => TranslateDirection(Vector3.forward);
    public Vector3 Back => TranslateDirection(Vector3.back);
    public Vector3 Left => TranslateDirection(Vector3.left);
    public Vector3 Right => TranslateDirection(Vector3.right);
    public Vector3 Up => TranslateDirection(Vector3.up);
    public Vector3 Down => TranslateDirection(Vector3.down);

    public Vector3 TranslateDirection(Vector3 direction)
    {
        return _rotation * direction;
    }

    public event Action<Vector3> PositionUpdated;
    public event Action<Quaternion> RotationUpdated;
    public event Action<Vector3> ScaleUpdated;

    public void Rotate(float angle)
    {
        Rotation = Quaternion.AngleAxis(angle, Up);
    }
}