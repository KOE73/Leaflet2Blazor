namespace FisSst.BlazorMaps;

/// <summary>
/// Determines Polyline's properties.
/// </summary>
public class PolylineOptions : PathOptions
{
    public double SmoothFactor { get; init; } = 1.0;
    public bool NoClip { get; init; } = false;
}
