namespace KOE.Leaflet2Blazor;

/// <summary>
/// Determines Icon's properties.
/// </summary>
public class IconOptions
{
    public IconOptions()
    {
    }

    public string? IconUrl { get; init; }
    public string? IconRetinaUrl { get; init; }
    public Point IconSize { get; init; } = new Point(0, 0);
    public Point IconAnchor { get; init; } = new Point(0, 0);
    public Point PopupAnchor { get; init; }= new Point(0, 0);
    public Point TooltipAnchor { get; init; } = new Point(0, 0);
    public string? ShadowUrl { get; init; }
    public string? ShadowRetinaUrl { get; init; }
    public Point ShadowSize { get; init; } = new Point(0, 0);
    public Point ShadowAnchor { get; init; } = new Point(0, 0);
    public string? ClassName { get; init; } = string.Empty;
}
