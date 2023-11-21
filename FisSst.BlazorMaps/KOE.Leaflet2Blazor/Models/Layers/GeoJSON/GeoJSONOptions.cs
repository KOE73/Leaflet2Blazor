namespace KOE.Leaflet2Blazor;

/// <summary>
/// Determines InteractiveLayer's properties.
/// 
/// L.geoJSON(data, {
///     style: function(feature)
/// {
///     return { color: feature.properties.color};
/// }
/// })
/// </summary>
public class GeoJSONOptions : InteractiveLayerOptions
{
    public bool MarkersInheritOptions { get; init; } = false;

    // function(geoJsonPoint, latlng){return L.marker(latlng);}
    // pointToLayer function 


    // function (geoJsonFeature) {    return {} }
    // style function 

    // function (feature, layer) {}
    // onEachFeature	Function 

    // function (geoJsonFeature) {return true;}
    // filter	Function 

    // function (geoJsonFeature) {return true;}
    // coordsToLatLng	Function 


}
