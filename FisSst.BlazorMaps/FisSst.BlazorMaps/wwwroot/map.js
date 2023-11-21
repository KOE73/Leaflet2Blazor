//import * as L from 'leaflet';

export function initialize(mapOptions) {
    const exInit = JSON.parse(mapOptions.exInit);
    const newMap = L.map(mapOptions.divId, exInit).setView(mapOptions.center, mapOptions.zoom);
    L.tileLayer(mapOptions.urlTileLayer, mapOptions.subOptions).addTo(newMap);
    return newMap;
}