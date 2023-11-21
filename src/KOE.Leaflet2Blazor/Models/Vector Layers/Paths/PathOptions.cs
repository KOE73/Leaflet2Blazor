namespace KOE.Leaflet2Blazor;

/// <summary>
/// Determines Path's properties.
/// </summary>
public class PathOptions : InteractiveLayerOptions
{
    public PathOptions()
    {
        BubblingMouseEvents = true;
        Interactive = true;
        Pane = DefaultPane;
    }

    private const string DefaultPane = "overlayPane";

    public bool Stroke { get; init; }= true;
    public string Color { get; init; }= "#3388ff";
    public int Weight { get; init; }= 3;
    public double Opacity { get; init; } = 1.0;
    public string LineCap { get; init; }= "round";
    public string LineJoin { get; init; } = "round";
    public string? DashArray { get; init; }
    public string? DashOffset { get; init; }
    public bool Fill { get; init; } = false;
    public string? FillColor { get; init; }
    public double FillOpacity { get; init; }= 0.2;
    public string FillRule { get; init; }= "evenodd";
    public string? ClassName { get; init; }
}
