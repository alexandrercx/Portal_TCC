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
  public class ResponseRelatorioViewModel {
    /// <summary>
    /// Gets or Sets CodigoHttp
    /// </summary>
    [DataMember(Name="codigoHttp", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "codigoHttp")]
    public int? CodigoHttp { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets Detalhes
    /// </summary>
    [DataMember(Name="detalhes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "detalhes")]
    public List<ResponseDetalheRelatorioViewModel> Detalhes { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseRelatorioViewModel {\n");
      sb.Append("  CodigoHttp: ").Append(CodigoHttp).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Detalhes: ").Append(Detalhes).Append("\n");
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
