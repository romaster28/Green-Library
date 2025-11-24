using System;
using UnityEngine;

namespace DR.RopeSimulation
{
    [Serializable]
    public class RopeConfigSerializable : IRopeConfig
    {
        [SerializeField] private int _segments = 25;
        [SerializeField] private float _segmentLength = 1;
        [SerializeField] private float _damping = .3F;
        [SerializeField] private int _numOfConstraintRuns = 10;
        [SerializeField] private Vector3 _gravity = new Vector3(0, -9.81f, 0);

        public int Segments => _segments;
        public float SegmentLength => _segmentLength;
        public float Damping => _damping;
        public int NumOfConstraintRuns => _numOfConstraintRuns;
        public Vector3 Gravity => _gravity;
    }
}