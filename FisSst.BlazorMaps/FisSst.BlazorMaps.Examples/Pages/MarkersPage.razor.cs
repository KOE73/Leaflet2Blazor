namespace FisSst.BlazorMaps.Examples.Pages;

public partial class MarkersPage : DemoBase
{
    [Inject] private IMarkerFactory MarkerFactory { get; init; } = null!;
    [Inject] private IIconFactory IconFactory { get; init; } = null!;

    private Marker? markerWithOptions;
    private Marker? marker1;
    private Marker? marker2;
    private Marker? marker3;


    private async Task AddMarkers()
    {
        marker1 = await MarkerFactory.CreateAndAddToMap(LLPnt_01, mapRef);
        marker2 = await MarkerFactory.CreateAndAddToMap(LLPnt_02, mapRef);
        marker3 = await MarkerFactory.CreateAndAddToMap(LLPnt_03, mapRef);
    }

    private async Task RemoveMarkers()
    {
        if(marker1 is not null) { await marker1.Remove(); marker1 = null; }
        if(marker2 is not null) { await marker2.Remove(); marker2 = null; }
        if(marker3 is not null) { await marker3.Remove(); marker3 = null; }
    }

    private async Task AddMarkerWithOptions()
    {
        IconOptions iconOptions = new IconOptions()
        {
            IconUrl = @"images/leaf-green.png",
            IconSize = new Point(38, 95),
            IconAnchor = new Point(22, 94),
            ShadowUrl = @"images/leaf-shadow.png",
            ShadowSize = new Point(50, 64),
            ShadowAnchor = new Point(4, 61),
            PopupAnchor = new Point(-3, -76),
        };

        MarkerOptions markerOptions = new MarkerOptions()
        {
            Opacity = 0.5,
            Draggable = true,
            IconRef = await IconFactory.Create(iconOptions),
        };

        markerWithOptions = await MarkerFactory.CreateAndAddToMap(LLPnt_04, mapRef, markerOptions);
    }

    private async Task RemoveMarkerWithOptions()
    {
        if(markerWithOptions is not null) { await markerWithOptions.Remove(); markerWithOptions = null; }
    }
}
