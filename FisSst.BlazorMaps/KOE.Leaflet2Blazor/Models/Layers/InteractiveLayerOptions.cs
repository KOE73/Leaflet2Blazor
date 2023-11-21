namespace KOE.Leaflet2Blazor;

/// <summary>
/// Determines InteractiveLayer's properties.
/// </summary>
public class InteractiveLayerOptions : LayerOptions
{
    public bool Interactive { get; init; } = true;
    public bool BubblingMouseEvents { get; init; } = true;
}
