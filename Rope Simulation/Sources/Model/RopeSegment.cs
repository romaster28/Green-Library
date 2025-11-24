using UnityEngine;

namespace DR.RopeSimulation
{
    public struct RopeSegment
    {
        public Vector3 Position { get; set; }
        public Vector3 Old { get; set; }

        public RopeSegment(Vector3 position)
        {
            Position = position;
            Old = position;
        }
    }
}