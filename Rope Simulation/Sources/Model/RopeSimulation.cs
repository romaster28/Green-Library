using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenLibrary.RopeSimulation
{
    public class RopeSimulation
    {
        private readonly IRopeConfig _config;
        private readonly Vector3[] _segments;
        private readonly Vector3[] _old;
        private readonly bool[] _blocked;

        public RopeSimulation(IRopeConfig config, Vector3 startPos)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _segments = new Vector3[config.Segments];
            _old = new Vector3[config.Segments];
            _blocked = new bool[config.Segments];

            for (int i = 0; i < config.Segments; i++)
            {
                _segments[i] = startPos;
                _old[i] = startPos;
            }
        }

        public IEnumerable<Vector3> GetSegments() => _segments;
        public int SegmentsCount => _segments.Length;

        public Vector3 GetSegment(int index)
        {
            return _segments[index];
        }

        public void BlockSegment(int segment, Vector3 position)
        {
            if (segment < 0 || segment >= _segments.Length)
                throw new ArgumentOutOfRangeException(nameof(segment));

            _segments[segment] = position;
            _old[segment] = position;
            _blocked[segment] = true;
        }

        public void ReleaseSegment(int segment)
        {
            if (segment < 0 || segment >= _segments.Length)
                throw new ArgumentOutOfRangeException(nameof(segment));

            _blocked[segment] = false;
        }

        /// <summary>
        /// Simulating, fixed update
        /// </summary>
        public void Simulate()
        {
            for (int i = 0; i < _segments.Length; i++)
            {
                if (_blocked[i])
                    continue;

                Vector3 segment = _segments[i];
                Vector3 old = _old[i];
                Vector3 velocity = (segment - old) * _config.Damping;

                old = segment;
                segment += velocity;
                segment += _config.Gravity * Time.fixedDeltaTime;
                _segments[i] = segment;
                _old[i] = old;
            }

            for (int i = 0; i < _config.NumOfConstraintRuns; i++)
                ApplyConstraints();
        }

        private void ApplyConstraints()
        {
            for (int i = 0; i < _segments.Length - 1; i++)
            {
                if (_blocked[i] && _blocked[i + 1])
                    continue;

                Vector3 current = _segments[i];
                Vector3 next = _segments[i + 1];

                float distance = (current - next).magnitude;
                float difference = distance - _config.SegmentLength;

                Vector3 changeDirection = (current - next).normalized;
                Vector3 change = changeDirection * difference;

                if (_blocked[i])
                {
                    next += change;
                }
                else if (_blocked[i + 1])
                {
                    current -= change;
                }
                else
                {
                    current -= change / 2;
                    next += change / 2;
                }

                _segments[i] = current;
                _segments[i + 1] = next;
            }
        }
    }
}