using UnityEngine;

namespace DR.RopeSimulation
{
    public class RopeConfig : IRopeConfig
    {
        private readonly int _segments;
        private readonly float _segmentLength;
        private readonly float _damping;
        private readonly int _numOfConstraintRuns;
        private readonly Vector3 _gravity;

        public RopeConfig(int segments, float segmentLength, float damping, int numOfConstraintRuns, Vector3 gravity)
        {
            _segmentLength = segmentLength;
            _damping = damping;
            _numOfConstraintRuns = numOfConstraintRuns;
            _segments = segments;
            _gravity = gravity;
        }

        public int Segments => _segments;
        public float SegmentLength => _segmentLength;
        public float Damping => _damping;
        public int NumOfConstraintRuns => _numOfConstraintRuns;

        public Vector3 Gravity => _gravity;
    }
}