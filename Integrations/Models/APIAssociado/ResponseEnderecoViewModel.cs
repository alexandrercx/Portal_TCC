using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ServicoAssociadoWeb.Integrations.Models.APIAssociado {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ResponseEnderecoViewModel {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets TipoEndereco
    /// </summary>
    [DataMember(Name="tipoEndereco", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tipoEndereco")]
    public string TipoEndereco { get; set; }

    /// <summary>
    /// Gets or Sets Logradouro
    /// </summary>
    [DataMember(Name="logradouro", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logradouro")]
    public string Logradouro { get; set; }

    /// <summary>
    /// Gets or Sets Numero
    /// </summary>
    [DataMember(Name="numero", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numero")]
    public string Numero { get; set; }

    /// <summary>
    /// Gets or Sets Bairro
    /// </summary>
    [DataMember(Name="bairro", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bairro")]
    public string Bairro { get; set; }

    /// <summary>
    /// Gets or Sets Cidade
    /// </summary>
    [DataMember(Name="cidade", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cidade")]
    public string Cidade { get; set; }

    /// <summary>
    /// Gets or Sets Cep
    /// </summary>
    [DataMember(Name="cep", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cep")]
    public string Cep { get; set; }

    /// <summary>
    /// Gets or Sets Uf
    /// </summary>
    [DataMember(Name="uf", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "uf")]
    public string Uf { get; set; }

    /// <summary>
    /// Gets or Sets Complemento
    /// </summary>
    [DataMember(Name="complemento", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "complemento")]
    public string Complemento { get; set; }

    /// <summary>
    /// Gets or Sets Pais
    /// </summary>
    [DataMember(Name="pais", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pais")]
    public string Pais { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseEnderecoViewModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  TipoEndereco: ").Append(TipoEndereco).Append("\n");
      sb.Append("  Logradouro: ").Append(Logradouro).Append("\n");
      sb.Append("  Numero: ").Append(Numero).Append("\n");
      sb.Append("  Bairro: ").Append(Bairro).Append("\n");
      sb.Append("  Cidade: ").Append(Cidade).Append("\n");
      sb.Append("  Cep: ").Append(Cep).Append("\n");
      sb.Append("  Uf: ").Append(Uf).Append("\n");
      sb.Append("  Complemento: ").Append(Complemento).Append("\n");
      sb.Append("  Pais: ").Append(Pais).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
