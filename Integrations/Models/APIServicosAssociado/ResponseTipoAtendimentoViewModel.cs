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
  public class ResponseTipoAtendimentoViewModel {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Nome
    /// </summary>
    [DataMember(Name="nome", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nome")]
    public string Nome { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseTipoAtendimentoViewModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Nome: ").Append(Nome).Append("\n");
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
