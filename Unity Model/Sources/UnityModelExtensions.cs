using UnityEngine;

namespace GreenLibrary.UnityModel
{
    public static class UnityModelExtensions
    {
        public static TransformModel ToModel(this Transform transform)
        {
            return new TransformModel(transform);
        }
    }
}