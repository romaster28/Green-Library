using UnityEngine;

namespace DR.RopeSimulation
{
    public interface IRopeConfig
    {
        int Segments { get; }
        float SegmentLength { get; }
        float Damping { get; }
        int NumOfConstraintRuns { get; }
        Vector3 Gravity { get; }
    }
}