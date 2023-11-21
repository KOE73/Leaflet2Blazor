namespace FisSst.BlazorMaps.Examples.Pages;

public partial class PopupsPage: DemoBase
{
    bool firstRender = true;
    Marker marker1 = null!;
    Marker marker2 = null!;

    [Inject]
    private IMarkerFactory MarkerFactory { get; init; }

    protected async Task AddMarkers()
    {
        if (firstRender)
        {
            firstRender = false;
            marker1 = await MarkerFactory.CreateAndAddToMap(LLPnt_01, mapRef);
            marker2 = await MarkerFactory.CreateAndAddToMap(LLPnt_02, mapRef);
        }
    }

    async Task BindPopup() => await marker1.BindPopup("Hi! This is a popup");

    async Task BindTooltip() => await marker2.BindTooltip("And this is a tooltip");

    async Task RemovePopup() => await marker1.UnbindPopup();

    async Task RemoveTooltip() => await marker2.UnbindTooltip();

    async Task UpdatePopup() => await marker1.SetPopupContent("Popup has changed its content");

    async Task UpdateTooltip() => await marker2.SetTooltipContent("Tooltip has changed its content");

    async Task TogglePopup() => await marker1.TogglePopup();

    async Task ToggleTooltip() => await marker2.ToggleTooltip();
}
