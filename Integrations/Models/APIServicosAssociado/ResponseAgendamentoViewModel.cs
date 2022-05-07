using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado
{

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ResponseAgendamentoViewModel {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets TipoAtendimento
    /// </summary>
    [DataMember(Name="tipoAtendimento", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tipoAtendimento")]
    public ResponseTipoAtendimentoViewModel TipoAtendimento { get; set; }

    /// <summary>
    /// Gets or Sets Associado
    /// </summary>
    [DataMember(Name="associado", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "associado")]
    public ResponseAssociadoViewModel Associado { get; set; }

    /// <summary>
    /// Gets or Sets Conveniado
    /// </summary>
    [DataMember(Name="conveniado", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "conveniado")]
    public ResponseConveniadoViewModel Conveniado { get; set; }

    /// <summary>
    /// Gets or Sets Endereco
    /// </summary>
    [DataMember(Name="endereco", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "endereco")]
    public ResponseEnderecoViewModel Endereco { get; set; }

    /// <summary>
    /// Gets or Sets DataAtendimento
    /// </summary>
    [DataMember(Name="dataAtendimento", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataAtendimento")]
    public DateTime? DataAtendimento { get; set; }

    /// <summary>
    /// Gets or Sets DataAgendamento
    /// </summary>
    [DataMember(Name="dataAgendamento", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataAgendamento")]
    public DateTime? DataAgendamento { get; set; }

    /// <summary>
    /// Gets or Sets Relatorio
    /// </summary>
    [DataMember(Name="relatorio", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "relatorio")]
    public ResponseRelatorioViewModel Relatorio { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseAgendamentoViewModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  TipoAtendimento: ").Append(TipoAtendimento).Append("\n");
      sb.Append("  Associado: ").Append(Associado).Append("\n");
      sb.Append("  Conveniado: ").Append(Conveniado).Append("\n");
      sb.Append("  Endereco: ").Append(Endereco).Append("\n");
      sb.Append("  DataAtendimento: ").Append(DataAtendimento).Append("\n");
      sb.Append("  DataAgendamento: ").Append(DataAgendamento).Append("\n");
      sb.Append("  Relatorio: ").Append(Relatorio).Append("\n");
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
