using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace FisSst.BlazorMaps;

/// <summary>
/// Determines Marker's properties.
/// </summary>
public class MarkerOptions : InteractiveLayerOptions
{
    public MarkerOptions()
    {
        // from InteractiveLayerOptions
        BubblingMouseEvents = false;

        // from LayerOptions
        Pane = DefaultPane;
    }

    const string DefaultPane = "markerPane";
    Icon iconRef;

    [JsonIgnore]
    public Icon IconRef
    {
        get
        {
            return iconRef;
        }
        init
        {
            iconRef = value;
            if(value != null)
            {
                Icon = iconRef.JSReference;
            }
            else
            {
                Icon = null;
            }
        }
    }
    public IJSObjectReference? Icon { get; init; }
    public bool Keyboard { get; init; } = true;
    public string Title { get; init; } = string.Empty;
    public string Alt { get; init; } = string.Empty;
    public int ZIndexOffset { get; init; } = 0;
    public double Opacity { get; init; } = 1;
    public bool RiseOnHover { get; init; } = false;
    public int RiseOffset { get; init; } = 250;
    public string ShadowPane { get; init; } = "shadowPane";
    public bool Draggable { get; init; }
    public bool AutoPan { get; init; }
    public Point AutoPanPadding { get; init; }
    public int AutoPanSpeed { get; init; }
}
