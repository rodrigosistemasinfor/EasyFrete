import { Draw } from "ol/interaction";
import { Component, OnInit } from "@angular/core";
import Map from "ol/Map";
import View from "ol/View";
import VectorLayer from "ol/layer/Vector";
import Style from "ol/style/Style";
import Icon from "ol/style/Icon";
import OSM from "ol/source/OSM";
import * as olProj from "ol/proj";
import TileLayer from "ol/layer/Tile";
import GeometryType from "ol/geom/GeometryType";
import VectorSource from "ol/source/Vector";
import Fill from "ol/style/Fill";
import Stroke from "ol/style/Stroke";
declare const ContextMenu: any;

@Component({
  templateUrl: "./lojas.component.html",
  styleUrls: ["./lojas.component.css"],
})
export class LojasComponent implements OnInit {
  constructor() {}
  map: any;
  draw: any;
  vectorSource: any;
  vectorLayer: any;

  ngOnInit(): void {
    this.vectorSource = new VectorSource();
    this.vectorLayer = new VectorLayer({
      source: this.vectorSource,
      style: new Style({
        fill: new Fill({
          color: "rgba(255, 255, 255, 0.2)",
        }),
        stroke: new Stroke({
          color: "#0066ff",
          width: 2,
        }),
      }),
    });

    this.map = new Map({
      target: "map",
      layers: [
        new TileLayer({
          source: new OSM(),
        }),
      ].concat([this.vectorLayer]),
      view: new View({
        center: olProj.fromLonLat([-38.531187, -3.732015]),
        zoom: 15,
      }),
    });
  }

  addInteraction() {
    this.draw = new Draw({
      source: this.vectorSource,
      type: "Circle" as GeometryType,
    });
    this.map.addInteraction(this.draw);
  }
}
