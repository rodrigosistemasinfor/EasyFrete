import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, retry } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { RaioPreco } from "../model/raio-preco.model";

@Injectable({
  providedIn: "root",
})
export class RaioPrecoService {
  private endPoint: string;

  constructor(private http: HttpClient) {
    this.endPoint = `${environment.Api}raioPreco/`;
  }

  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };

  insertMany(arr: RaioPreco[]): Observable<any> {
    return this.http.post(`${this.endPoint}`, arr).pipe(
      retry(2),
      map((resp) => resp)
    );
  }
}
