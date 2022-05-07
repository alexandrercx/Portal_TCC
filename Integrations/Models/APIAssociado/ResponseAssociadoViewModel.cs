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
  public class ResponseAssociadoViewModel {
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
    /// Gets or Sets Cpf
    /// </summary>
    [DataMember(Name="cpf", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cpf")]
    public long? Cpf { get; set; }

    /// <summary>
    /// Gets or Sets DataNascimento
    /// </summary>
    [DataMember(Name="dataNascimento", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataNascimento")]
    public DateTime? DataNascimento { get; set; }

    /// <summary>
    /// Gets or Sets NomeMae
    /// </summary>
    [DataMember(Name="nomeMae", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nomeMae")]
    public string NomeMae { get; set; }

    /// <summary>
    /// Gets or Sets Cns
    /// </summary>
    [DataMember(Name="cns", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cns")]
    public long? Cns { get; set; }

    /// <summary>
    /// Gets or Sets PisPasep
    /// </summary>
    [DataMember(Name="pisPasep", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pisPasep")]
    public long? PisPasep { get; set; }

    /// <summary>
    /// Gets or Sets PlanoId
    /// </summary>
    [DataMember(Name="planoId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "planoId")]
    public long? PlanoId { get; set; }

    /// <summary>
    /// Gets or Sets Email
    /// </summary>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or Sets Senha
    /// </summary>
    [DataMember(Name="senha", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "senha")]
    public string Senha { get; set; }

    /// <summary>
    /// Gets or Sets Enderecos
    /// </summary>
    [DataMember(Name="enderecos", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "enderecos")]
    public List<ResponseEnderecoViewModel> Enderecos { get; set; }

    /// <summary>
    /// Gets or Sets Telefones
    /// </summary>
    [DataMember(Name="telefones", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "telefones")]
    public List<ResponseTelefoneViewModel> Telefones { get; set; }

    /// <summary>
    /// Gets or Sets ContaBanco
    /// </summary>
    [DataMember(Name="contaBanco", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contaBanco")]
    public ResponseContaBancoViewModel ContaBanco { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseAssociadoViewModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Nome: ").Append(Nome).Append("\n");
      sb.Append("  Cpf: ").Append(Cpf).Append("\n");
      sb.Append("  DataNascimento: ").Append(DataNascimento).Append("\n");
      sb.Append("  NomeMae: ").Append(NomeMae).Append("\n");
      sb.Append("  Cns: ").Append(Cns).Append("\n");
      sb.Append("  PisPasep: ").Append(PisPasep).Append("\n");
      sb.Append("  PlanoId: ").Append(PlanoId).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  Senha: ").Append(Senha).Append("\n");
      sb.Append("  Enderecos: ").Append(Enderecos).Append("\n");
      sb.Append("  Telefones: ").Append(Telefones).Append("\n");
      sb.Append("  ContaBanco: ").Append(ContaBanco).Append("\n");
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
