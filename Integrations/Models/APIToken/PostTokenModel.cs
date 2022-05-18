using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Integrations.Models.APIToken
{
   [DataContract]
   public class PostTokenModel
   {
      public PostTokenModel()
      {
         ClienteID = "mJJvLnDDkmh9DITi9CoFyqZEAbTnsXFF";
         ClienteSecret = "4QdgWcL8MqyliBA2RUzmTv57AAmma6LRfF_YoP5Wb_THyFF0H4Q6U0tTRAvV8t5j";
         Audience = "https://localhost:5021";
         GrantType = "client_credentials";

      }

      [DataMember(Name = "client_id", EmitDefaultValue = false)]
      [JsonProperty(propertyName: "client_id")]
      public string ClienteID { get; set; }

      [DataMember(Name = "client_secret", EmitDefaultValue = false)]
      [JsonProperty(propertyName: "client_secret")]
      public string ClienteSecret { get; set; }

      [DataMember(Name = "audience", EmitDefaultValue = false)]
      [JsonProperty(propertyName: "audience")]
      public string Audience { get; set; }

      [DataMember(Name = "grant_type", EmitDefaultValue = false)]
      [JsonProperty(propertyName: "grant_type")]
      public string GrantType { get; set; }
   }
}
