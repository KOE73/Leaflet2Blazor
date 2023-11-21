namespace KOE.Leaflet2Blazor;

// TODO есть куча методов и фабрика....
/// <summary>
/// Represents coordinates - latitude and longitude.
/// </summary>
public class LatLngBounds : JsReferenceBase
{
    internal LatLngBounds(IJSObjectReference jsReference) : base(jsReference) { }

    //public LatLng Corner1 { get; set; }
    //public LatLng Corner2 { get; set; }

    public async Task<LatLng> GetCenter() => await InvokeAsync<LatLng>("getCenter");
    public async Task<LatLng> GetSouthWest() => await InvokeAsync<LatLng>("getSouthWest");
    public async Task<LatLng> GetNorthEast() => await InvokeAsync<LatLng>("getNorthEast");
    public async Task<LatLng> GetNorthWest() => await InvokeAsync<LatLng>("getNorthWest");
    public async Task<LatLng> GetSouthEast() => await InvokeAsync<LatLng>("getSouthEast");
    public async Task<double> GetWest() => await InvokeAsync<double>("getWest");
    public async Task<double> GetSouth() => await InvokeAsync<double>("getSouth");
    public async Task<double> GetEast() => await InvokeAsync<double>("getEast");
    public async Task<double> GetNorth() => await InvokeAsync<double>("getNorth");
    public async Task<bool> Contains(LatLngBounds bounds) => await InvokeAsync<bool>("contains", bounds.JSReference);
    public async Task<bool> Contains(LatLng latLng) => await InvokeAsync<bool>("contains", latLng);
    public async Task<bool> Intersects(LatLngBounds bounds) => await InvokeAsync<bool>("intersects", bounds.JSReference);
    public async Task<bool> Overlaps(LatLngBounds bounds) => await InvokeAsync<bool>("overlaps", bounds.JSReference);
    public async Task<bool> Equals(LatLngBounds bounds) => await InvokeAsync<bool>("equals", bounds.JSReference);
    public async Task<bool> Equals(LatLngBounds bounds, double maxMargin) => await InvokeAsync<bool>("equals", bounds.JSReference, maxMargin);
    public async Task<bool> IsValid() => await InvokeAsync<bool>("isValid");
    public async Task<string> ToBBoxString() => await InvokeAsync<string>("toBBoxString");
}
