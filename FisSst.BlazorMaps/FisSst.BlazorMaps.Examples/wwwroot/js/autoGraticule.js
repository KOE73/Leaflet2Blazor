//import * as L from '../leaflet/leaflet-src.js';
//import AutoGraticule from '../tsjs/L.AutoGraticule.js';

//import * as AG from '/tsjs/L.AutoGraticule.js';

export function AddAutoGraticule(map) {
    new L.AutoGraticule().addTo(map);
    //new AutoGraticule().addTo(map);
}