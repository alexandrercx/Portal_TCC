using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Integrations.Models.APIToken
{
   [DataContract]
   public class ResponseTokenModel
   {
      [DataMember(Name = "access_token", EmitDefaultValue = false)]
      [JsonProperty(PropertyName = "access_token")]
      public string AccessToken { get; set; }

      [DataMember(Name = "expires_in", EmitDefaultValue = false)]
      [JsonProperty(PropertyName = "expires_in")]
      public int ExpiresIn { get; set; }

      [DataMember(Name = "token_type", EmitDefaultValue = false)]
      [JsonProperty(PropertyName = "token_type")]
      public string TokenType { get; set; }
   }
}
