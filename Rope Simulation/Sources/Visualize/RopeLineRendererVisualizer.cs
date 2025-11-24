using System;
using UnityEngine;

namespace DR.RopeSimulation.Example
{
    [RequireComponent(typeof(LineRenderer))]
    public class RopeLineRendererVisualizer : MonoBehaviour
    {
        private RopeSimulation _simulation;
        private LineRenderer _renderer;

        public void SetRope(RopeSimulation ropeSimulation)
        {
            _simulation = ropeSimulation ?? throw new ArgumentNullException(nameof(ropeSimulation));
        }

        private void Awake()
        {
            _renderer = GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            _simulation?.Simulate();
        }

        private void LateUpdate()
        {
            if (_renderer == null)
                return;

            if (_simulation == null)
                return;

            _renderer.positionCount = _simulation.SegmentsCount;

            int index = 0;

            foreach (var segment in _simulation.GetSegments())
            {
                _renderer.SetPosition(index, segment);
                index++;
            }
        }
    }
}