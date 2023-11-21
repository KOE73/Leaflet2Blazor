namespace KOE.Leaflet2Blazor.Examples.Pages;

public partial class DemoBase : ComponentBase
{
    [Inject] protected IJSRuntime JsRuntime { get; init; }
    [Inject] protected ILatLngBoundsFactory LatLngBoundsFactory { get; init; } = null!;


    protected static double Lat = 52.31172719082248;
    protected static double Lng = 4.726867675781251;

    protected readonly LatLng center = new LatLng(Lat, Lng);

    //protected readonly LatLng LatLng01 = new LatLng(Lat + 0.004324, Lng + 0.004683);
    //protected readonly LatLng LatLng02 = new LatLng(Lat + 0.005495, Lng + 0.001064);
    //protected readonly LatLng LatLng03 = new LatLng(Lat + 0.006061, Lng + 0.007469);
    //protected readonly LatLng LatLng04 = new LatLng(Lat + 0.009103, Lng + 0.005534);
    //protected readonly LatLng LatLng05 = new LatLng(Lat + 0.008534, Lng + 0.003535);
    //protected readonly LatLng LatLng06 = new LatLng(Lat + 0.008235, Lng + 0.005198);
    //protected readonly LatLng LatLng07 = new LatLng(Lat + 0.003202, Lng + 0.005697);
    //protected readonly LatLng LatLng08 = new LatLng(Lat + 0.000545, Lng + 0.004743);
    //protected readonly LatLng LatLng09 = new LatLng(Lat + 0.007532, Lng + 0.005791);
    //protected readonly LatLng LatLng10 = new LatLng(Lat + 0.005247, Lng + 0.009297);
    //protected readonly LatLng LatLng11 = new LatLng(Lat + 0.008249, Lng + 0.000836);
    //protected readonly LatLng LatLng12 = new LatLng(Lat + 0.004129, Lng + 0.005537);
    //protected readonly LatLng LatLng13 = new LatLng(Lat + 0.004403, Lng + 0.003286);
    //protected readonly LatLng LatLng14 = new LatLng(Lat + 0.009150, Lng + 0.003894);
    //protected readonly LatLng LatLng15 = new LatLng(Lat + 0.006159, Lng + 0.009046);
    //protected readonly LatLng LatLng16 = new LatLng(Lat + 0.000142, Lng + 0.001009);
    //protected readonly LatLng LatLng17 = new LatLng(Lat + 0.003766, Lng + 0.005137);
    //protected readonly LatLng LatLng18 = new LatLng(Lat + 0.003783, Lng + 0.004827);

    // 4 corner
    protected readonly LatLng LLPol_01 = new LatLng(52.332829320672, 4.73630905151367);
    protected readonly LatLng LLPol_02 = new LatLng(52.330836218841, 4.74351882934570);
    protected readonly LatLng LLPol_03 = new LatLng(52.295462231849, 4.73579406738281);
    protected readonly LatLng LLPol_04 = new LatLng(52.295672204013, 4.73012924194336);

    // 3 point
    protected readonly LatLng LLPol_11 = new LatLng(52.314145856449, 4.74952697753906);
    protected readonly LatLng LLPol_12 = new LatLng(52.315090324706, 4.77716445922851);
    protected readonly LatLng LLPol_13 = new LatLng(52.287587557131, 4.77527618408203); 

    // Markers / Cirkles
    protected readonly LatLng LLPnt_01 = new LatLng(52.304385170954, 4.75313186645507);
    protected readonly LatLng LLPnt_02 = new LatLng(52.325897804075, 4.73716735839843);
    protected readonly LatLng LLPnt_03 = new LatLng(52.313096423637, 4.71502304077148);
    protected readonly LatLng LLPnt_04 = new LatLng(52.324533898829, 4.78042602539062);

    // Big sqare 1
    protected readonly LatLng LLSqa_01 = new LatLng(52.323747011291, 4.69828605651855);
    protected readonly LatLng LLSqa_02 = new LatLng(52.308845966296, 4.72867012023925);

    // Big sqare 2
    protected readonly LatLng LLSqa_11 = new LatLng(52.346351337571, 4.71287727355957);
    protected readonly LatLng LLSqa_12 = new LatLng(52.334395035787, 4.74695205688476);

    protected readonly LatLng LatLng16 = new LatLng(Lat + 0.000142, Lng + 0.001009);
    protected readonly LatLng LatLng17 = new LatLng(Lat + 0.003766, Lng + 0.005137);
    protected readonly LatLng LatLng18 = new LatLng(Lat + 0.003783, Lng + 0.004827);



    protected Map mapRef;
    protected MapOptions mapOptions;

    public DemoBase()
    {
        mapOptions = MakeOptions();
    }

    protected virtual MapOptions MakeOptions()
    {
        return new MapOptions()
        {
            DivId = "mapId",
            Center = center,
            Zoom = 13,
            UrlTileLayer = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
            ExInit = """{"editable": true}""",
            SubOptions = new MapSubOptions()
            {
                Attribution = "&copy; <a lhref='http://www.openstreetmap.org/copyright'>OpenStreetMap</a>",
                MaxZoom = 18,
                TileSize = 512,
                ZoomOffset = -1,
            }
        };
    }


    protected async Task GetCenterExample()
    {
        LatLng center = await mapRef.GetCenter();
        await JsRuntime.InvokeAsync<string>("alert", $"Map centered at: Lat: {center.Lat}, Lng: {center.Lng}");
    }
}
