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
  public class ResponseContaBancoViewModel {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets BancoId
    /// </summary>
    [DataMember(Name="bancoId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bancoId")]
    public int? BancoId { get; set; }

    /// <summary>
    /// Gets or Sets Agencia
    /// </summary>
    [DataMember(Name="agencia", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "agencia")]
    public string Agencia { get; set; }

    /// <summary>
    /// Gets or Sets DigitoAgencia
    /// </summary>
    [DataMember(Name="digitoAgencia", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "digitoAgencia")]
    public string DigitoAgencia { get; set; }

    /// <summary>
    /// Gets or Sets Conta
    /// </summary>
    [DataMember(Name="conta", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "conta")]
    public string Conta { get; set; }

    /// <summary>
    /// Gets or Sets DigitoConta
    /// </summary>
    [DataMember(Name="digitoConta", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "digitoConta")]
    public string DigitoConta { get; set; }

    /// <summary>
    /// Gets or Sets TipoConta
    /// </summary>
    [DataMember(Name="tipoConta", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tipoConta")]
    public string TipoConta { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseContaBancoViewModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  BancoId: ").Append(BancoId).Append("\n");
      sb.Append("  Agencia: ").Append(Agencia).Append("\n");
      sb.Append("  DigitoAgencia: ").Append(DigitoAgencia).Append("\n");
      sb.Append("  Conta: ").Append(Conta).Append("\n");
      sb.Append("  DigitoConta: ").Append(DigitoConta).Append("\n");
      sb.Append("  TipoConta: ").Append(TipoConta).Append("\n");
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
