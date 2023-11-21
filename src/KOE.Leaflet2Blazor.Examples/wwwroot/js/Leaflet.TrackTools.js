'use strict';

//import * as L from 'leaflet';
////import { LatLngBounds, LayerGroup, Util, Polyline, LatLng, marker, divIcon, latLngBounds } from 'leaflet';
//import * as L from 'leaflet';

(function (factory, window) {
    /*globals define, module, require*/

    // define an AMD module that relies on 'leaflet'
    if (typeof define === 'function' && define.amd) {
        define(['leaflet'], factory);

        // define a Common JS module that relies on 'leaflet'
    } else if (typeof exports === 'object') {
        module.exports = factory(require('leaflet'));
    }

    // attach your plugin to the global 'L' variable
    if (typeof window !== 'undefined' && window.L) {
        factory(window.L);
    }

}(function (L) {

    L.Tracks = L.Evented.extend({
        options: {

            // You can pass them when creating a map using the `editOptions` key.
            // 🍂option zIndex: int = 1000
            // The default zIndex of the editing tools.
            zIndex: 1000,

            // 🍂option drawingCSSClass: string = 'leaflet-editable-drawing'
            // CSS class to be added to the map container while drawing.
            drawingCSSClass: 'leaflet-editable-drawing',

            // 🍂option editLayer: Layer = new L.LayerGroup()
            // Layer used to store edit tools (vertex, line guide…).
            trackVertexLayer: undefined,

            // 🍂option featuresLayer: Layer = new L.LayerGroup()
            // Default layer used to store drawn features (Marker, Polyline…).
            featuresLayer: undefined,


            // 🍂option lineGuideOptions: hash = {}
            // Options to be passed to the line guides.
            lineGuideOptions: {},

        },



        initialize: function (map, options) {
            L.setOptions(this, options);
            this._lastZIndex = this.options.zIndex;
            this.map = map;
            this.trackVertexLayer = this.createTrackVertexLayer();
            //this.forwardLineGuide = this.createLineGuide();
            //this.featuresLayer = this.createFeaturesLayer();
            //this.backwardLineGuide = this.createLineGuide();
        },

        createTrackVertexLayer: function () {
            return this.options.trackVertexLayer || new L.LayerGroup().addTo(this.map);
        },

        createVertexIcon: function (options) {
            //return L.Browser.mobile && L.Browser.touch ? new L.Editable.TouchVertexIcon(options) : new L.Tracks.VertexIcon(options);
            return new L.Tracks.VertexIcon(options);
            //return new L.Tracks.VertexMarker(options);
        },

        createVertexMarker: function (latlng, latlngs) {
            //return new L.Tracks.VertexMarker(options);
            return new L.Tracks.VertexMarker(latlng, /*latlngs,*/ this);
        },
    });

    L.Map.mergeOptions({

        // 🍂namespace Map
        // 🍂section Map Options
        // 🍂option editToolsClass: class = L.Editable
        // Class to be used as vertex, for path editing.
        trackToolsClass: L.Tracks,

        // 🍂option editable: boolean = false
        // Whether to create a L.Editable instance at map init.
        track: true,

        // 🍂option editOptions: hash = {}
        // Options to pass to L.Editable when instantiating.
        trackOptions: {}

    });

    L.Map.addInitHook(function () {

        this.whenReady(function () {
            if (this.options.track) {
                this.tracksTool = new this.options.trackToolsClass(this, this.options.trackOptions);
            }
        });
    });

    L.Tracks.VertexIcon = L.DivIcon.extend({

        options: {
            iconSize: new L.Point(8, 8)//,
            //className:"leaflet-track-icon leaflet-div-icon"
        }
    });

    L.Tracks.VertexMarker = L.Marker.extend({

        options: {
            draggable: true,
            className: 'leaflet-div-icon leaflet-track-icon'
        },
        initialize: function (latlng, /*latlngs,*/ track, options) {
            // We don't use this._latlng, because on drag Leaflet replace it while
            // we want to keep reference.
            //this.latlng = latlng;
            //this.latlngs = latlngs;
            this.trackTools = track;
            L.Marker.prototype.initialize.call(this, latlng, options);
            //this.options.icon = this.editor.tools.createVertexIcon({ className: this.options.className });
            this.options.icon = this.trackTools.createVertexIcon({ className: this.options.className });
            //this.latlng.__vertex = this;
            this.trackTools.trackVertexLayer.addLayer(this);
            //this.setZIndexOffset(editor.tools._lastZIndex + 1);
        },
    });

}, window));



//L.tracksTool = new L.Tracks();
//}
