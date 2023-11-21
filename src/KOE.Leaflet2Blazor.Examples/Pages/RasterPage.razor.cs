using Microsoft.VisualBasic;

namespace KOE.Leaflet2Blazor.Examples.Pages;

public partial class RasterPage : DemoBase
{
    [Inject] private IImageOverlayFactory ImageOverlayFactory { get; init; } = null!;


    string ImageUrl = @"images/tractor.jpg";

    ImageOverlay? ImageOverlay1;
    ImageOverlay? ImageOverlayWithOptions;


    private async Task AddImageOverlays()
    {
        var bounds = await LatLngBoundsFactory.Create(LLSqa_01, LLSqa_02);

        var c =await bounds.GetCenter();
        var SouthWest =await bounds.GetSouthWest();
        var NorthEast =await bounds.GetNorthEast();
        var NorthWest =await bounds.GetNorthWest();
        var SouthEast = await bounds.GetSouthEast();

        ImageOverlay1 = await ImageOverlayFactory.CreateAndAddToMap(ImageUrl, bounds, mapRef);
    }

    private async Task RemoveImageOverlays()
    {
        await ImageOverlay1.Remove();
    }

    private async Task AddImageOverlayWithOptions()
    {

        ImageOverlayOptions ImageOverlayOptions = new ImageOverlayOptions()
        {
            Opacity = 0.5,
            //Draggable = true,
            //IconRef = await IconFactory.Create(iconOptions),
        };
        var bounds = await LatLngBoundsFactory.Create(LLSqa_11, LLSqa_12);

        ImageOverlayWithOptions = await ImageOverlayFactory.CreateAndAddToMap(ImageUrl, bounds , mapRef, ImageOverlayOptions);
    }

    private async Task RemoveImageOverlayWithOptions()
    {
        await ImageOverlayWithOptions.Remove();
    }
}
