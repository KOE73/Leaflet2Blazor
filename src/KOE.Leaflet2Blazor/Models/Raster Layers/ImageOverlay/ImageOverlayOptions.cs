namespace KOE.Leaflet2Blazor;

/// <summary>
/// Determines ImageOverlay's properties.
/// </summary>
public class ImageOverlayOptions : InteractiveLayerOptions
{
    public double Opacity { get; init; } = 1.0;
    public string Alt { get; init; } = string.Empty;
    public String CrossOrigin { get; init; } = "false";
    public string ErrorOverlayUrl { get; init; } = string.Empty;
    public int ZIndex { get; init; } = 1;
    public string ClassName { get; init; } = string.Empty;
}
