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
  public class ResponseDetalheRelatorioViewModel {
    /// <summary>
    /// Gets or Sets Atributo
    /// </summary>
    [DataMember(Name="atributo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "atributo")]
    public string Atributo { get; set; }

    /// <summary>
    /// Gets or Sets Mensagem
    /// </summary>
    [DataMember(Name="mensagem", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mensagem")]
    public string Mensagem { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseDetalheRelatorioViewModel {\n");
      sb.Append("  Atributo: ").Append(Atributo).Append("\n");
      sb.Append("  Mensagem: ").Append(Mensagem).Append("\n");
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
