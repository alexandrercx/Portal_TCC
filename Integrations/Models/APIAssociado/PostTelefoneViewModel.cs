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
  public class PostTelefoneViewModel {
    /// <summary>
    /// Gets or Sets Numero
    /// </summary>
    [DataMember(Name="numero", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numero")]
    public string Numero { get; set; }

    /// <summary>
    /// Gets or Sets Ddi
    /// </summary>
    [DataMember(Name="ddi", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ddi")]
    public string Ddi { get; set; }

    /// <summary>
    /// Gets or Sets Ddd
    /// </summary>
    [DataMember(Name="ddd", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ddd")]
    public string Ddd { get; set; }

    /// <summary>
    /// Gets or Sets TipoTelefone
    /// </summary>
    [DataMember(Name="tipoTelefone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tipoTelefone")]
    public string TipoTelefone { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PostTelefoneViewModel {\n");
      sb.Append("  Numero: ").Append(Numero).Append("\n");
      sb.Append("  Ddi: ").Append(Ddi).Append("\n");
      sb.Append("  Ddd: ").Append(Ddd).Append("\n");
      sb.Append("  TipoTelefone: ").Append(TipoTelefone).Append("\n");
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
