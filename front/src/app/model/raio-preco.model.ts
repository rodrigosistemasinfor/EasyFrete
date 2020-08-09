import { DomainBase } from "../domain/base/base.domain";
import { ObjectMapper, JsonProperty } from "json-object-mapper";

export class RaioPreco extends DomainBase {
  @JsonProperty({ name: 'Lat' })
  public Lat: number;
  @JsonProperty({ name: 'Long' })
  public Long: number;
  @JsonProperty({ name: 'Raio' })
  public Raio: number;
  @JsonProperty({ name: 'Preco' })
  public Preco: number;
  @JsonProperty({ name: 'Loja' })
  public Loja: number;
  @JsonProperty({ name: 'Descricao' })
  public Descricao: number;

  static Create(json: any): RaioPreco {
    return ObjectMapper.deserialize<RaioPreco>(RaioPreco, json);
  }
}
