using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace KOE.Leaflet2Blazor.Examples.Pages;

public partial class Index: DemoBase
{

    private async Task GetCenterExample()
    {
        LatLng center = await this.mapRef.GetCenter();
        await this.JsRuntime.InvokeAsync<string>("alert", $"Map centered at: Lat: {center.Lat}, Lng: {center.Lng}");
    }
}
