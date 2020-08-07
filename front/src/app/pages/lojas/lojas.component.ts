import { RaioPreco } from "./../../model/raio-preco.model";
declare const ol: any;
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
import { FullScreen, defaults as defaultControls } from "ol/control";
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
  arrayRadius: RaioPreco[] = [];

  ngOnInit(): void {
    this.configureMap();
  }

  private drawEnd(event) {
    const drawType = event.target.mode_;
    const feature = event.feature.getGeometry();
    let draw = this.getDraw(drawType, feature);
    this.arrayRadius.push({
      Lat: draw.value.coord[1],
      Long: draw.value.coord[0],
      Raio: draw.value.radius,
    } as RaioPreco);
    console.log(this.getDraw(drawType, feature).raius);
  }

  private configureMap() {
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
      controls: defaultControls().extend([
        new FullScreen({
          source: "fullscreen",
        }),
      ]),
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
    this.draw.on("drawend", (event) => {
      this.drawEnd(event);
    });
  }

  private transformCoordinate(coordinate: any): any[] {
    return ol.proj.transform(coordinate, "EPSG:3857", "EPSG:4326");
  }
  private getDraw(drawType: any, feature: any): any {
    switch (drawType) {
      case "Circle":
        return {
          drawType: drawType,
          value: {
            coord: this.transformCoordinate(feature.getCenter()),
            radius: feature.getRadius(),
          },
        };
      case "Polygon":
        return {
          drawType: drawType,
          value: feature
            .getCoordinates()[0]
            .map((coordinate) => this.transformCoordinate(coordinate)),
        };
      case "LineString":
        return {
          drawType: drawType,
          value: feature
            .getCoordinates()
            .map((coordinate) => this.transformCoordinate(coordinate)),
        };
      default:
        return {
          drawType: drawType,
          value: 0,
        };
    }
  }
}
