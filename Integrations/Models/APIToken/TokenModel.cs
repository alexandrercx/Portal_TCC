using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Integrations.Models.APIToken
{
   public class TokenModel
   {
      public ResponseTokenModel Response { get; set; }
      public DateTime ExpiresIn { get; set; }
   }
}
