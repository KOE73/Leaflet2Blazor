namespace KOE.Leaflet2Blazor;

/// <summary>
/// Determines Circle's properties.
/// </summary>
public class CircleOptions : PathOptions
{
    public CircleOptions()
    {
        Fill = true;
    }

    public double Radius { get; init; } = 10;
}
