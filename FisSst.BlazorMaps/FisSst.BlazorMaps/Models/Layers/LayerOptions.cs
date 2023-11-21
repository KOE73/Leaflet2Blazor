namespace FisSst.BlazorMaps;

/// <summary>
/// Determines Layer's properties.
/// </summary>
public class LayerOptions
{
    public string Pane { get; init; } = "overlayPane";
    public string? Attribution { get; init; }
}
