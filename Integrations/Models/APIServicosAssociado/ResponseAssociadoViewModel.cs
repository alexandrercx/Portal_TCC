using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ResponseAssociadoViewModel {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Documento
    /// </summary>
    [DataMember(Name="documento", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "documento")]
    public long? Documento { get; set; }

    /// <summary>
    /// Gets or Sets Nome
    /// </summary>
    [DataMember(Name="nome", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nome")]
    public string Nome { get; set; }

    /// <summary>
    /// Gets or Sets Ativo
    /// </summary>
    [DataMember(Name="ativo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ativo")]
    public string Ativo { get; set; }

    /// <summary>
    /// Gets or Sets DataCadastro
    /// </summary>
    [DataMember(Name="dataCadastro", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataCadastro")]
    public DateTime? DataCadastro { get; set; }

    /// <summary>
    /// Gets or Sets DataAtualizacao
    /// </summary>
    [DataMember(Name="dataAtualizacao", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataAtualizacao")]
    public DateTime? DataAtualizacao { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseAssociadoViewModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Documento: ").Append(Documento).Append("\n");
      sb.Append("  Nome: ").Append(Nome).Append("\n");
      sb.Append("  Ativo: ").Append(Ativo).Append("\n");
      sb.Append("  DataCadastro: ").Append(DataCadastro).Append("\n");
      sb.Append("  DataAtualizacao: ").Append(DataAtualizacao).Append("\n");
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
