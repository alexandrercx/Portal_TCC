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
  public class RequestAgendamentoViewModel {
    /// <summary>
    /// Gets or Sets TipoAtendimentoId
    /// </summary>
    [DataMember(Name="tipoAtendimentoId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tipoAtendimentoId")]
    public int TipoAtendimentoId { get; set; }

    /// <summary>
    /// Gets or Sets AssociadoId
    /// </summary>
    [DataMember(Name="associadoId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "associadoId")]
    public long? AssociadoId { get; set; }

    /// <summary>
    /// Gets or Sets ConveniadoId
    /// </summary>
    [DataMember(Name="conveniadoId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "conveniadoId")]
    public long? ConveniadoId { get; set; }

    /// <summary>
    /// Gets or Sets EnderecoId
    /// </summary>
    [DataMember(Name="enderecoId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "enderecoId")]
    public long? EnderecoId { get; set; }

    /// <summary>
    /// Gets or Sets DataAtendimento
    /// </summary>
    [DataMember(Name="dataAtendimento", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataAtendimento")]
    public DateTime? DataAtendimento { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestAgendamentoViewModel {\n");
      sb.Append("  TipoAtendimentoId: ").Append(TipoAtendimentoId).Append("\n");
      sb.Append("  AssociadoId: ").Append(AssociadoId).Append("\n");
      sb.Append("  ConveniadoId: ").Append(ConveniadoId).Append("\n");
      sb.Append("  EnderecoId: ").Append(EnderecoId).Append("\n");
      sb.Append("  DataAtendimento: ").Append(DataAtendimento).Append("\n");
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
