using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado
{
    public class ResponsePlanoViewModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        [DataMember(Name = "nome", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "valorBase", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "valorBase")]
        public decimal ValorBase { get; set; }
    }
}
